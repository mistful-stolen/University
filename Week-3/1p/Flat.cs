abstract class Flat : IRealEstate {
    protected double area;
    protected int roomsCount;
    protected int inhabitantsCount;
    protected int unitPrice;

    public int InhabitantsCount {
        get { return inhabitantsCount; }
    }

    public Flat(double area, int roomsCount, int inhabitantsCount, int unitPrice) {
        this.area = area;
        this.roomsCount = roomsCount;
        this.inhabitantsCount = inhabitantsCount;
        this.unitPrice = unitPrice;
    }

    public abstract bool MoveIn(int newInhabitants);

    public int TotalValue() {
        return (int) area * unitPrice;
    }

    public override string ToString() {
        return $"Area: {area}, Number of rooms: {roomsCount}, Value: {TotalValue()}, and so on.";
    }
}