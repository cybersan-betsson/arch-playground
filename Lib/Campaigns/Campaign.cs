namespace Lib;

internal class Campaign
{
	public required KeyType Id { get; init; }
	public required string Name { get; init; }
	public required CampaignStatus Status { get; init; }
	public required ISegmentSet SegmentSet { get; init; }
	public required IBrand Brand { get; init; }
	public required ICommunicationSet CommunicationSet { get; init; }
}
