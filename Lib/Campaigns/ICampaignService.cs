namespace Domain;

internal interface ICampaignService
{
	Campaign CreateCampaign(string name, Brand brand);
	void ChangeState(Campaign campaign, CampaignStatus status);
	void AddSegment(Campaign campaign, Segment segment);

	Segments GetSegments(Campaign campaign);
}
