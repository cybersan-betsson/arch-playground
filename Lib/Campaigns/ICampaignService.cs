namespace Lib;

internal interface ICampaignService
{
	Campaign CreateCampaign(string name, IBrand brand);
	void ChangeState(Campaign campaign, CampaignStatus status);
}
