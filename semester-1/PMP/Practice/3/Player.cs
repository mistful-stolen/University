class Player 
{
    string name;
    Position pos;

    internal Player(string name, Position pos){
        this.name = name;
        this.pos = pos;
    }

    internal string ToString(){
        return $"{name} {pos}";
    }

}

enum Position
{
    Goalkeeper,
    Forward,
    Winger,
    Defender
}