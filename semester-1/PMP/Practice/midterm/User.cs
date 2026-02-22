internal class User {
    private int userID;
    private SubscriptionType subType;
    private int subscriptionCost;
    private DateTime userJoinDate;
    private DateTime userLastPaid;
    private CountryName userCountry;
    private int userAge;
    private DeviceType userDeviceType;

    public int UserID {
        get { return userID; }
    }

    public SubscriptionType SubType {
        get { return subType; }
    }

    public int SubscriptionCost {
        get { return subscriptionCost; }
    }

    public DateTime UserJoinDate {
        get { return userJoinDate; }
    }

    public DateTime UserLastPaid {
        get { return userLastPaid; }
    }

    public CountryName UserCountry {
        get { return userCountry; }
    }

    public int UserAge {
        get { return userAge; }
    }

    public DeviceType UserDeviceType {
        get { return userDeviceType; }
    }

    public User(string text) {
        string[] splitText = text.Split(",");

        userID = int.Parse(splitText[0]);
        subType = (SubscriptionType)Enum.Parse(typeof(SubscriptionType), splitText[1]);
        subscriptionCost = int.Parse(splitText[2]);
        userJoinDate = DateTime.Parse(splitText[3]);
        userLastPaid = DateTime.Parse(splitText[4]);
        userCountry = (CountryName)Enum.Parse(typeof(CountryName), splitText[5]);
        userAge = int.Parse(splitText[6]);
        userDeviceType = (DeviceType)Enum.Parse(typeof(DeviceType), splitText[7]);
    }

    public int SubscriptionInDays() {
        return (DateTime.Today - userJoinDate).Days;
    }

    public int DaysSinceLastPayment() {
        return (DateTime.Today - userLastPaid).Days;
    }

    public string DataAsText() {
        return $"User ID: {userID} ({userCountry}, {subType}, {userDeviceType}). Subscription: {SubscriptionInDays()} days, last payment: {DaysSinceLastPayment()} days.";
    }





}

internal enum CountryName {
    Australia=1,
    Brazil=2,
    Canada=3,
    France=4, 
    Germany=5, 
    Italy=6, 
    Mexico=7,
    Spain=8, 
    UnitedKingdom=9, 
    UnitedStates=10
}

internal enum SubscriptionType {
    Basic,
    Premium,
    Standard
}

internal enum DeviceType {
    Laptop, 
    SmartTV, 
    Smartphone, 
    Tablet
}