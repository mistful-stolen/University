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

    private void UserAction() {
        if (Console.KeyAvailable == true) {
            ConsoleKeyInfo pressed = Console.ReadKey(true);

            switch (pressed.Key) {
                case ConsoleKey.Escape:
                    Exited = true;
                    break;
                case ConsoleKey.UpArrow:
                    if (player.Position.Y == 0) {
                        player.Position.Y -= 0;
                    } else {
                        player.Position.Y -= 1;
                    }

                    break;
                case ConsoleKey.DownArrow:
                    player.Position.Y += 1;
                    break;
                case ConsoleKey.LeftArrow:
                    if (player.Position.X == 0) {
                        player.Position.X -= 0;
                    } else {
                        player.Position.X -= 1;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    player.Position.X += 1;
                    break;

            }
        }

    }


    public void Run() {
        do
        {
            RenderGame();
            UserAction();
            Thread.Sleep(25);
        } while (Exited == false);
    }





}