using System.Collections;

namespace Project_School.Iterator.Collections;

public class Hashmap<T> : Interfaces.Iterator.ICollection<T>
{
    private readonly T[] _array;
    private readonly int _capacity;

    public Hashmap(int capacity)
    {
        _array = new T[capacity];
        _capacity = capacity;
    }

    public int Count { get; } = 0;
    public bool Reverse { get; set; } = false;

    public void PushBack(T value)
    {
        if (value is null) return;
        _array[value.GetHashCode() % _capacity] = value;
    }

    public T? PopBack()
    {
        throw new NotImplementedException();
    }

    // IEnumerator implementation
    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void DeleteElement(T value)
    {
        _array[value.GetHashCode() % _capacity] = default;
    }
}