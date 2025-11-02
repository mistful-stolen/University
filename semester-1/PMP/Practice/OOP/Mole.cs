class Mole {
    

    int molePosition = 0;
    int grid = 1;

    internal int MolePosition
    {
        get { return molePosition; }
    }

    internal void TurnUp() {
        for (int i = 1; i <= grid; i++) {
            
            if (i == molePosition) {
                Console.Write(" M ");
            } else {
                Console.Write($" {i} ");
            }
            if (i % 3 == 0) {
                Console.WriteLine();
            }
        }
    }



    internal void Hide(int number1, int number2) {
        Random random = new Random();


        molePosition = random.Next(number1, number2 + 1);
        grid = number2;
    }
}