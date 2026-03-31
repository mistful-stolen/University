public class FoodTooHeavyException : Exception
{
    public FoodTooHeavyException() : base()
    {
    }

    public FoodTooHeavyException(string? message) : base(message)
    {
    }

    public FoodTooHeavyException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}