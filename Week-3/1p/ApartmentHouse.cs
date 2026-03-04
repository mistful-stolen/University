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
}