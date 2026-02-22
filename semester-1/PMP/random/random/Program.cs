namespace random;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = new int[5] { 1, 2, 3, 4, 5 };
        doSomething(numbers);

        foreach(int element in numbers) {
            Console.WriteLine(element);
        }
    }

    static int doSomething(int[] array) {
        int counter = -1;
        for (int i = 0; i < array.Length; i++) {
            if (array[i] % 2 == 0) {
                counter++;
                array[counter] = array[i];
            }
        }
        return counter;
    }
}
