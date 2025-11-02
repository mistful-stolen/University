class Flight 
{
    DateTime now = DateTime.Now;
    Random rnd = new Random();

    private string flightNumber;
    private string destination;
    private string departure;
    private int late;
    private Status status;

    internal string FlightNumber
    {
        get { return flightNumber; }
    }

    internal string Destination
    {
        get { return destination; }
    }

    internal string Departure
    {
        get { return departure; }
    }

    internal int Late
    {
        get { return late; }
    }

    internal Status Status
    {
        get { return status; }
    }

    internal Flight(string flightNumber, string destination, string departure, int late) {
        this.flightNumber = flightNumber;
        this.destination = destination;
        this.departure = departure;
        this.late = late;
    }

    internal Flight(string flightNumber, string destination, string departure) {
        this.flightNumber = flightNumber;
        this.destination = destination;
        this.departure = departure;
        this.late = 0;
    }

    public void Delay(int delay) {
        late = delay;
    }

    public void Cancel() {
        status = Status.Canceled;
    }

    private void UpdateStatus(Status newStatus) {
        switch(newStatus) 
        {
            case Status.Scheduled:
                status = Status.Scheduled;
                break;
            case Status.Delayed:
                status = Status.Delayed;
                break;
            case Status.Canceled:
                status = Status.Canceled;
                break;
        }
    }

    private void UpdateStatus() {
        if (late == 0 && status != Status.Canceled) {
            status = Status.Scheduled;
        } else if (late > 0 && status != Status.Canceled) {
            status = Status.Delayed;
        }
    }

    string EstimatedDeparture(){
        DateTime parsedDate = DateTime.Parse(departure);
        parsedDate = parsedDate.AddMinutes(late);

        return parsedDate.ToString("yyyy. MM. dd. HH:mm:ss");
    }

    internal string AllData
    {
        get 
        {   
            UpdateStatus();
            UpdateStatus(status);
            switch(status)
            {
                case Status.Scheduled:
                    return $"Flight {flightNumber} is on time. (STD {EstimatedDeparture()})";
                case Status.Delayed:
                    return $"Flight {flightNumber} is delayed by {late} minutes. (ETD {EstimatedDeparture()})";
                case Status.Canceled:
                    return $"Flight {flightNumber} is canceled.";
                default:
                    return $"Something went wrong!";
            }
        }
    }

}

enum Status
{
    Scheduled,
    Delayed,
    Canceled
}