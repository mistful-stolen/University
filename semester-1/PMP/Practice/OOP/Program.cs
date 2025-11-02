namespace OOP;

class Program
{
    static void Main()
    {       
        Mole game1 = new Mole();
        bool win = false;

        do 
        {
            Console.Write("Start (set/ no = 0): ");
            int set = int.Parse(Console.ReadLine());
            game1.Hide(1, set);


            Console.Write("Guess: ");
            int guess = int.Parse(Console.ReadLine());

            if(guess == game1.MolePosition) {
                game1.TurnUp();
                Console.WriteLine("Your guess is correct!");
                Console.WriteLine($"Mole's position was: {game1.MolePosition}");
                win = true;
            } else {
                game1.TurnUp();
                Console.WriteLine("You missed!");
            }
        } while (win != true);
        
    }
}