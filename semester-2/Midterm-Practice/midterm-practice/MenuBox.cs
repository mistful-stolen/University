public class MenuBox : IOrderable
{
    private string name;

    public MenuBox(string name, int weight, string address)
    {
        this.name = name;
        Weight = weight;
        Address = address;
    }

    public int Weight { get; set; }
    public string Address { get; set; }

    public double CalculatePrice(bool priorityDelivery)
    {
        if (Weight <= 300) return 800;
        if (Weight <= 1000) return 1500;
        if (Weight <= 3000) return 3000;

        throw (new FoodTooHeavyException());
    }

    public override string ToString()
    {
        return $"Cím: {Address} / Megnevezés: {name} / Tömeg: {Weight} g";
    }
}