class GameItem {
    Position position;
    ConsoleSprite sprite;
    ItemType type;
    double fillingRatio;
    bool available = true;

    public Position Position {
        get { return position; }
    }

    public ConsoleSprite Sprite {
        get { return sprite; }
    }

    public ItemType Type {
        get { return type; }
    }

    public double FillingRatio {
        get { return fillingRatio; }
    }

    public bool Available {
        get { return available; }
    }

    private void SetInitialProperties() {
        switch (Type) {
            case ItemType.Ammo:
                sprite = new ConsoleSprite(ConsoleColor.Red, ConsoleColor.Yellow, 'A');
                break;
            case ItemType.BFGCell:
                sprite = new ConsoleSprite(ConsoleColor.Green, ConsoleColor.White, 'B');
                break;
            case ItemType.Door:
                if (fillingRatio == 1.0) {
                    sprite = new ConsoleSprite(ConsoleColor.Gray, ConsoleColor.Yellow, '/');
                }

                if (fillingRatio == 0.0) {
                    sprite = new ConsoleSprite(ConsoleColor.Gray, ConsoleColor.DarkYellow, '/');
                }
                break;
            case ItemType.LevelExit:
                sprite = new ConsoleSprite(ConsoleColor.Blue, ConsoleColor.Black, 'E');
                break;
            case ItemType.Medikit:
                sprite = new ConsoleSprite(ConsoleColor.Gray, ConsoleColor.Red, '+');
                break;
            case ItemType.ToxicWaste:
                sprite = new ConsoleSprite(ConsoleColor.Green, ConsoleColor.White, ':');
                break;
            case ItemType.Wall:
                sprite = new ConsoleSprite(ConsoleColor.Gray, ConsoleColor.Gray, ' ');
                break;
        }
    }

    public GameItem(int x, int y, ItemType typeConst) {
        position = new Position(x, y);
        type = typeConst;

        SetInitialProperties();
    }

    public void Interact() {
        // Ammo, BFGCell, Medikit
        switch (Type) {
            case ItemType.Ammo:
                available = false;
                break; 
            case ItemType.BFGCell:
                available = false;
                break;
            case ItemType.Medikit:
                available = false;
                break; 
        }

        // Door
        switch (Type) {
            case ItemType.Door:
                if (fillingRatio == 1.0) {
                    fillingRatio = 0.0;
                    sprite.Foreground = ConsoleColor.DarkYellow;
                }

                if (fillingRatio == 0.0) {
                    fillingRatio = 1.0;
                    sprite.Foreground = ConsoleColor.Yellow;
                }
                break;
        }
    }

}

enum ItemType {
    Ammo,
    BFGCell,
    Door,
    LevelExit,
    Medikit,
    ToxicWaste,
    Wall
}