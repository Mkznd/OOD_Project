namespace Project_School.Iterator.Algorithms;

/// <summary>
///     Algorithm to find element/elements of the collection implementing
///     <see cref="Interfaces.Iterator.ICollection{T}" />
///     interface that satisfy passed delegate
/// </summary>
/// <typeparam name="T">Type of the element in the collection</typeparam>
public static class FindAlgorithm<T>
{
    /// <summary>
    ///     Method that finds the first element for which delegate returns <c>true</c> or <c>null</c>
    /// </summary>
    /// <param name="collection">Collection to search in</param>
    /// <param name="func">Delegate returning bool?</param>
    /// <param name="reverse">Should the method seek from the beginning or the end of the collection</param>
    /// <returns>
    ///     The seeked element or default value for <typeparamref name="T" />
    /// </returns>
    public static T? FindFirst(Interfaces.Iterator.ICollection<T> collection, Func<T, bool?> func, bool reverse)
    {
        collection.Reverse = reverse;
        var result = collection.FirstOrDefault(e => func(e) is null or true);
        return result;
    }
}