class Game {
    Player player;
    bool exited = false;
    GameItem[] gameItem;

    public Player Player {
        get { return player; }
    }

    public bool Exited {
        get { return exited; }
        set { exited = value; }
    }

    public GameItem[] Items {
        get { return gameItem; }
    }

    public Game(GameItem[] item) {
        player = new Player(0, 0);
        gameItem = new GameItem[item.Length];

        for (int i = 0; i < gameItem.Length; i++) {
            gameItem[i] = item[i];
        }

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

        for (int i = 0; i < Items.Length; i++) {
            if (Items[i] != null) {
                RenderSingleSprite(Items[i].Position, Items[i].Sprite);
            }
        }


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
                case ConsoleKey.D:
                    for (int i = 0; i < Items.Length; i++) {
                        if (Items[i] != null) {
                            Items[i].Interact();
                        }
                    }
                    break;
                    


            }
        }

    }

    private void CleanUpGameItems() {
        for (int i = 0; i < Items.Length; i++) {
            GameItem[] 
            if (Items[i] != null && Items[i].Available == false
        }
    }


    public void Run() {
        do
        {
            RenderGame();
            UserAction();
            CleanUpGameItems();
            Thread.Sleep(25);
        } while (Exited == false);
    }







}