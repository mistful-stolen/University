public class NotOrderedItemsException : Exception
{
    private IComparable[] items;
    public NotOrderedItemsException(IComparable[] items) : base("A tömb nem rendezett.")
    {
        this.items = items;
    }

    
}