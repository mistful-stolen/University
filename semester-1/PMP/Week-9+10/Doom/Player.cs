class Player {
    Position position;
    ConsoleSprite sprite;

    public Position Position 
    {
        get { return position; }
        set { position = value; }
    }

    public ConsoleSprite Sprite 
    {
        get { return sprite; }
    }

    public Player(int x, int y) {
        position = new Position(x, y);
        sprite = new ConsoleSprite(ConsoleColor.Black, ConsoleColor.Green, '0');
    }
}