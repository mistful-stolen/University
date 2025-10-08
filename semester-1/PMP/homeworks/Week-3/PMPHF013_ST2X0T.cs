using System;

namespace Week_3
{
    class Program 
    {
        static void Main(string[] args)
        {
            // We take in some inputs. Yup.
            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());
            int z = int.Parse(Console.ReadLine());
            
            // We store the integers in an array because we are lazy.
            int[] xyzInt = new int[3] { x, y, z };
            // We create a separate array for absolute values because we are still lazy.
            int[] xyzAbs = new int[3] { x, y, z };

            // We convert negative integers into positive integers.
            for (int i = 0; i < xyzInt.Length; i++){
                if (xyzAbs[i] < 0) {
                    xyzAbs[i] *= -1;
                }
            }
            
            // We find the greatest absolute value because then we can just find the number using a quotient.
            int xyzMaximum = 0;
            for (int i = 0; i < xyzAbs.Length; i++){
                if (xyzMaximum < xyzAbs[i]){
                    xyzMaximum = xyzAbs[i];
                }
            }

            // We'll have to find the greatest number with its quotient. ARGHHHHHHHHHHHHHHHHH. WHY AM I NOT ALLOWED TO USE A BREAK STAETMETNT NAEWRSTNE Ne

            
            int xyzIndex = xyzInt.Length;
            if (xyzMaximum == 0){
                Console.WriteLine(0);
            } else {
                for (int i = 0; i < xyzAbs.Length; i++){
                    if (xyzInt[i] / xyzMaximum == 1){
                        xyzIndex = i;
                    } else if (xyzInt[i] / xyzMaximum == -1 && xyzIndex == xyzInt.Length){
                        xyzIndex = i;
                    }
                }

                Console.WriteLine(xyzInt[xyzIndex]);
            }

            
            
            
          
        }
    }
}


