namespace Lib
{
	internal class Logic : ILogic
	{
		#region ctor
		private readonly ILogger logger;
		private readonly AppSettings appSettings;
		public Logic(ILogger<Logic> logger, IOptions<AppSettings> options)
		{
			this.logger = logger;
			this.appSettings = options.Value;

#if DEBUG

		LogEveryLevelToSeeColors(logger);

		static void LogEveryLevelToSeeColors(ILogger logger)
		{
			logger.LogTrace("TRACE");
			logger.LogDebug("DEBUG");
			logger.LogInformation("INFORMATION");
			logger.LogWarning("WARNING");
			logger.LogError("ERROR");
			logger.LogCritical("CRITICAL");
		}

#endif

		}
		#endregion

		public Task RunAsync(CancellationToken cancellationToken)
		{
			logger.LogInformation("AppVersion {appVersion}, VS template version {vsTemplateVersion}", appSettings.Version, appSettings.VisualStudioTemplateVersion);

			return Task.CompletedTask;
		}
	}
}