using System;

namespace Week_11
{    
    class Program
    {
        static void Main(string[] args)
        {
            // https://main.elearning.uni-obuda.hu/pluginfile.php/633579/mod_assign/introattachment/0/PMPHF014.pdf?forcedownload=1
            
            string[] file = File.ReadAllLines("input.txt");
            string length = file[0];

            string[] lines = new string[file.Length - 1];

            for (int i = 0; i < lines.Length; i++) {
                lines[i] = file[i + 1];
            }

            string calculation = "";




            if (length == "2") 
            {
                File.WriteAllText("output.txt", "1");
            } 
            else 
            {
                int layer = 0;
                int[] depth = new int[lines.Length];
                for (int i = 0; i < lines.Length; i++) 
                {
                    if (lines[i] == "if" && lines[i - 1] == "if" || lines[i] == "if" && lines[i - 1] == "else") {
                        layer++;
                    }

                    if ((lines[i] == "else" || lines[i] == "endif") && lines[i - 1] == "endif") {
                        layer--;                    
                    }

                    depth[i] = layer;

                    if (lines[i] == "begin" || lines[i] == "end") {
                        depth[i] = 8;
                    }
                }

                int[] values = new int[lines.Length];
                for (int i = 0; i < lines.Length; i++) {
                    
                    if (lines[i] == "if" && lines[i + 1] != "if") {
                        values[i] = 1;
                    }

                    if (lines[i] == "else" && lines[i + 1] != "if") {
                        values[i] = 1;
                    }

                    if (lines[i] == "endif"){
                        values[i] = 3;
                    }

                    if (lines[i] == "begin" || lines[i] == "end"){
                        values[i] = 8;
                    }
                }

                int maximumDepth = 0;

                for (int i = 0; i < lines.Length; i++) {
                    if (maximumDepth < depth[i]) {
                        maximumDepth = depth[i];
                    }
                }

                
                

                foreach (int element in depth) {
                    Console.Write(element);
                }

                Console.WriteLine();
                
                foreach(int element in values) {
                    Console.Write(element);
                }
                Console.WriteLine();
                
                Console.WriteLine(calculation);
            }
        }
    }
}
