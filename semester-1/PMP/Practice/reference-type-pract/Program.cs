namespace reference_type_pract;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = new int[3] { 1, 2, 3 };
        int[] symLink = numbers;

        symLink[0] = 5;

        foreach (int element in numbers) {
            Console.Write(element + ", ");
        }
        
        Console.WriteLine();
        foreach (int element in symLink) {
            Console.Write(element + ", ");
        }

        numbers = new int[3];

        foreach (int element in )
        
    }
}
