namespace DatabaseLib;

public static class Extensions
{
	public static IServiceCollection AddDatabaseLib(this IServiceCollection services)
	{
		services.AddTransient<IRepository, CouchbaseRepository>();
		return services;
	}
}
