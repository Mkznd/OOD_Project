namespace Project_School.Iterator;

public static class PrintAlgorithm<T>
{
    public static void Print(ICollection<T> collection, Func<T, bool?> func, bool reverse)
    {
        collection.Reverse = reverse;
        foreach (var elem in collection.Where(e => func(e) is null or true))
            if (elem != null)
                Console.WriteLine(elem);
    }
}