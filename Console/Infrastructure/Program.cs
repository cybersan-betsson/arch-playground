namespace Console;

internal sealed class Program
{
	public static async Task<int> Main(string[] args)
	{
		try
		{
			var host = TryBuildHost(args) ?? throw new Exception("host is null");
			var errorCode = await TryRunHostAsync(host, CancellationToken.None);
			return (int)errorCode;
		}
		catch (Exception ex)
		{
			System.Console.Error.WriteLine($"General error during Main: {ex}");
			return (int)ErrorCode.GeneralError;
		}
	}

	static IHost? TryBuildHost(string[] args, Action<HostBuilderContext, IServiceCollection>? configureServices = null)
	{
		var host = Host
			.CreateDefaultBuilder(args)
			// methods of Host below listed in order of execution
			.ConfigureHostConfiguration(configurationBuilder =>
			{

			})
			.ConfigureAppConfiguration(builder =>
			{
				var cultureInfo = new CultureInfo((int)CultureTypes.NeutralCultures);
				var maschineName = cultureInfo.TextInfo.ToTitleCase(Environment.MachineName);
				builder.AddJsonFile(path: "appsettings.json", optional: false, reloadOnChange: true);
				builder.AddJsonFile(path: $"appsettings.Maschine.{maschineName}.json", optional: true, reloadOnChange: true);
				builder.AddJsonFile(path: $"appsettings.User.{Environment.UserName}.json", optional: true, reloadOnChange: true);
				builder.AddEnvironmentVariables(Const.ENVIRONMENTAL_VARIABLES_PREFIX);
				builder.AddCommandLine(args); // program.exe -d VAR=val
			})
			.ConfigureLogging((hostingContext, builder) =>
			{
				builder
					.AddConsole()
					.AddCyberConsole();
			})
			.ConfigureServices((context, services) =>
			{
				HostedService.ConfigureServices(context, services);
				configureServices?.Invoke(context, services);
			})
			.Build();

		return host;
	}

	private static async Task<ErrorCode> TryRunHostAsync(IHost host, CancellationToken cancellationToken)
	{
		try
		{
			await host.RunAsync(cancellationToken);
			return ErrorCode.NoError;
		}
		catch (TaskCanceledException)
		{
			System.Console.WriteLine($"TaskCanceledException (Ctrl-C maybe), no proper software finish, error code {(int)ErrorCode.TaskCancelled} (ErrorCode.TaskCancelled)");
			return ErrorCode.TaskCancelled;
		}
	}
}