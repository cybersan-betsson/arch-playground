namespace Domain;

internal sealed class CampaignService : ICampaignService
{
	#region ctor
	private readonly IClock clock;
	private readonly IRepository repository;

	public CampaignService(IClock clock, IRepository repository)
	{
		this.clock = clock;
		this.repository = repository;
	} 
	#endregion

	public Campaign CreateCampaign(string name, Brand brand) => new()
	{
		Id = new KeyType(),
		Name = name,
		Status = CampaignStatus.PreDraft,
		Segments = new SegmentImpl(),
		Brand = brand,
		Communications = new CommunicationSet(),
		ExcludedCustomers = new ExcludedCustomersSet()
	};

	public void ChangeState(Campaign campaign, CampaignStatus status)
	{
		if (campaign.Status == CampaignStatus.PreDraft && status == CampaignStatus.Draft
			// ...
			|| campaign.Status == CampaignStatus.Draft && status == CampaignStatus.AwaitingApproval)
		{
			repository.Save(campaign);
		}
		else
		{
			throw new CampaignChangeStatusException(campaign, status);
		}
	}

	public void AddSegment(Campaign campaign, Segment segment) => throw new NotImplementedException();

	public Segments GetSegments(Campaign campaign) => throw new NotImplementedException();
}
