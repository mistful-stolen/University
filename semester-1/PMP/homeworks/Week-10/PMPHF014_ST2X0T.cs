using System;
using System.Numerics;

namespace Week_10 
{
    class Program
    {
        static void Main(string[] args)
        {
            // https://main.elearning.uni-obuda.hu/pluginfile.php/633579/mod_assign/introattachment/0/PMPHF014.pdf?forcedownload=1
            
            string path = "input.txt";
            string[] text = File.ReadAllLines(path);

            string calculation = "";
            if (text[0] == "2") 
            {
                string defaultValue = "1";
                File.WriteAllText("output.txt", defaultValue);
            } 
            else 
            {
                string[] lines = new string[text.Length - 3];
                for (int i = 0; i < text.Length - 3; i++) 
                {
                    lines[i] = text[i + 2];
                }
                
                int index = 0;
                for (int i = 0; i < lines.Length; i++) 
                {
                    
                    switch (lines[i]) 
                    {
                        case "if":
                            if (lines[i + 1] == "else" && lines[i + 2] == "endif") {
                                calculation += "2";
                            } else if (lines[i + 1] == "else") {
                                calculation += "1";
                            } else if (lines[i] == "else" && lines[i + 1] == "endif") {
                                calculation += "1";
                            }


                            break;
                        case "else":
                            if (lines[i + 1] == "if") {
                                calculation += "+";
                            }

                            if (lines[i - 1] == "endif" && lines[i + 1] == "endif") {
                                calculation += "+";
                            }
                            break;

                        case "endif":
                            if (i != lines.Length - 1 && lines[i + 1] == "if") {
                                calculation += "*";
                            }
                            break;
                    }



                }
            
            Console.WriteLine(calculation);
            /*
            string[] splitCalculation = calculation.Split(" + ");

        
            
            for (int i = 0; i < splitCalculation.Length; i++) {
                BigInteger finalValue;
                if (splitCalculation[i].Length != 1) {
                    finalValue = 2;
                    for (int j = 0; j < splitCalculation[i].Length; j++) {
                        if (splitCalculation[i][j] == '*') {
                            finalValue *= 2;
                        }
                    }
                } else {
                    finalValue = BigInteger.Parse(splitCalculation[i]);
                }
                splitCalculation[i] = finalValue.ToString();
            }
            
            
            BigInteger output = 0;
            foreach(string element in splitCalculation) {
                output += BigInteger.Parse(element);
            }

            File.WriteAllText("output.txt", output.ToString());
            */
            }
        }
    }
}