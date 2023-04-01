namespace Project_School.Iterator;

public static class FindAlgorithm<T>
{
    public static T? FindFirst(ICollection<T> collection, Func<T, bool?> func, bool reverse)
    {
        collection.Reverse = reverse;
        var result = collection.FirstOrDefault(e => func(e) is null or true);
        return result;
    }
}