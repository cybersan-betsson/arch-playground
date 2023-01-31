namespace Lib;

internal sealed class SegmentSet : ISegmentSet
{
	private readonly HashSet<Segment> segments = new();

	public void Add(Segment segment) => segments.Add(segment);
	public bool Contains(Segment segment) => segments.Contains(segment);
	public int Count() => segments.Count;
	public IEnumerable<Segment> AsEnumerable() => segments.AsEnumerable();
	public void Remove(Segment segment) => segments.Remove(segment);
}
