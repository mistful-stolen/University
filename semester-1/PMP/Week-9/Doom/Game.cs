class Game {
    Player player;
    bool exited = false;

    public Player Player {
        get { return player; }
    }

    public bool Exited {
        get { return exited; }
        set { exited = value; }
    }

    public Game() {
        player = new Player(0, 0);
    }

    private void RenderSingleSprite(Position position, ConsoleSprite sprite) {
        if (position.X < Console.WindowWidth && position.Y < Console.WindowHeight) {
            Console.SetCursorPosition(position.X, position.Y);
            Console.ForegroundColor = sprite.Foreground;
            Console.BackgroundColor = sprite.Background;
            Console.Write(sprite.Glyph);
        }
    }

    private void RenderGame() {
        Console.CursorVisible = false;
        Console.ResetColor();
        Console.Clear();
        RenderSingleSprite(player.Position, player.Sprite);
    }





}