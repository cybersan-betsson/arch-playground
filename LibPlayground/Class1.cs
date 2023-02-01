namespace LibPlayground;

internal interface ISomeService
{
	void SomeMethod();
}

internal class SomeService : ISomeService
{
	public void SomeMethod()
	{
	}
}

internal static class Extensions
{
	internal static IServiceCollection AddSomeServices(this IServiceCollection services)
	{
		services.TryAddTransient<ISomeService, SomeService>();
		return services;
	}
}

internal class LoggingService : ISomeService
{
	private readonly ISomeService someService;

	public LoggingService(ISomeService someService) => this.someService = someService;

	public void SomeMethod()
	{
		DoSomethingBefore();
		someService.SomeMethod();
		DoSomethingAfter();
	}

	private void DoSomethingBefore()
	{
	}

	private void DoSomethingAfter()
	{
	}
}

internal static class Extensions2
{
	internal static IServiceCollection AddSomeServices(this IServiceCollection services)
	{
		services.TryAddTransient<ISomeService, LoggingService>();
		return services;
	}

	internal static IServiceCollection AddSomeServices2(this IServiceCollection services)
	{
		services.TryAddTransient<SomeService>();
		services.TryAddTransient<ISomeService>((provider) => new LoggingService(provider.GetRequiredService<SomeService>()));
		return services;
	}
}