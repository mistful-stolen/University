class Buffalo {
    

    int x = 1;
    int y = 1;
    bool active = true;

    public Buffalo() {
        Random rnd = new Random();
        x = rnd.Next(1, 5);
        y = rnd.Next(1, 5);
    }

    public int X {
        get { return x; }
    }

    public int Y {
        get { return y; }
    }

    public bool Active
    {
        get { return active; }
    }

    public void Move(Field instance) {
        Random rnd = new Random();

        switch(rnd.Next(3)) {
            case 0:
                if (instance.AllowedPosition(x + 1, y) == true && active != false) {
                    x += 1;
                }
                break;
            case 1:
                if (instance.AllowedPosition(x, y + 1) == true && active != false) {
                    y += 1;
                }
                break;
            default:
                if (instance.AllowedPosition(x + 1, y + 1) == true && active != false) {
                    x += 1;
                    y += 1;
                }
                break;
        }

    }

    public void Deactivate() {
        active = false;
    }

    public void Show() {
        Console.SetCursorPosition(x, y);
        
        if (active == true) {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("B");
        }

        if (active == false) {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("b");
        }

        Console.ForegroundColor = ConsoleColor.White;
    }




}