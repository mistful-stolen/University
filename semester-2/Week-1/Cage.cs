class Cage {
    int maxSize = 10;
    Animal[] animals;
    int count = 0;
    
    public Cage(int size) {

        animals = new Animal[size <= 10 ? size : maxSize]; // ternary operator
        /*
        if (size <= 10) {
            this.animals = new Animal[size];
        }
        else {
            this.animals = new Animal[maxSize];
        }
        */
    }

    public bool Add(Animal newAnimal) {
        if (count == animals.Length) return false; // early exit;

        animals[count] = newAnimal;
        count++;
        return true;
    }

    public void Delete(string name) {
        int idx = -1;
        for (int i = 0; i < count; i++) {
            if (idx == -1 && animals[i].Name == name) {
                idx = i;
            }
        }

        if (idx != -1) {
            for (int i = idx; i < count - 1; i++) {
                animals[i] = animals[i + 1];
            }

            animals[count] = null;
            count--;
        }
    }

    public int CountSpecies(Species species) {
        int iterator = 0;
        for (int i = 0; i < count; i++) {
            if (animals[i].Species == species) {
                iterator++;
            }
        }

        return iterator;
    }

    public bool doesExistSpeciesAndGender(Species species, bool gender) {
        bool van = false;
        int i = 0;

        while (i <= count - 1 && van == false) {
            if (animals[i].Species == species && animals[i].IsMale == gender) {
                van = true;
            }

            i++;
        }

        return van;
    }

    public Animal[] CollectAll(Species species) {
        Animal[] result = new Animal[count];

        int resultCount = 0;

        for (int i = 0; i < count; i++) {
            if (animals[i].Species == species) {
                result[resultCount] = animals[i];
                resultCount++;
            }
        }


        return result;
    }

    public int AverageWeight(Species species) {
        Animal[] speciesAnimals = CollectAll(species);
        int sum = 0;
        int total = 0;

        for (int i = 0; i < speciesAnimals.Length; i++) {
            if (speciesAnimals[i] != null) {
                sum += speciesAnimals[i].Weight;
                total++;
            }
        }

        return sum / total;
    }

    public bool SameSpeciesDifferentGenders(Species species) {
        Animal[] speciesAnimals = CollectAll(species);

        bool isMale = false;
        bool isFemale = false;

        for (int i = 0; i < speciesAnimals.Length; i++) {
            if (speciesAnimals[i] != null) {
                if(speciesAnimals[i].IsMale == true) {
                    isMale = true;
                }

                if(speciesAnimals[i].IsMale == false) {
                    isFemale = true;
                }
            }
        }

        if (isMale == true && isFemale == true) {
            return true;
        }

        return false;
    }

    public static int MostSpecifiedSpecies(Cage[] cage, Species species) {
        int idx = -1;
        int max = 0;
        for (int i = 0; i < cage.Length; i++) {
            int number = 0;
            for (int j = 0; j < cage[i].animals.Length; j++) {
                if (cage[i].animals[j].Species == species) {
                    number++;
                }
            }

            if (number > max) {
                idx = i;
            }
        }

        return idx;
    }

    public string ListAnimals() {
        string message = "";

        for (int i = 0; i < count; i++) {
            message += animals[i].ToString() + "\n";
        }

        return message;
    } 
}