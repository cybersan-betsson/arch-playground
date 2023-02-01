namespace Lib;

internal abstract class BaseBetflixSet<T> : IBetflixSet<T>
{
    private readonly HashSet<T> items = new();

    public void Add(T item) => items.Add(item);
    public bool Contains(T item) => items.Contains(item);
    public int Count() => items.Count;
    public IEnumerable<T> AsEnumerable() => items.AsEnumerable();
    public void Remove(T segment) => items.Remove(segment);
}
