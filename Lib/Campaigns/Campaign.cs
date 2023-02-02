namespace Domain;

public class Campaign
{
	public required KeyType Id { get; init; }

	public required string Name { get; init; }
	public required CampaignStatus Status { get; init; }
	public required Brand Brand { get; init; }

	public required Segments Segments { get; init; }

	public required ICommunicationSet Communications { get; init; }
	public required IExcludedCustomersSet ExcludedCustomers { get; init; }

	public IEnumerable<string> Countries { get; set; } = Enumerable.Empty<string>();

	public DateTime StartDate { get; set; }
	public DateTime EndDate { get; set; }
	public string JiraReference { get; set; } = string.Empty;
	public string CreatedBy { get; set; } = string.Empty;
	public string? ApprovedBy { get; set; }
	public string Product { get; set; } = string.Empty;
	public string BudgetCode => "BTLRET";
}
