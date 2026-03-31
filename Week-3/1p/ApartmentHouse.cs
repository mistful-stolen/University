class ApartmentHouse
{
    public IRealEstate[] RealEstates { get; private set; }

    int flatCount;
    int garageCount;
    int maxFlatCount;
    int maxGarageCount;

    public ApartmentHouse(int maxFlatCount, int maxGarageCount)
    {
        flatCount = 0;
        garageCount = 0;
        this.maxFlatCount = maxFlatCount;
        this.maxGarageCount = maxGarageCount;

        RealEstates = new IRealEstate[maxFlatCount + maxGarageCount];
    }

    public bool Add(IRealEstate newRealEstate)
    {
        if (newRealEstate is Flat && flatCount < maxFlatCount) 
        { RealEstates[flatCount + garageCount] = newRealEstate; flatCount++; return true; }
        if (newRealEstate is Garage && garageCount < maxGarageCount) 
        { RealEstates[flatCount + garageCount] = newRealEstate; garageCount++; return true; }

        return false;
    }


}