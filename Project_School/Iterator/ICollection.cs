namespace Project_School.Iterator;

public interface ICollection<T>
{
    public int Count { get; }
    public void PushBack(T value);
    public T? PopBack();
}