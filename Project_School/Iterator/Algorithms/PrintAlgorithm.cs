using Project_School.Interfaces.Iterator;

namespace Project_School.Iterator.Algorithms;

/// <summary>
///     Algorithm to print elements of the collection implementing
///     <see cref="Interfaces.Iterator.ICollection{T}" />
///     interface that satisfy passed delegate
/// </summary>
/// <typeparam name="T">Type of the element in the collection</typeparam>
public static class PrintAlgorithm<T>
{
    /// <summary>
    ///     Method that prints all elements for which delegate returns <c>true</c> or <c>null</c>
    /// </summary>
    /// <param name="collection">Collection to search in</param>
    /// <param name="func">Delegate returning bool?</param>
    /// <param name="reverse">Should the method seek from the beginning or the end of the collection</param>
    public static void Print(Interfaces.Iterator.ICollection<T> collection, Func<T, bool?> func, bool reverse)
    {
        collection.Reverse = reverse;
        foreach (var elem in collection.Where(e => func(e) is null or true))
            if (elem != null)
                Console.WriteLine(elem);
    }
}