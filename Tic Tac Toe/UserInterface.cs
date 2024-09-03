using System.Diagnostics;

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
            Console.WriteLine("Here is the current state of the game: ");
            const int SIZE_OF_GRID = 3;
            for (int x = 0; x < SIZE_OF_GRID; x++)
            {
                for (int y = 0; y < SIZE_OF_GRID; y++)
                {
                    Console.Write(grid[x, y]);
                }
                Console.Write($"\r\n");
            }
            Console.Write($"\r\n");
        }

        //we need the input from the player regarding where they want to play the next character (2 methods, 1 for the row and 1 for the column, so we can return 1-1 int)

        /// <summary>
        /// Defines the number of rows for the next character in the grid
        /// </summary>
        /// <returns>Number of rows for the next character in the grid as an int</returns>
        public static int GetPlayerRow()
        {
            Console.WriteLine("Please give me the number of row where you want to play your next move (1-3 from top to bottom):");
            int x = Convert.ToInt32(Console.ReadLine());
            x--;
            return x;
        }

        /// <summary>
        /// Defines the number of columns for the next character in the grid
        /// </summary>
        /// <returns>Number of columns for the next character in the grid as an int</returns>
        public static int GetPLayerColumn()
        {
            Console.WriteLine("Please give me the number of column where you want to play your next move (1-3 from left to right):");
            int y = Convert.ToInt32(Console.ReadLine());
            y--;
            return y;
        }

        /// <summary>
        /// Prints the text when it is time for the computer to play its next move
        /// </summary>
        public static void PrintComputerPlays()
        {
            Console.WriteLine($"Now it is the Computer's turn!\r\nThe computer plays his next move:");
        }

        /// <summary>
        /// Warning for the player that they cannot overwrite the computer's symbol
        /// </summary>
        public static void PrintPlayAgain()
        {
            Console.WriteLine($"You cannot place overwrite the computer's symbol! Try again!\r\n");
        }

        /// <summary>
        /// Prints the message that the number entered by the player is not valid
        /// </summary>
        public static void PrintNumberIsNotValid()
        {
            Console.WriteLine("Please give me a valid number! The value has to be between 1 and 3!");
        }


        /// <summary>
        /// Prints the text when the player won
        /// </summary>
        public static void PrintWonByPlayer()
        {
            Console.WriteLine("You Won!");
        }

        /// <summary>
        /// Prints the text when the computer won
        /// </summary>
        public static void PrintWonByComputer()
        {
            Console.WriteLine("The computer won this game! Try again!");
        }

        /// <summary>
        /// Clears the screen before the next round
        /// </summary>
        public static void ClearTheScreen()
        {
            Console.WriteLine("\r\nPlease press any button to move on to the next round!");
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Showing the message when nobody wins the game
        /// </summary>
        public static void PrintTie()
        {
            Console.WriteLine("This is a tie, nobody wins!");
        }

    }
}

