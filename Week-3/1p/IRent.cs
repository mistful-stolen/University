interface IRent {
    int GetCost(int months);
    bool IsBooked { get; }
    bool Book(int months);

}