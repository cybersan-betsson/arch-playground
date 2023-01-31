//global using KeyType = System.Guid;

namespace Console;

internal sealed class KeyType
{
	public Guid Value { get; set; } = Guid.NewGuid();

	public override string ToString() => Value.ToString();

	public string OtherFriendlyForm() => ".....";
}

internal interface IClock
{
	DateTime UtcNow { get; }
}

internal sealed class Clock : IClock
{
	public DateTime UtcNow { get => DateTime.UtcNow; }
}

// Draft => Started => Finished

internal abstract class _examples_
{
	public KeyType Id { get; set; } = new();

	public string Name { get; set; } = "";
}

internal class DraftCampaing : _examples_
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
	T PushState<T>(_examples_ baseCampaign);
}

internal class Orchestrator : IOrchestrator
{
	private readonly IClock clock;
	public Orchestrator(IClock clock) => this.clock = clock;

	public T PushState<T>(_examples_ oldStateCampaign) => oldStateCampaign switch
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

internal interface IOrchestrator2
{
	StartedCampaing PushState(DraftCampaing draftCampaing);

	FinishedCampaign PushState(StartedCampaing startedCampaing);
}

internal sealed class Orchestrator2 : IOrchestrator2
{
	private readonly IClock clock;
	public Orchestrator2(IClock clock) => this.clock = clock;

	public StartedCampaing PushState(DraftCampaing draftCampaing) => new()
	{
		Id = draftCampaing.Id,
		Name = draftCampaing.Name,
		StartMoment = clock.UtcNow
	};

	public FinishedCampaign PushState(StartedCampaing startedCampaing) => new()
	{
		Id = startedCampaing.Id,
		Name = startedCampaing.Name,
		StartMoment = startedCampaing.StartMoment,
		FinishMoment = clock.UtcNow
	};
}