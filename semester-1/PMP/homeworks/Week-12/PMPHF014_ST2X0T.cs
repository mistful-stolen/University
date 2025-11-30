using System;

namespace Week_12 
{
    class Program
    {
        static void Main(string[] args)
        {

            // Most ölöm meg magam.
            string[] file = File.ReadAllLines("input.txt");
            int length = int.Parse(file[0]);

            if (length == 2) {
                File.WriteAllText("output.txt", "1");
                return;
            }

            string[] lines = ExtractLines(file);
            
            int[] index = new int[1] { 0 };
            long output = LeafBrancher(lines, index);

            File.WriteAllText("output.txt", output.ToString());
        }

        static long LeafBrancher(string[] lines, int[] index) {
            long leafs = 1;
            int[] refIndex = index;

            while (refIndex[0] < lines.Length) {
                string line = lines[refIndex[0]];

                if (line == "endif" || line == "else") {
                    return leafs;
                }

                if (line == "if") {

                    refIndex[0]++;
                    long ifBranch = LeafBrancher(lines, index);

                    refIndex[0]++;
                    long elseBranch = LeafBrancher(lines, index);

                    refIndex[0]++;

                    leafs *= (ifBranch + elseBranch);
                }

            }
            return leafs; // NOT ALL CODE PATHS RETURN A VALUE arnestoarstneioarstniioarstnertgnrstgneaneio
        }

        static string[] ExtractLines(string[] file) {
            string[] lines = new string[file.Length - 3];
            for (int i = 0; i < file.Length - 3; i++) {
                lines[i] = file[i + 2];
            }

            return lines;
        }
    }

}