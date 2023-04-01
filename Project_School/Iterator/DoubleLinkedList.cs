using System.Collections;

namespace Project_School.Iterator;

public class LinkedListNode<T>
{
    public T Value { get; set; }
    public LinkedListNode<T>? Prev { get; set; }
    public LinkedListNode<T>? Next { get; set; }

    public LinkedListNode(T value)
    {
        Value = value;
        Prev = null;
        Next = null;
    }
}

public class DoubleLinkedList<T> : ICollection<T>, IEnumerable<T>
{
    private LinkedListNode<T>? _head;
    private LinkedListNode<T>? _tail;

    public int Count { get; private set; }

    public DoubleLinkedList()
    {
        _head = null;
        _tail = null;
        Count = 0;
    }

    public void PushBack(T value)
    {
        var node = new LinkedListNode<T>(value);

        if (_head == null)
        {
            _head = node;
            _tail = node;
        }
        else
        {
            if (_tail != null)
            {
                _tail.Next = node;
                node.Prev = _tail;
            }

            _tail = node;
        }

        Count++;
    }

    public T PopBack()
    {
        if (_tail == null)
        {
            throw new InvalidOperationException("The list is empty.");
        }

        var value = _tail.Value;

        if (_head == _tail)
        {
            // Only one element in the list
            _head = null;
            _tail = null;
        }
        else
        {
            _tail = _tail.Prev;
            if (_tail != null) _tail.Next = null;
        }

        Count--;
        return value;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var current = _head;

        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }
    
    public IEnumerator<T> GetReverseEnumerator()
    {
        var current = _tail;

        while (current != null)
        {
            yield return current.Value;
            current = current.Prev;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}