class Field 
{
    int grid = 0;

    public Field(int gridElement) {
        grid = gridElement;
    }

    public int TargetX
    {
        get { return grid; }
    }

    public int TargetY
    {
        get { return grid; }
    }

    public bool AllowedPosition(int x, int y)
    {
        if (x < 1 || x > grid) {
            return false;
        }

        if (y < 1 || y > grid) {
            return false;
        }
        return true;
    }

    public void Show() {
        Console.SetCursorPosition(1, 1);
        for (int i = 1; i != grid + 1; i++){
            for (int j = 1 ; j != grid + 1; j++){
                if (i == 1 || i == grid) {
                    Console.Write("\u2014");
                }

                if ((j == 1 || j == grid) && (i != 1 && i != grid)) {
                    Console.Write("|");
                }
                
                if ((j != 1 && j != grid) && (i != 1 && i != grid)) {
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }
    }

}