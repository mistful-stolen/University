namespace _2;

class Program
{
    static void Main(string[] args)
    {
        Flight[] flights = new Flight[3] 
        {
            new Flight("LH1337", "Budapest", "15:00"),
            new Flight("W62221", "Tokyo", "9:00", 30),
            new Flight("FR3586", "Bangladesh", "1:00")
        };

        GroundControl gc = new GroundControl();
        gc.AddFlight(array: flights);
   
        gc.DisplayFlightData();        
        flights[2].Cancel();

        gc.DisplayFlightData();

    
    }
}
