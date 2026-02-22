internal class Dataset {
    private User[] users;

    public Dataset(string file) {
        string[] lines = File.ReadAllLines(file);
        users = new User[lines.Length - 1];

        for (int i = 0; i < lines.Length - 1; i++) {
            users[i] = new User(lines[i + 1]);
        }
    }

    public int UserBase {
        get { return users.Length; }
    }

    private int AverageMonthlyRevenue(SubscriptionType subType) {
        int totalPrice = 0;
        int totalSubs = 0;

        for (int i = 0; i < users.Length; i++) {
            if (users[i].SubType == subType) {
                totalPrice += users[i].SubscriptionCost;
                totalSubs++;
            }
        }

        return totalPrice / totalSubs;
    }

    private User[] CollectNonPayers(int number) {
        string nonPayers = "";

        for (int i = 0; i < UserBase; i++) {
            if (users[i].DaysSinceLastPayment() > number) {
                nonPayers += $"{i};";
            }
        }

        string[] splitPayers = nonPayers.Split(";");
        User[] nonPayersArray = new User[splitPayers.Length];

        for (int i = 0; i < splitPayers.Length; i++) {
            nonPayersArray[i] = users[int.Parse(splitPayers[i])];
        }

        return nonPayersArray;
    }

    private string MaximalAgeData() {
        int maximum = 0;
        int indexOfUser = 0;

        for (int i = 0; i < users.Length; i++) {
            if (maximum == users[i].UserAge) {
                continue;
            }

            if (maximum < users[i].UserAge) {
                maximum = users[i].UserAge;
                indexOfUser = i;
            }
        }

        return users[indexOfUser].DataAsText();
    }

    public string DistributionOfDeviceType(DeviceType devType) {
        int countryCount = 0;

        foreach (CountryName element in Enum.GetValues(typeof(CountryName))) {
            countryCount++;
        }

        int[] usersPerCountry = new int[countryCount];

        int index = 0;
        int devTypeUsers = 0;
        foreach (CountryName element in Enum.GetValues(typeof(CountryName))) {
            for (int i = 0; i < users.Length; i++) {
                if (users[i].UserDeviceType == devType && users[i].UserCountry == element) {
                    usersPerCountry[index]++;
                    devTypeUsers++;
                }
            }
            index++;
        }

        string text = $"-- Distribution of {devType} --\n";
        index = 0;

        foreach (CountryName element in Enum.GetValues(typeof(CountryName))) {
            text += $"{element}: {((double)usersPerCountry[index] / devTypeUsers) * 100}%\n";
            index++;
        }

        return text;
    }



}