namespace Project_School.Interfaces.Iterator;

/// <summary>
///     Custom ICollection interface defines basic methods for collection manipulation, also <see cref="Reverse" />
///     for Reverse collection traversal
/// </summary>
/// <typeparam name="T">Type of the elements in the collection</typeparam>
public interface ICollection<T> : IEnumerable<T>
{
    public int Count { get; }
    public bool Reverse { get; set; }

    /// <summary>
    ///     Inserts element at the end of the collection
    /// </summary>
    /// <param name="value">Value to insert</param>
    public void PushBack(T value);

    /// <summary>
    ///     Removes the last element of the collection and returns it
    /// </summary>
    /// <returns>Removed value</returns>
    public T? PopBack();
}