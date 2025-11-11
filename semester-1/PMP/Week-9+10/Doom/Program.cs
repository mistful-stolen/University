namespace Doom;

class Program
{
    static void Main(string[] args)
    {
        GameItem[] items = new GameItem[6] { 
            new GameItem(2, 3, ItemType.Ammo),
            new GameItem(5, 8, ItemType.Door),
            new GameItem(1, 9, ItemType.Wall),
            new GameItem(5, 4, ItemType.Medikit),
            null,
            null
         };
        

        Game newGame = new Game(items);


        newGame.Run();
        
    }
}
