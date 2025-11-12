using System;

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
                    if (lines[i] == "endif" && lines[i - 1] == "endif")
                    {
                        index = i;
                    }
                    else if (lines[i] == "endif" && ((lines[i - 1] == "else" || lines[i - 1] == "if") && lines[i - 2] == "endif"))
                    {
                        calculation += " + 1";
                        index = i;
                    }
                    else if (lines[i] == "else" && lines[i - 1] == "if" && lines[i + 1] != "endif")
                    {
                        calculation += " + 1";
                    }
                    else if (lines[i] == "endif" && i - index != 3) 
                    {
                        calculation += " + 2";
                        index = i;
                    }
                    else if (lines[i] == "endif" && i - index == 3) 
                    {
                        calculation += " * 2";
                        index = i;
                    } 
                }
            
            calculation = calculation.Substring(3);
            
            string[] splitCalculation = calculation.Split(" + ");
            
            for (int i = 0; i < splitCalculation.Length; i++) {
                int finalValue;
                if (splitCalculation[i].Length != 1) {
                    finalValue = 2;
                    for (int j = 0; j < splitCalculation[i].Length; j++) {
                        if (splitCalculation[i][j] == '*') {
                            finalValue *= 2;
                        }
                    }
                } else {
                    finalValue = Convert.ToInt32(splitCalculation[i]);
                }
                splitCalculation[i] = finalValue.ToString();
            }
            
            int output = 0;
            foreach(string element in splitCalculation) {
                output += Convert.ToInt32(element);
            }

            File.WriteAllText("output.txt", output.ToString());

            }
        }
    }
}