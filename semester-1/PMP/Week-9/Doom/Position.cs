class Position {
    int x = 0;
    int y = 0;

    public int X {
        get { return x; }
        set { x = value; }
    }

    public int Y {
        get { return y; }
        set { y = value; }
    }

    public Position(int x, int y) {
        this.x = x;
        this.y = y;
    }

    public static Position Add(Position p_1, Position p_2) {
        return new Position(p_1.X + p_2.X, p_1.Y + p_2.Y);
    }

    public static float Distance(Position p_1, Position p_2) {
        return (float) Math.Sqrt(Math.Pow(p_1.X - p_2.X, 2) + Math.Pow(p_1.Y - p_2.Y, 2));
    }


}