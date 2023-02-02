namespace Domain;

internal sealed class BrandImpl : Brand
{
	public required KeyType Id { get; init; }
	public required string Name { get; init; }
	public required string Code { get; init; }
}