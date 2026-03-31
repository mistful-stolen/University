public class InvalidPackageException : DeliveryException
{
    public FrozenFoodPackage FRZN { get; }

    public InvalidPackageException(FrozenFoodPackage frzn)
    {
        FRZN = frzn;
    }

    public InvalidPackageException(string? message, FrozenFoodPackage frzn) : base(message)
    {
        FRZN = frzn;
    }

    public InvalidPackageException(string? message, Exception? innerException, FrozenFoodPackage frzn) : base(message, innerException)
    {
        FRZN = frzn;
    }
}