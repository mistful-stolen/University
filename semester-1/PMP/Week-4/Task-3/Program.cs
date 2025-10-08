Console.Write("Rendszám: ");
string input = Console.ReadLine();

// 1.
string standard1 = input.ToLower();

standard1 = standard1.Replace(" ", "");
standard1 = standard1.Replace("-", " ");

Console.WriteLine("Standard" + standard1);


