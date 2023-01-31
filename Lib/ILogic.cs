namespace Console
{
	internal interface ILogic
	{
		Task RunAsync(CancellationToken cancellationToken);
	}
}