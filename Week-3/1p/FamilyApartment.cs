class FamilyApartment : Flat {
    int childrenCount;

    public FamilyApartment(double area, int rooms, int unitPrice) 
            : base(area, rooms, 0, unitPrice) {
                childrenCount = 0;
        }

    public bool ChildIsborn() {
        int adultsCount = inhabitantsCount - childrenCount;

        if (adultsCount < 2) { return false; }

        inhabitantsCount++;
        childrenCount++;
        return true;
    }

    public override bool MoveIn(int newInhabitants) { 
        int updated = inhabitantsCount + newInhabitants;

        if (updated > roomsCount * 2) { return false; }

        int adultsCount = (inhabitantsCount - childrenCount) + newInhabitants;
        int requiredArea = adultsCount * 10 + childrenCount * 5;
        if (requiredArea > area) { return false; } 

        inhabitantsCount += newInhabitants;
        return true;
    }
    
    public override string ToString()
    {
        return base.ToString() + $", Number of childrens : {childrenCount}"; 
    }


    
}