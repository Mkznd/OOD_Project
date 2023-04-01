using System.Collections;

namespace Project_School.Iterator;

public class ResizableArray<T> : ICollection<T>
{
    private T?[] _items;

    public ResizableArray()
    {
        _items = new T[4];
        Count = 0;
    }

    public int Count { get; private set; }
    public bool Reverse { get; set; }

    public void PushBack(T value)
    {
        if (Count == _items.Length) Array.Resize(ref _items, _items.Length * 2);

        _items[Count++] = value;
    }

    public T? PopBack()
    {
        if (Count == 0) throw new InvalidOperationException("The list is empty.");

        var value = _items[--Count];
        _items[Count] = default;

        if (Count <= _items.Length / 4) Array.Resize(ref _items, _items.Length / 2);

        return value;
    }

    // IEnumerable implementation

    public IEnumerator<T> GetEnumerator()
    {
        return Reverse ? GetReverseEnumerator() : GetForwardEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerator<T> GetReverseEnumerator()
    {
        for (var i = Count - 1; i >= 0; i--)
            yield return _items[i] ?? throw new InvalidOperationException();
    }

    public IEnumerator<T> GetForwardEnumerator()
    {
        for (var i = 0; i < Count; i++) yield return _items[i] ?? throw new InvalidOperationException();
    }
}