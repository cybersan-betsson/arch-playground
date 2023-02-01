namespace Lib;

internal interface IBetflixSet<T>
{
	void Add(T item);
	void Remove(T item);
	bool Contains(T item);
	int Count();
	IEnumerable<T> AsEnumerable();
}