class Animal {
    string name;
    bool isMale;
    int weight;
    Species species;

    public Animal(string name, bool isMale, int weight, Species species) {
        this.name = name;
        this.isMale = isMale;
        this.weight = weight;
        this.species = species;
    }

    public string Name {
        get { return name; }
    }

    public bool IsMale {
        get { return isMale; }
    }

    public int Weight {
        get { return weight; }
    }

    public Species Species {
        get { return species; }
    }

    public override string ToString() {
        return $"{name}, {(isMale ? "hím" : "nőstény")}, {weight}kg, {TranslateSpecies(species)}";
    }

    string TranslateSpecies(Species species) {
        switch(species) {
            case Species.Dog: return "Kutús";
            case Species.Rabbit: return "Nyuús";
            case Species.Panda: return "Panta";
            default: return "Anád";
        }
    }

}

enum Species {
    Dog,
    Panda,
    Rabbit
}