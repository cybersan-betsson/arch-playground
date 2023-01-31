namespace Lib
{
	internal interface ILogic
	{
		Task RunAsync(CancellationToken cancellationToken);
	}
}