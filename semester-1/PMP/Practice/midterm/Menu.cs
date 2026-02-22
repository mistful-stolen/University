internal class Menu {
    Dataset data;

    private void Options() {
        Console.WriteLine("1. Load data file");
        Console.WriteLine("2. Get average monthly revenue");
        Console.WriteLine("3. Get average monthly revenue");
        Console.WriteLine("4. Show distribution of devices");
        Console.WriteLine("5. Exit");
    }

    private int Choice();

    public void Run(){
        Options();
    }
}