namespace Week_1;

class Program
{
    static void Main(string[] args)
    {
        Cage[] cages = Init();

        Console.WriteLine(cages[0].CountSpecies(Species.Dog));
        Console.WriteLine(cages[0].doesExistSpeciesAndGender(Species.Dog, true));

        Animal[] animy = cages[0].CollectAll(Species.Dog);

        Console.WriteLine(animy[1].Name);
        Console.WriteLine(cages[0].AverageWeight(Species.Dog));
        Console.WriteLine(cages[0].SameSpeciesDifferentGenders(Species.Dog));
        Console.WriteLine(Cage.MostSpecifiedSpecies(cages, Species.Dog));

        Console.WriteLine(cages[0].ListAnimals());
    }

    static Cage[] Init() {
        Cage[] cages = new Cage[4] {
            new Cage(4),
            new Cage(2),
            new Cage(2),
            new Cage(2),
        };

        cages[0].Add(new Animal("Buksi", true, 500, Species.Dog));
        cages[0].Add(new Animal("Lepárd", true, 465, Species.Rabbit));
        cages[0].Add(new Animal("Jóska", true, 555, Species.Panda));
        cages[0].Add(new Animal("Anyád", false, 500, Species.Dog));

        cages[1].Add(new Animal("Lepárd", true, 465, Species.Rabbit));
        cages[1].Add(new Animal("Jóska", true, 555, Species.Panda));

        cages[2].Add(new Animal("Lepárd", true, 465, Species.Rabbit));
        cages[2].Add(new Animal("Jóska", true, 555, Species.Panda));

        cages[3].Add(new Animal("Lepárd", true, 465, Species.Rabbit));
        cages[3].Add(new Animal("Jóska", true, 555, Species.Panda));

        return cages;

    }
}
