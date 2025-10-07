namespace Task_2;

class Program
{
    static void Main(string[] args)
    {
        DateTime currentDate = DateTime.Today;
        

        int iteration = 0;
        string inquiry = "n";
        string textToBeAppended = "";
        do {
            Console.Write($"On {currentDate.ToString("yyyy.MM.dd")}. numbers were: ");
            textToBeAppended = textToBeAppended + $"On {currentDate.ToString("yyyy.MM.dd")}. numbers were: ";
            int[] pickedNumbers = LotteryAlgorithm();
            foreach (int element in pickedNumbers){
                Console.Write(element + " ");
                textToBeAppended = textToBeAppended + element + " ";

            }
            textToBeAppended = textToBeAppended + "; ";

            // 4. feladat hasonló a ZH-hoz
            Console.WriteLine();
            Console.Write("Another week? [y/n]: ");
            inquiry = Console.ReadLine().ToLower();
            
            currentDate = currentDate.AddDays(7);

            


        } while (inquiry == "y");

        Console.WriteLine(textToBeAppended);

        string[] textToBeAppendedSplit = textToBeAppended.Split("; ");
        File.AppendAllLines("lottery", textToBeAppendedSplit);

        

        

    }
    static int[] LotteryAlgorithm(){
        Random random = new Random();
    
        int[] lotteryNumbers = new int[90];

    
        for (int i = 0; i != lotteryNumbers.Length; ++i){
            lotteryNumbers[i] = i + 1;
        }

        // We pick a number from 1 to 90 five times.
        // We store what we pick. We remove what we pick.
        // If what we pick next is 0, then it must mean it's already been picked, so we must pick once anew.

        int[] pickedLotteryNumbers = new int[5];

        for (int i = 0; i != 5; i++){
            int lotteryNumberPickedIndex = random.Next(0, 90);

            if (lotteryNumbers[lotteryNumberPickedIndex] == 0) {
                Console.WriteLine("This number has already been picked!");
                continue;
            }

        pickedLotteryNumbers[i] = lotteryNumbers[lotteryNumberPickedIndex];
        lotteryNumbers[lotteryNumberPickedIndex] = 0;
        }

        return pickedLotteryNumbers;




    }
}
