namespace _3;

partial class Program
{
    static void Main(string[] args)
    {
        Team team1 = new Team();

        Player[] players = RandomPlayers(GameStart());
        DisplayPlayers(players);

        do 
        {
            SelectPlayer(team1, players);
        } while (team1.IsFull() == false);

        team1.DisplayTeam();




        


        


        
        
    }
}
