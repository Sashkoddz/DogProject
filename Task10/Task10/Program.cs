namespace Task10
{
    internal class Program
    {
        static char[,] labyrinth;
        static List<string> paths = new List<string>();
        static void Main(string[] args)
        {
            string[] dimensions = Console.ReadLine().Split();
            int rows = int.Parse(dimensions[0]);
            int cols = int.Parse(dimensions[1]);

            labyrinth = new char[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                string line = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    labyrinth[row, col] = line[col];
                }
            }

            FindPaths(0, 0, "");

            foreach (string path in paths)
            {
                Console.WriteLine(path);
            }
        }
        static void FindPaths(int row, int col, string path)
        {
            if (!IsInBounds(row, col) || labyrinth[row, col] == '*')
            {
                return;
            }

            if (labyrinth[row, col] == 'e')
            {
                paths.Add(path);
                return;
            }

            labyrinth[row, col] = '*';
            FindPaths(row, col + 1, path + "R");
            FindPaths(row + 1, col, path + "D"); 
            FindPaths(row, col - 1, path + "L"); 
            FindPaths(row - 1, col, path + "U"); 
            labyrinth[row, col] = '-';
        }
        static bool IsInBounds(int row, int col)
        {
            return row >= 0 && row < labyrinth.GetLength(0) && col >= 0 && col < labyrinth.GetLength(1);
        }
    }
}
