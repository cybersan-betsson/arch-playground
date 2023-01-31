namespace Console;

public sealed class CyberConsoleSettings : ConsoleFormatterOptions
{
	/// <summary>
	/// How to format moment of event. If null/empty - datetime is hidden
	/// </summary>
	public string DateTimeFormat { get; set; } = "";

	/// <summary>
	/// How long is the last element of category shown. Category is hidden if CategoryWidth < 1
	/// </summary>
	public int CategoryWidth { get; set; } = 0;

	public ColorsForLogLevels Colors { get; set; } = new();

	public class ColorsForLogLevels
	{
		public bool Enabled { get; set; } = true;

		public string None { get; set; } = "Black";
		public string Trace { get; set; } = "Gray";
		public string Debug { get; set; } = "White";
		public string Information { get; set; } = "LimeGreen";
		public string Warning { get; set; } = "Orange";
		public string Error { get; set; } = "Red";
		public string Critical { get; set; } = "Fuchsia";
	}
}