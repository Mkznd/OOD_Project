namespace Project_School.Iterator.Algorithms;

public static class ForEachAlgorithm<T>
{
    public static void ForEach(Interfaces.ICollection<T> collection, Func<T, object> func)
    {
        foreach (var elem in collection.Select(e => e)) func(elem);
    }
}