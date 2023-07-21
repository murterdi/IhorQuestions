//Starting

namespace FriendsTaskTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the matrix as string (e.g. \"1,0,1;0,1,0\"): ");
            string input = Console.ReadLine();

            int areas = CountAreasOfOnes(input);
            Console.WriteLine("Result : " + areas);
        }

        static int CountAreasOfOnes(string input)
        {
            string[] rows = input.Split(';');
            int rowCount = rows.Length;
            int colCount = rows[0].Split(',').Length;

            int[,] matrix = new int[rowCount, colCount];

            for (int i = 0; i < rowCount; i++)
            {
                string[] cols = rows[i].Split(',');
                for (int j = 0; j < colCount; j++)
                {
                    matrix[i, j] = int.Parse(cols[j]);
                }
            }

            int areas = 0;
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    if (matrix[i, j] == 1)
                    {
                        areas++;
                        DFS(matrix, i, j);
                    }
                }
            }

            return areas;
        }

        //using Depth-First Search (DFS) algorithm.
        static void DFS(int[,] matrix, int row, int col)
        {
            int rowCount = matrix.GetLength(0);
            int colCount = matrix.GetLength(1);

            if (row < 0 || row >= rowCount || col < 0 || col >= colCount || matrix[row, col] != 1)
            {
                return;
            }

            matrix[row, col] = -1;

            DFS(matrix, row - 1, col);
            DFS(matrix, row + 1, col);
            DFS(matrix, row, col - 1);
            DFS(matrix, row, col + 1);
        }
    }
}