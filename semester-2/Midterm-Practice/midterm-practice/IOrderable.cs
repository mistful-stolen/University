public interface IOrderable
{
    public int Weight { get; set; }
    public string Address { get; set; }
    public double CalculatePrice(bool priorityDelivery);
}