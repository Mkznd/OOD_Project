namespace Project_School.Iterator;

public interface ICollection<T> : IEnumerable<T>
{
    public int Count { get; }
    public bool Reverse { get; set; }

    public void PushBack(T value);
    public T? PopBack();
}