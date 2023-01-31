namespace Lib;

internal sealed class KeyType
{
	private Guid Value { get; set; } = Guid.NewGuid();

	public override string ToString() => Value.ToString();

	public void FromString(string value) => Value = Guid.Parse(value);
}
