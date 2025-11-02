class GroundControl 
{
    Flight[] flights;

    public void AddFlight(Flight[] array){
        flights = new Flight[array.Length];
        for (int i = 0; i < array.Length; i++) {
            flights[i] = array[i];
        }
    }

    internal Flight[] Flights
    {
        get { return flights; }
    }

    string AverageDelay() {
        int totalDelay = 0;
        int count = 0;

        foreach (Flight element in flights) {
            if (element.Status == Status.Canceled) {
                continue;
            }

            totalDelay += element.Late;
            count++;
        }
        
        return $"Average delay is {totalDelay / count} minutes.";
    }

    public void DisplayFlightData(){
        foreach(Flight element in flights) {
            Console.WriteLine(element.AllData);
        }

        Console.WriteLine(AverageDelay());
    }

    

}