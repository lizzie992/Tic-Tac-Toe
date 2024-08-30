using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{

    class LogicalCode
    {
        const int SIZE_OF_GRID = 3;
        string[,] grid = new string[SIZE_OF_GRID, SIZE_OF_GRID];

        /// <summary>
        /// This method created an empty 3x3 grid
        /// </summary>
        /// <param name="grid">add the name of the grid</param>
        public static void CreateEmptyGrid(string[,] grid)
        {
            const string UNDERLINE = " _ ";
            int x = 0;
            int y = 0;
            for (x = 0; x < SIZE_OF_GRID; x++)
            {
                for (y = 0; y < SIZE_OF_GRID; y++)
                {
                    grid[x, y] = UNDERLINE;
                }
            }
        }

        /// <summary>
        /// Returns a random number between 0-3 to use for the computer's symbol placement
        /// </summary>
        /// <returns>Returns the row's value for the computer's next move</returns>
        public static int ComputerPlaysItsNextRow()
        {
            int minValue = 0;
            int maxValue = 3;
            Random random = new Random();
            int randomNumber = random.Next(minValue, maxValue);
            return randomNumber;
        }
        /// <summary>
        /// Returns a random number between 0-3 to use for the computer's symbol placement
        /// </summary>
        /// <returns>Returns the column's value for the computer's next move</returns>
        public static int ComputerPlaysItsNextColumn()
        {
            int minValue = 0;
            int maxValue = 3;
            Random random = new Random();
            int randomNumber = random.Next(minValue, maxValue);
            return randomNumber;
        }

        /// <summary>
        /// Compares the values that the computer has given with the values from the player, if they are the same
        /// </summary>
        /// <param name="x">numberOfRowFromComputer</param>
        /// <param name="y">numberOfRowFromPlayer</param>
        /// <param name="w">numberOfColumnFromComputer></param>
        /// <param name="z">numberOfColumnFromPlayer</param>
        /// <returns></returns>
        public static bool ComputerOverwritesPLayer(int x, int y, int w, int z)
        {
            if (x == y && w == z)
            {
                return true;
            }
            else
            {
                return false;
            }
        }




        /// <summary>
        /// Checking if there is a winning combination in the game
        /// </summary>
        /// <param name="grid">Name of the grid</param>
        /// <param name="Character">Character variable name</param>
        /// <param name="SIZE_OF_GRID">Size of rows and columns in the grid</param>
        /// <returns></returns>
        public static bool Winning(string[,] grid, string Character, int SIZE_OF_GRID)
        {
            bool PlayerWinning = false;

            for (int x = 0; x < SIZE_OF_GRID; x++) // horizontal rows
            {
                for (int y = 0; y < SIZE_OF_GRID; y++)
                {
                    if (grid[x, y] != Character)
                    {
                        PlayerWinning = false;
                        break;
                    }
                    if (grid[x, y] == Character && y < SIZE_OF_GRID - 1)
                    {
                        continue;
                    }
                    if (grid[x, y] == Character && y == SIZE_OF_GRID - 1)
                    {
                        PlayerWinning = true;
                        break;
                    }
                }
                if (PlayerWinning == true)
                {
                    break;
                }
            }
            if (PlayerWinning == true)
            {
                return true;
            }

            for (int y = 0; y < SIZE_OF_GRID; y++) // vertical rows
            {
                for (int x = 0; x < SIZE_OF_GRID; x++)
                {
                    if (grid[x, y] != Character)
                    {
                        PlayerWinning = false;
                        break;
                    }
                    if (grid[x, y] == Character && x < SIZE_OF_GRID - 1)
                    {
                        continue;
                    }
                    if (grid[x, y] == Character && x == SIZE_OF_GRID - 1)
                    {
                        PlayerWinning = true;
                        break;
                    }
                }
                if (PlayerWinning == true)
                {
                    break;
                }
            }
            if (PlayerWinning == true)
            {
                return true;
            }


            int z = SIZE_OF_GRID;
            for (int x = 0; x < SIZE_OF_GRID; x++) // diagonal row top right to left bottom
            {
                z--;
                if (grid[x, z] != Character)
                {
                    PlayerWinning = false;
                    break;
                }
                if (grid[x, z] == Character && x < SIZE_OF_GRID - 1)
                {
                    continue;
                }
                if (grid[x, z] == Character && x == SIZE_OF_GRID - 1)
                {
                    PlayerWinning = true;
                    break;
                }


                if (PlayerWinning == true)
                {
                    break;
                }

            }
            if (PlayerWinning == true)
            {
                return true;
            }


            for (int x = 0; x < SIZE_OF_GRID; x++) // diagonal row top left to right bottom
            {
                int y = x;
                if (grid[x, y] != Character)
                {
                    PlayerWinning = false;
                    break;
                }
                if (grid[x, y] == Character && y < SIZE_OF_GRID - 1)
                {
                    continue;
                }
                if (grid[x, y] == Character && y == SIZE_OF_GRID - 1)
                {
                    PlayerWinning = true;
                    break;
                }

                if (PlayerWinning == true)
                {
                    break;
                }
            }
            if (PlayerWinning == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
