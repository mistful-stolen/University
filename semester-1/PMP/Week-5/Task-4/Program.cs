namespace Task_4;

class Program
{
    static void Main(string[] args)
    {
        string[] databasePerLine = File.ReadAllLines("/home/mistie/University/semester-1/Week-5/Task-4/NHANES_1999-2018.csv");
        string[] databasePerElement = databasePerLine.Split(",");
        string[] databasePerElementOneRow = databasePerLine[0].Split(",");

        foreach(string element in databasePerElementOneRow) {
            Console.WriteLine(element);
        }
        
        
    }
}
