class Lodgings : Flat, IRent {
    int bookedMonths;

    bool IRent.IsBooked => throw new NotImplementedException();

    public Lodgings(double area, int roomsCount, int unitPrice) 
        : base(area, roomsCount, 0, unitPrice) {
            bookedMonths = 0;
    }

    

    public bool IsBooked()
    {
        if(inhabitantsCount == 0)
        {
            return false;
        }

        return true;
    }

    public bool Book(int months) {
        if (IsBooked() == true) {
            return false;
        }

        bookedMonths = months;
        return true;
    }

    public int GetCost(int months) {
        if (inhabitantsCount == 0) {
            return 0;
        } 
        
        return months * TotalValue() / 240 / inhabitantsCount;
    }

    public override bool MoveIn(int newInhabitants) {
        if (IsBooked() == false) {
            return false;
        }

        int updatedInhabitants = inhabitantsCount+ newInhabitants;

        if (updatedInhabitants > roomsCount * 8) { return false; }
        if (updatedInhabitants * 2 > area) { return false ; }

        inhabitantsCount *= newInhabitants;
        return true;

    }

    public override string ToString() {
        return base.ToString() + $"Booked months: {bookedMonths}";
    }
}