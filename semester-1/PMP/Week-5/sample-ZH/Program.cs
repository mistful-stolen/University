namespace sample_ZH;

class Program
{
    static void Main(string[] args)
    {
        string genreRaw = File.ReadAllText("./genre.txt");
        string[] genre = genreRaw.Split(",");

        // We set the length of our genreID array.
        string[] genreName = new string[genre.Length];
        string[] genreID = new string[genre.Length];

        // We extract all the IDs.
        for (int i = 0; i < genre.Length; i++) {
            string[] genreSplit = genre[i].Split("=");
            genreName[i] = genreSplit[0];
            genreID[i] = genreSplit[1];
        }

        string[] datasetGamesPerRow = File.ReadAllLines("./games_dataset.csv");

        string[] gameTitle = new string[datasetGamesPerRow.Length - 1];
        string[] gameGenre = new string[datasetGamesPerRow.Length - 1];
        string[] gamePublisher = new string[datasetGamesPerRow.Length - 1];
        string[] gamePlatformReleaseDate = new string[datasetGamesPerRow.Length - 1];
        string[] gameOriginalReleaseDate = new string[datasetGamesPerRow.Length - 1];

        for (int i = 0; i < datasetGamesPerRow.Length - 1; i++) {
            string[] datasetGamesPerElement = datasetGamesPerRow[i + 1].Split(";");

            gameTitle[i] = datasetGamesPerElement[0];
            gamePublisher[i] = datasetGamesPerElement[2];
            gamePlatformReleaseDate[i] = datasetGamesPerElement[3];
            gameOriginalReleaseDate[i] = datasetGamesPerElement[4];

            for (int j = 0; j < genreID.Length; j++) {
                if (datasetGamesPerElement[1] == genreID[j]) {
                    gameGenre[i] = genreName[j];
                }
            }
        }

        // 3.
        Console.WriteLine("\n3.");
        Console.Write("Search game publisher: ");
        string userInput = Console.ReadLine();

        int countOfPublisherGames = 0;

        foreach(string element in gamePublisher) {
            if (element == userInput) {
                countOfPublisherGames++;
            }
        }

        Console.WriteLine($"This publisher \'{userInput}\' has {countOfPublisherGames} published games!");


        // 4.

        Console.WriteLine("\n4.");
        Console.WriteLine("These games were available from release both on their platform from original release:");
        for (int i = 0; i < gameTitle.Length; i++) {
            if (gameOriginalReleaseDate[i] == gamePlatformReleaseDate[i]) {
                Console.WriteLine($"Title: {gameTitle[i]}, Genre: {gameGenre[i]}, Release Date: {gameOriginalReleaseDate[i]}");
            }

        }

        // 5.
        Console.WriteLine("\n5.");
        Console.WriteLine("Number of games per genre:");
        foreach (string element in genreName) {
            int count = 0;
            for (int i = 0; i < gameTitle.Length; i++) {
                if (element == gameGenre[i]) {
                    count++;
                }
            }
            
            Console.WriteLine($"{element}: {count}");
        }

        // Phew~~~ 
        // 80 lines... 
        // I'm pretty certain the code is not as clean as it could be. Sorry.
        
    }
}
