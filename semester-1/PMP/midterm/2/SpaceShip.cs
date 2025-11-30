class SpaceShip {
    string shipName;
    ShipClassType shipType;
    int marineCount;
    CrewStatusType crewStatus;
    int shipLoad;
    DateTime lastMessageDate;

    public string ShipName {
        get { return shipName; }
    }

    public ShipClassType ShipType {
        get { return shipType; } 
    }

    public int MarineCount {
        get { return marineCount; }
    }

    public CrewStatusType CrewStatus {
        get { return crewStatus; }
    }

    public int ShipLoad {
        get { return shipLoad; }
    }

    public DateTime LastMessageDate {
        get { return lastMessageDate; }
    }

    public SpaceShip(string lineHextect) {
        string[] splitHextect = lineHextect.Split(";");

        shipName = splitHextect[0];
        shipType = (ShipClassType)Enum.Parse(typeof(ShipClassType), splitHextect[1]);
        marineCount = int.Parse(splitHextect[2]);
        crewStatus = (CrewStatusType)Enum.Parse(typeof(CrewStatusType), splitHextect[3]);
        shipLoad = int.Parse(splitHextect[4]);
        lastMessageDate = DateTime.Parse(splitHextect[5]);
    }

    public int DaysSinceLastMessage(DateTime date) {
        return (date - lastMessageDate).Days;
    }

    public bool NeedsRescue(DateTime date) {
        switch (crewStatus) {
            case CrewStatusType.MissingInAction:
                return true;
            case CrewStatusType.Deceased:
                return true;
        }

        switch (crewStatus) {
            case CrewStatusType.Active:
                if (DaysSinceLastMessage(date) > 30) {
                    return true;
                }
                break;
            case CrewStatusType.InCryosleep:
                if (DaysSinceLastMessage(date) > 3650) {
                    return true;
                }
                break;
        }


        return false; 
    }
    
    public override string ToString() {
        return $"{shipName} ({shipType})";
    }

    public string GetStatusReport(DateTime date) {
        string needsRescue = (NeedsRescue(date) == true) ? "Yes" : "No";
        
        return @$"=== {ToString()} ===
        Crew: {marineCount} ({crewStatus})
        Last Message: {DaysSinceLastMessage(date)} days
        Rescue Needed: {needsRescue}
        ";
    }

}

enum ShipClassType {
    Cargo,
    Military,
    Research, 
    Mining, 
    Colonial, 
    Rescue
}

enum CrewStatusType {
    Active=1, 
    InCryosleep=2, 
    MissingInAction=3, 
    Deceased=4
}