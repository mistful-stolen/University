using System.IO.IsolatedStorage;
using System.Reflection.Metadata;

class Garage : IRealEstate, IRent
{
    double area;
    int unitPrice;
    bool isHeated;
    int months;
    bool isOccupied;

    public Garage()
    {
    }

    

    public bool IsBooked => months > 0 || isOccupied;

    public int UpdateOccupied()
    {
        return (int) area * unitPrice;
    }

    public override string ToString()
    {
        return $"Area: {area}, Vale: {TotalValue()}, Heated: {(isHeated ? "Yes" : "No")}";
    }

    public bool Book(int months)
    {
        if (IsBooked) { return false; }

        this.months = months;
        return true;
    }

    public int GetCost(int months)
    {
        return (int)(months * TotalValue() / 120 * (isHeated ? 1.5 : 1));
    }

    public int TotalValue()
    {
        throw new NotImplementedException();
    }

    
}