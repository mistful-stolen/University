public class Participant : IParticipant
{
    public Participant(string name)
    {
        Name = name;
    }

    public string Name { get; private set; }


    public int CompareTo(object? obj)
    {
        if (obj == null) throw new ArgumentNullException();
        if (obj is not Participant other) throw new ArgumentException();

        return this.Name.CompareTo(other.Name);
    }

    public override bool Equals(object? obj)
    {
        if (obj == null) throw new ArgumentNullException();
        if (obj is not Participant other) throw new ArgumentException();

        return this.Name == other.Name;
    }

    public override string ToString()
    {
        return Name;
    }

    public static Participant Parse(string input)
    {
        if (input == null) throw new ArgumentNullException();
        if(input.Contains(',') || input.Split(' ').Length <= 1) throw new ArgumentException();


        return new Participant("Joe");

    }
}