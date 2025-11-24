namespace arrnaey;

class Program
{
    static void Main(string[] args)
    {
        int[] array = new int[1] { 0 };
        int[] symLink = array;

        ListElements(array, symLink);

        array[0]++;
        symLink[0]++;

        ListElements(array, symLink);

        symLink[0] = 165;

        ListElements(array, symLink);
    }

    static void ListElements(int[] array, int[] symLink) {
        foreach (int element in array) {
            Console.WriteLine(element);
        }

        Console.WriteLine("----------------");
        foreach (int element in symLink) {
            Console.WriteLine(element);
        }
    }
}
