class Team {
    // We need 1 goalkeeper, 2 winger, 1 forwarder, 1 defender
    
    public Player[] players = new Player[5]; // Object, null, null, null, null.
    int numberOfPlayers = 0;

    int countGoalKeeper = 0;
    int countWinger = 0;
    int countForward = 0;
    int countDefender = 0;



    internal bool IsFull() {
        if(numberOfPlayers == 5) {
            return true;
        } else {
            return false;
        }
    }

    internal bool IsIncluded(Player instance) {
        for (int i = 0; i < players.Length; i++){
            if (players[i] != null && players[i].ToString() == instance.ToString()){
                return true;
            }
        }
        return false;
    }

    internal bool IsAvailable(Player instance){
      switch (instance.ToString().Split(" ")[1])
      {
        case "Forward":
            if (countForward == 1)
            {
                return false;
            }
            else {
                return true;
            }
        case "Winger":
            if (countWinger == 2) {
                return false;
            }
            else {
                return true;
            }
        case "Goalkeeper":
            if (countGoalKeeper == 1) {
                return false;
            } else {
                return true;
            }
        case "Defender":
            if (countDefender == 1) {
                return false;
            } else {
                return true;
            }
        default:
            return false;
      }
    }



    internal void Include(Player instance) {
        players[numberOfPlayers] = instance;
        numberOfPlayers++;
    
        switch (instance.ToString().Split(" ")[1])
        {
            case "Forward":
                countForward++;
                break;
            case "Winger":
                countWinger++;
                break;
            case "Defender":
                countDefender++;
                break;
            case "Goalkeeper":
                countGoalKeeper++;
                break;
        }
    }

    internal void DisplayTeam() {
        Console.WriteLine("Your team: ");
        for (int i = 0; i < players.Length; i++) {
            Console.WriteLine(players[i].ToString());
        }
    }
}