namespace Domain;

[Serializable]
internal class CampaignException : Exception
{
	public CampaignException()
	{
	}

	public CampaignException(string? message) : base(message)
	{
	}

	public CampaignException(string? message, Exception? innerException) : base(message, innerException)
	{
	}

	protected CampaignException(SerializationInfo info, StreamingContext context) : base(info, context)
	{
	}
}