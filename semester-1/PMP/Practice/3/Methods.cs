namespace _3;

partial class Program {
    static Player[] RandomPlayers(int quantity) {
        Random rnd = new Random();
        Player[] players = new Player[quantity];

        string[] names = new string[10]
            {
                "Liam",
                "Leonard",
                "Xeon",
                "Pixie",
                "Zeno",
                "David",
                "Adam",
                "Author",
                "Zach",
                "Peter"
            };
        
        Position[] position = new Position[4]
        {
            Position.Goalkeeper,
            Position.Forward,
            Position.Winger,
            Position.Defender
        };
        
        for (int i = 0; i < quantity; i++) {
            players[i] = new Player(names[rnd.Next(names.Length)], position[rnd.Next(position.Length)]);
        }

        return players;
    }

    static int GameStart() {
        Console.Write("Number of players to generate: ");
        int userInput = int.Parse(Console.ReadLine());

        return userInput;
    }

    static void DisplayPlayers(Player[] instance) {
        for (int i = 0; i < instance.Length; i++) {
            Console.WriteLine($"{i + 1}. {instance[i].ToString()}");
        }
    }

    static void SelectPlayer(Team team, Player[] player) {
        Console.Write("Select player: ");
        int playerSelection = int.Parse(Console.ReadLine());
        switch (team.IsIncluded(player[playerSelection - 1])) {
            case true:
                Console.WriteLine("Already included! Please, select another one!");
                break;
            case false:
                switch (team.IsAvailable(player[playerSelection - 1])){
                    case false:
                        Console.WriteLine("Position already taken! Please, pick a different player!");
                        break;
                    case true:
                        Console.WriteLine("Player added!");
                        team.Include(player[playerSelection - 1]);
                        break;
                }
                break;
        }
    }
}