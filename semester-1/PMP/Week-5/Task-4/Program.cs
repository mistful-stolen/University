namespace Task_4;

class Program
{
    static void Main(string[] args)
    {
        string[] databasePerLine = File.ReadAllLines("./NHANES_1999-2018.csv");

        // What if we split up the the current index: x, y, z, xx, yy, zz
        // Then we sort them into separate arrays
        // But how do we know the length of the arrays?
        // We just simply set the length of the arrays to the number of rows.

        int[] columnSEQN = new int[databasePerLine.Length - 1];
        string[] columnSURVEY = new string[databasePerLine.Length - 1];
        decimal[] columnRIAGENDR = new decimal[databasePerLine.Length - 1];
        decimal[] columnRIDAGEYR = new decimal[databasePerLine.Length - 1];
        decimal[] columnBMXBMI = new decimal[databasePerLine.Length - 1];
        decimal[] columnLBDGLUSI = new decimal[databasePerLine.Length - 1];


        for (int i = 0; i < databasePerLine.Length - 1; i++){
            string[] databasePerElement = databasePerLine[i + 1].Split(",");
            columnSEQN[i] = Convert.ToInt32(databasePerElement[0]);
            columnSURVEY[i] = databasePerElement[1];
            columnRIAGENDR[i] = Convert.ToDecimal(databasePerElement[2]);
            columnRIDAGEYR[i] = Convert.ToDecimal(databasePerElement[3]);
            columnBMXBMI[i] = Convert.ToDecimal(databasePerElement[4]);
            columnLBDGLUSI[i] = Convert.ToDecimal(databasePerElement[5]);

        }

        // In a loop, we collect the body mass index of male or females.
        // If male, we store a countMale++ as well as we add the BMI into our total bodymassindex.

        decimal totalBodyMassIndexMale = 0;
        decimal totalBodyMassIndexFemale = 0;

        int numberOfMales = 0;
        int numberOfFemales = 0;

        for (int i = 0; i < columnBMXBMI.Length; i++) {
            switch (columnRIAGENDR[i]) {
                case 1.0m:
                    totalBodyMassIndexMale += columnBMXBMI[i];
                    numberOfMales++;
                    break;
                case 2.0m:
                    totalBodyMassIndexFemale += columnBMXBMI[i];
                    numberOfFemales++;
                    break;
            }
        }

        decimal averageBMIMale = totalBodyMassIndexMale / numberOfMales;
        decimal averageBMIFemale = totalBodyMassIndexFemale / numberOfFemales;

        // I'll only ever use my own functions. Default functions, blurgh, cough, cough, Microshit~ God, this whole thing feels so reminiscent of the days when I was grinding hard.
        decimal roundedAverageBMIMale = RoundToTwo(averageBMIMale);
        decimal roundedAverageBMIFemale = RoundToTwo(averageBMIFemale);
        Console.WriteLine("1.");
        Console.WriteLine($"Nők átlagos testtömegindexe: {roundedAverageBMIFemale}");
        Console.WriteLine($"Férfiak átlagos testtömegindexe: {roundedAverageBMIMale}");
        

        // 2.

        int numberOfParticipantsWithHighBloodSugarIGuess = 0;
        for (int i = 0; i < columnLBDGLUSI.Length; i++){
            
            if (columnLBDGLUSI[i] > 5.6m) {
                numberOfParticipantsWithHighBloodSugarIGuess++;
            }

        }
        
        
        Console.WriteLine("\n2.");
        Console.WriteLine($"5.6-nál nagyobb vércukrú százaléka: {PercentageCalculator(numberOfParticipantsWithHighBloodSugarIGuess, columnSEQN.Length)}");   

        // We have to search for the greatest BMI. We'll have to run a loop, search for the largest BMI.
        // Once we found the largest BMI, we'll have to search who it belongs to.
        // Once we found our specimen, we'll just simply output their blood sugar level.

        decimal maxBMI = 0;

        foreach (decimal element in columnBMXBMI) {
            if (element > maxBMI) {
                maxBMI = element;
            }
        }

        Console.WriteLine("\n3.");
        for (int i = 0; i < columnBMXBMI.Length; i++) {

            if (columnBMXBMI[i] == maxBMI) {
                Console.WriteLine($"Páciens vércukri :DDDD szintje: {columnLBDGLUSI[i]}");
            }
        }
        

        // 4.

        decimal sumOfAges = 0;
        int countOfOverweightIndividuals = 0;

        for (int i = 0; i < columnRIAGENDR.Length; i++) {
            if (columnBMXBMI[i] >= 30.0m) {
                sumOfAges += columnRIDAGEYR[i];
                countOfOverweightIndividuals++;
            }
        }

        decimal averageAgeOfOverweightIndividuals = RoundToTwo(sumOfAges / countOfOverweightIndividuals);

        Console.WriteLine("\n4.");
        Console.WriteLine($"Túlsúlyos (legalább 30.0-as BMI) személyek átlagos életkora: {averageAgeOfOverweightIndividuals}");

    }

    static decimal RoundToTwo(decimal number){
        string roundedString = $"{(int) number}.{(int) ((number * 10) % 10)}{(int) ((number * 10 * 10) % 10)}";
        return decimal.Parse(roundedString);
    }

    static string PercentageCalculator(int selectNumbers, decimal allNumbers) {
        return $"{(int)((selectNumbers / allNumbers) * 100)}%";
    }
}
