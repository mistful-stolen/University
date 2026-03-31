public class FrozenFoodPackage : FoodPackage
{
    public FrozenFoodPackage(int weight, string address, Wrapper wrapper) : base(weight, address, wrapper)
    {
        if (wrapper == Wrapper.Standard) throw (new InvalidPackageException(this));
    }

    public override double CalculatePrice(bool priorityDelivery)
    {
        if (priorityDelivery) throw (new DeliveryException("Nem kérhet prioritás kiszállítást!"));

        return 2000 + (Weight * 3);

        

        
    }
}