using System.Dynamic;

public class NotSetException : Exception
{
    public IComparable[] Items { get; private set;}
    public NotSetException(IComparable[] items, string message) : base(message)
    {
        Items = items;
    }
}