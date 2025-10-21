namespace Practice;

class Program
{
    static void Main(string[] args)
    {
        decimal x = 1m;

        while (x > 0) {
            Console.WriteLine(x);
            x /= 2;
            
        }

        Console.WriteLine(x);
    }
}
