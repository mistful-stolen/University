namespace _2;

class Program
{
    static void Main(string[] args)
    {
        FleetHandler fleet = new FleetHandler("weyland-yutani.csv");

        fleet.GenerateReport();
    }
}
