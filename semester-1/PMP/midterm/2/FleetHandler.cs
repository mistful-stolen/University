class FleetHandler {
    SpaceShip[] spaceShips;
    DateTime currentDate;

    public FleetHandler(string filePath) {
        string[] file = File.ReadAllLines(filePath);
        currentDate = DateTime.Parse(file[0]);

        spaceShips = new SpaceShip[file.Length - 1];

        for (int i = 0; i < spaceShips.Length; i++) {
            spaceShips[i] = new SpaceShip(file[i + 1]);
        }
    }

    public int TotalShipCount {
        get { return spaceShips.Length; }
    }

    public bool HasAnyDeceasedCrew {
        get {
            for (int i = 0; i < spaceShips.Length; i++) {
                if (spaceShips[i].CrewStatus == CrewStatusType.Deceased) {
                    return true;
                }
            }
            return false;
        }
    }

    public double AverageCargo(ShipClassType shipClass) {
        double totalCargo = 0;
        int numberOfShips = 0;

        for (int i = 0; i < spaceShips.Length; i++) {
            if (spaceShips[i].ShipType == shipClass) {
                totalCargo += spaceShips[i].ShipLoad;
                numberOfShips++;
            }
        }

        return totalCargo / numberOfShips;
    }

    public SpaceShip[] GetShipsByGroup() {
        // We create an array, with a length of spaceShips
        // We need a number that stores indexes of first rows
        // We start a for loop, then slowly copy over everything, and if we find a maiden in distress, 
        // we just simply replace the first values with the value, this way, most of the non-important ones will be on the right side.
        // If it's either (Cargo or Research) and (NeedsRescue), we put them at the start of the array
        // We move the ones we need on the left while moving the ones we don't need on the right.
        int index = 0;
        SpaceShip[] shipsGrouped = new SpaceShip[spaceShips.Length];
        for (int i = 0; i < spaceShips.Length; i++) {
            if ((spaceShips[i].ShipType == ShipClassType.Cargo) || (spaceShips[i].ShipType == ShipClassType.Research)) {
                if (spaceShips[i].NeedsRescue(currentDate)) {
                    SpaceShip temporary = spaceShips[index];
                    shipsGrouped[index] = spaceShips[i];
                    shipsGrouped[i] = temporary;

                    index++;
                }
            }

            shipsGrouped[i] = spaceShips[i];
        }

        return shipsGrouped;
    }

    public string GetLargestCrewData(CrewStatusType status) {
        int maximum = 0;
        for (int i = 0; i < spaceShips.Length; i++) {
            if (spaceShips[i].CrewStatus == status) {
                if (spaceShips[i].MarineCount > maximum) {
                    maximum = spaceShips[i].MarineCount;
                }
            }
        }

        for (int i = 0; i < spaceShips.Length; i++) {
            if (spaceShips[i].CrewStatus == status) {
                if (spaceShips[i].MarineCount == maximum) {
                    return spaceShips[i].GetStatusReport(currentDate);
                }
            }
        }

        return "";


    }

    public void GenerateReport() {
        Console.WriteLine($"Current date is {currentDate.ToString("yyyy. MM. dd. H:mm:ss")}.");
        Console.WriteLine($"Total ship count is {TotalShipCount}.");

        Console.WriteLine("Average cargo by shiptypes:");
        foreach(ShipClassType element in Enum.GetValues(typeof(ShipClassType))) {
            Console.WriteLine($"    {element}: {AverageCargo(element)}");
        }

        Console.WriteLine("Detailed info sorted by risk:");
        foreach(SpaceShip element in GetShipsByGroup()) {
            Console.WriteLine(element.GetStatusReport(currentDate));
        }
    }


}