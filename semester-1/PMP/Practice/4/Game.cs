class Game {
    Field field;
    Buffalo[] buffalo;

    public Game(int size, int buffaloQuantity) {
        field = new Field(size);
        buffalo = new Buffalo[buffaloQuantity];
        for (int i = 0; i < buffalo.Length; i++) {
            buffalo[i] = new Buffalo();
        }
    }

    bool IsOver
    {
        get 
        {
            for (int i = 0; i < buffalo.Length; i++) {
                if (buffalo[i].X == field.TargetX && buffalo[i].Y == field.TargetY){
                    return true;
                }
            }
            return false;
        }
    }

    void VisualizeElements(){
        Console.Clear();
        field.Show();
        
        for (int i = 0; i < buffalo.Length; i++) {
            buffalo[i].Show();
        }
    }

    void Shoot(int x, int y) {
        for (int i = 0; i < buffalo.Length; i++) {
            if (x == buffalo[i].X && y == buffalo[i].Y) {
                buffalo[i].Deactivate();
            }
        }
    }

    public void Run() {
        int countCancel = 0;
        do
        {
            VisualizeElements();

            Console.SetCursorPosition(0, 0);
            Console.Write("Shoot [x]: ");
            int x = int.Parse(Console.ReadLine());

            VisualizeElements();
            Console.SetCursorPosition(0, 0);
            Console.Write("Shoot [y]: ");
            int y = int.Parse(Console.ReadLine());

            
            Shoot(x, y);

            for (int i = 0; i < buffalo.Length; i++) {
                buffalo[i].Move(field);

                if (buffalo[i].Active == false) {
                    countCancel++;
                }
            }
            
            if (countCancel == buffalo.Length) {
                break;
            }

        } while (IsOver != true);
        
        if (IsOver == true) {
            VisualizeElements();
            Console.WriteLine("Game Over! Buffalos win!");
            
        } else {
            VisualizeElements();
            Console.WriteLine("You Win!");
        }
        
    }



  


}