namespace Tic_Tac_Toe
{
    public static class UserInterface
    {
        //method for printing the current state of the grid:

        /// <summary>
        /// Prints the current state of the grid
        /// </summary>
        /// <param name="grid">add the name of the grid</param>
        public static void PrintGrid(string[,] grid)
        {
            const int sizeOfGrid = 3;
            for (int x = 0; x < sizeOfGrid; x++)
            {
                for (int y = 0; y < sizeOfGrid; y++)
                {
                    Console.Write(grid[x, y]);
                }
                Console.Write($"\r\n");
            }
        }

        //we need the input from the player regarding where they want to play the next character (2 methods, 1 for the row and 1 for the column, so we can return 1-1 int)

        /// <summary>
        /// Defines the number of rows for the next character in the grid
        /// </summary>
        /// <returns>Number of rows for the next character in the grid as an int</returns>
        public static int PlayerMoveRow(int numberOfRow)
        {
            const string INSTUCTION_FOR_ROW = "Please give me the number of row where you want to play your next move (1-3 from top to bottom):";
            Console.WriteLine(INSTUCTION_FOR_ROW);
            numberOfRow = Convert.ToInt32(Console.ReadLine());
            numberOfRow--;
            return numberOfRow;
        }

        /// <summary>
        /// Defines the number of columns for the next character in the grid
        /// </summary>
        /// <returns>Number of columns for the next character in the grid as an int</returns>
        public static int PlayerMoveColumn(int numberOfColumn)
        {
            const string INSTUCTION_FOR_COLUMN = "Please give me the number of column where you want to play your next move (1-3 from left to right):";
            Console.WriteLine(INSTUCTION_FOR_COLUMN);
            numberOfColumn = Convert.ToInt32(Console.ReadLine());
            numberOfColumn--;
            return numberOfColumn;
        }
    }
}

