namespace Project_School.Iterator.Algorithms;

public static class CountIfAlgorithm<T>
{
    public static int CountIf(Interfaces.Iterator.ICollection<T> collection, Func<T, bool?> func, bool reverse)
    {
        var c = collection.Where(e => func(e) is true).Count(elem => elem != null);
        return c;
    }
}