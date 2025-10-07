namespace Task_1;

class Program
{
    static void Main(string[] args)
    {
        string[] quoteAsArray = File.ReadAllLines("/home/mistie/University/semester-1/Week-5/Task-1/text");
        string[] splitQuote = new string[quoteAsArray.Length];
        
        for (int i = 0; i < quoteAsArray.Length; i++) {
            string[] splitted = quoteAsArray[i].Split("#");

            switch (splitted[0]) {
                case "Red":
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(splitted[1]);
                    break;
                case "Green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(splitted[1]);
                    break;
                case "Blue":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(splitted[1]);
                    break;
            }
        }

        
    }
}
