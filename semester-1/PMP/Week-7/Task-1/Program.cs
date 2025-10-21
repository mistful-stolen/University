namespace Task_1;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("You have nothing here yet.");
    }

    static class Messages {
        public static void Hello(){
            Console.WriteLine("Hello.");
        }

        public static string HelloName(string name) {
            return $"Hello, {name}.";
        }
    }

    static class Operations {
        public static int SumInt(params int[] a){
            int sum = 0;
            foreach (int element in a) {
                sum += element;
            }

            return sum;
        }
    }
}
