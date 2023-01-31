namespace Lib;

[Serializable]
internal class CampaignChangeStatusException : Exception
{
	private Campaign? campaign;
	private CampaignStatus? status;

	public CampaignChangeStatusException()
	{
	}

	public CampaignChangeStatusException(string? message) : base(message)
	{
	}

	public CampaignChangeStatusException(Campaign campaign, CampaignStatus status) : this($"Wrong status transition for campaign {campaign.Id} from {campaign.Status} to {status}")
	{
		this.campaign = campaign;
		this.status = status;
	}

	public CampaignChangeStatusException(string? message, Exception? innerException) : base(message, innerException)
	{
	}

	protected CampaignChangeStatusException(SerializationInfo info, StreamingContext context) : base(info, context)
	{
	}
}