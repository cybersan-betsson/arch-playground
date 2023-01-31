namespace Lib;

internal interface ISegmentSet
{
	void Add(Segment segment);
	void Remove(Segment segment);
	bool Contains(Segment segment);
	int Count();
	IEnumerable<Segment> AsEnumerable();
}