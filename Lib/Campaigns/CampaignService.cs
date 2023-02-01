namespace Lib;

internal sealed class CampaignService : ICampaignService
{
	public Campaign CreateCampaign(string name, IBrand brand) => new()
	{
		Id = new KeyType(),
		Name = name,
		Status = CampaignStatus.PreDraft,
		Segments = new SegmentSet(),
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
		}
		else
		{
			throw new CampaignChangeStatusException(campaign, status);
		}
	}
}
