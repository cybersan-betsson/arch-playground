namespace Domain;

internal static class CampaignExtensions
{
	public static IServiceCollection AddCampaigns(this IServiceCollection services)
	{
		services.TryAddTransient<ICampaignService, CampaignService>();
		return services;
	}
}
