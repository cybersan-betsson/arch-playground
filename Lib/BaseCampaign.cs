global using KeyType = System.Guid;

namespace Lib;

internal interface IClock
{
	DateTime UtcNow { get; }
}

internal sealed class Clock : IClock
{
	public DateTime UtcNow { get => DateTime.UtcNow; }
}

internal abstract class BaseCampaign
{
	public KeyType Id { get; set; } = KeyType.NewGuid();
	public string Name { get; set; } = "";
}

internal class DraftCampaing : BaseCampaign
{

}

internal class StartedCampaing : DraftCampaing
{
	public required DateTime StartMoment;
}

internal sealed class FinishedCampaign : StartedCampaing
{
	public required DateTime FinishMoment;
}

internal interface IOrchestrator
{
	T PushState<T>(BaseCampaign baseCampaign);
}

internal class Orchestrator : IOrchestrator
{
	private readonly IClock clock;
	public Orchestrator(IClock clock) => this.clock = clock;

	public T PushState<T>(BaseCampaign oldStateCampaign) => oldStateCampaign switch
	{
		StartedCampaing startedCampaing => (T)(object)new FinishedCampaign()
		{
			Id = startedCampaing.Id,
			Name = startedCampaing.Name,
			StartMoment = startedCampaing.StartMoment,
			FinishMoment = clock.UtcNow
		},

		DraftCampaing draftCampaing => (T)(object)new StartedCampaing()
		{
			Id = draftCampaing.Id,
			Name = draftCampaing.Name,
			StartMoment = clock.UtcNow
		},
		
		_ => throw new NotSupportedException(),
	};
}
