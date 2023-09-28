using System;
using System.Text;

namespace LevensteinApp
{
    class LevensteinDistance
    {
        static string GetInput (string prompt)
        {
            Console.Write(prompt);
            string Inp = Console.ReadLine();
            int count = 0;
            foreach (var el in Inp) if (char.IsLetter(el)) count++;
            while (count == 0) {
                Console.WriteLine("Enter a non-empty string");
                Inp = Console.ReadLine();
                foreach (var el in Inp) if (char.IsLetter(el)) count++;
            }
            //Having taken in a string with letters, delete everything non-letter
            StringBuilder Result = new StringBuilder(count);
            foreach (var x in Inp) if (char.IsLetter(x)) { Result.Append(x);};
            return Result.ToString();
        }

        static void Print_Matrix(int[,] Matrix, string title) {
            Console.WriteLine("\n{0}\n", title);
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    Console.Write(Matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
        static void Run_It_Back(int curr_line, int curr_column, string WordSource, string WordRes, int[,] Matrix)
        {
            if (curr_line == 0 & curr_column == 0) {  return; }
            string NewWordSource = WordSource;
            string NewWordRes = WordRes;
            if (WordSource[curr_column] == WordRes[curr_line]) {
                if (Matrix[curr_line, curr_column] == Matrix[curr_line - 1, curr_column - 1]) {
                    Run_It_Back(curr_line - 1, curr_column - 1, NewWordSource, NewWordRes, Matrix);
                    //No Console output - there was no action performed because the letters matched
                }
            }

        }

        static void Main()
        {
            Console.WriteLine("### Levenstein`s Distance Calculation Algorithm ###\n");
            string Word1 = GetInput("Enter the first word: ");
            string Word2 = GetInput("Enter the second word: ");

            int[,] VF_Matrix = new int[Word2.Length + 1, Word1.Length + 1]; //Creating a Vagner-Fischer`s Matrix
            //Suppose Word1 is the Source word, Word2 is the result

            //Initializing the first line of the Matrix
            for (int i = 0; i < Word1.Length + 1; ++i)
            {
                VF_Matrix[0, i] = i;
            }

            //Initializing the first column of the Matrix
            for (int j = 0; j < Word2.Length + 1; ++j)
            {
                VF_Matrix[j, 0] = j;
            }

            //Filling the matrix up using VF method
            for (int line = 1; line < VF_Matrix.GetLength(0); ++line)
            {
                for (int column = 1; column < VF_Matrix.GetLength(1); ++column)
                {
                    //Whether we +1 the left-up num in the comparison depends on whether the letters of the current pair are equal
                    VF_Matrix[line, column] = Math.Min(Math.Min(VF_Matrix[line - 1, column] + 1, VF_Matrix[line, column - 1] + 1), VF_Matrix[line - 1, column - 1] + Convert.ToInt32(Word1[column-1] != Word2[line-1]));
                }
            }

            //Printing the matrix to check
            Print_Matrix(VF_Matrix, "Vagner - Fischer`s Matrix:");

            //Got the Matrix, now the most faraway from (0,0) cell contains the Levenstein`s Distance.
            Console.WriteLine("\nThe Levenstein`s Distance for the input pair of words = {0}", VF_Matrix[Word2.Length, Word1.Length]);

            //To trace the path of permutations, we`ll use a recurrent function
            Run_It_Back(0, 0, Word1, Word2, VF_Matrix);

            Console.Write("\nProgram finished. Press any key to terminate . . .");
            Console.ReadKey();
            return;
        }
    }
}
