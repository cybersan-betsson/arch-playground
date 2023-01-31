namespace Console
{
	internal sealed class HostedService : IHostedService
	{
		#region ctor
		private readonly ILogic logic;

		public HostedService(ILogic logic) => this.logic = logic;
		#endregion

		/// <summary>
		/// Configure services here
		/// </summary>
		/// <param name="context"></param>
		/// <param name="services"></param>
		public static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
		{
			var config = context.Configuration;
			services.Configure<AppSettings>(config);
			services.Configure<CyberConsoleSettings>(config.GetSection("Logging:CyberConsole"));

			services.AddHostedService<HostedService>();

			services.TryAddTransient<ILogic, Logic>();
		}

		public async Task StartAsync(CancellationToken cancellationToken) => await logic.RunAsync(cancellationToken);

		public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
	}
}