using System.Reflection.Metadata;

public class RegularFoodPackage : FoodPackage
{

    
    
    static private Random rndm = new Random();

    public RegularFoodPackage(int weight, string address) : base(weight, address, (Wrapper)rndm.Next(0, 3)) {    }

    public override double CalculatePrice(bool priorityDelivery)
    {
        double price = 1000 + (Weight * 2);

        return priorityDelivery ? price + 700 : price;
    }
}