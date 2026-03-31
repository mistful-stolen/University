public abstract class FoodPackage : IOrderable, IComparable
{
    public FoodPackage(int weight, string address)
    {
        Weight = weight;
        Address = address;
    }

    public FoodPackage(int weight, string address, Wrapper wrapper)
    {
        Weight = weight;
        Address = address;
        Wrapper = wrapper;
    }

    public int Weight { get; set; }
    public string Address { get; set; }
    public Wrapper Wrapper { get; }


    public abstract double CalculatePrice(bool priorityDelivery);

    public int CompareTo(object? obj)
    {
        if (obj is not FoodPackage) throw (new Exception());

        FoodPackage? other = obj as FoodPackage;

        if (this.Weight < other?.Weight) return -1;
        if (this.Weight > other?.Weight) return 1;

        return 0;
    }


    public override string ToString()
    {
        return $"Cím: {Address} / Csomagolás: {Wrapper} / Tömeg: {Weight} g";
    }

}

public enum Wrapper { Standard, Insulated, Frozen }