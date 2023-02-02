namespace Domain;

internal interface IClock
{
	DateTime UtcNow { get; }
}
