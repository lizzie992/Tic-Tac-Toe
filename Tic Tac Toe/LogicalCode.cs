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
        public static int GetComputerRow()
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
        public static int GetComputerColumn()
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
        public static bool CheckCharacterOverlap(int x, int y, int w, int z)
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
        /// Checking the input from the player, if it is valid for this grid size
        /// </summary>
        /// <param name="number">Index number that we will use in the grid</param>
        /// <returns></returns>
        public static bool CheckPlayerInput(int number)
        {
            const int MIN_NUMBER_OF_GRID = 0;
            const int MAX_NUMBER_OF_GRID = 2;
            if (number <= MAX_NUMBER_OF_GRID && number >= MIN_NUMBER_OF_GRID)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// CHecking if all the fields of the grid are filled up with characters. If everything is filled up and no winning combination, then the game is a tie
        /// </summary>
        /// <param name="grid">Name of the grid</param>
        /// <param name="X">Name of the empty character</param>
        /// <returns></returns>
        public static bool CheckTie(string[,] grid, string X)
        {
            bool NoOneWinning = false;
            const string UNDERLINE = " _ ";
            for (int x = 0; x < SIZE_OF_GRID; x++)
            {
                for (int y = 0; y < SIZE_OF_GRID; y++)
                {
                    if (grid[x, y] != UNDERLINE)
                    {
                        NoOneWinning = true;
                    }
                    if (grid[x, y] == UNDERLINE)
                    {
                        NoOneWinning = false;
                        break;
                    }
                }
                if (NoOneWinning == false)
                {
                    break;
                }
            }
            if (NoOneWinning == true) //the grid does not contain any more underline characters, so it is a tie
            {
                return true;
            }
            else //there are still empty spaces in the grid, the game continues
            {
                return false;
            }
        }


        /// <summary>
        /// Checking if there is a winning combination in the game
        /// </summary>
        /// <param name="grid">Name of the grid</param>
        /// <param name="character">Character variable name</param>
        /// <param name="size">Size of rows and columns in the grid</param>
        /// <returns>Returns true / false</returns>
        public static bool CheckWinHorizontal(string[,] grid, string character, int size)
        {
            bool PlayerWinning = false;

            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    if (grid[x, y] != character)
                    {
                        PlayerWinning = false;
                        break;
                    }
                    if (grid[x, y] == character && y < size - 1)
                    {
                        continue;
                    }
                    if (grid[x, y] == character && y == size - 1)
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
            return false;
        }

        /// <summary>
        /// Checking if there is a winning combination in the game
        /// </summary>
        /// <param name="grid">Name of the grid</param>
        /// <param name="character">Character variable name</param>
        /// <param name="size">Size of rows and columns in the grid</param>
        /// <returns>Returns true / false</returns>
        public static bool CheckWinVertical(string[,] grid, string character, int size)
        {
            bool PlayerWinning = false;
            for (int y = 0; y < size; y++)
            {
                for (int x = 0; x < size; x++)
                {
                    if (grid[x, y] != character)
                    {
                        PlayerWinning = false;
                        break;
                    }
                    if (grid[x, y] == character && x < size - 1)
                    {
                        continue;
                    }
                    if (grid[x, y] == character && x == size - 1)
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
            return false;
        }

        /// <summary>
        /// Checking if there is a winning combination in the game
        /// </summary>
        /// <param name="grid">Name of the grid</param>
        /// <param name="character">Character variable name</param>
        /// <param name="size">Size of rows and columns in the grid</param>
        /// <returns>Returns true / false</returns>
        public static bool CheckWinDiagonal(string[,] grid, string character, int size)
        {
            bool PlayerWinning = false;
            int z = size;
            for (int x = 0; x < size; x++) // diagonal row top right to left bottom
            {
                z--;
                if (grid[x, z] != character)
                {
                    PlayerWinning = false;
                    break;
                }
                if (grid[x, z] == character && x < size - 1)
                {
                    continue;
                }
                if (grid[x, z] == character && x == size - 1)
                {
                    return true;
                }
            }
            for (int x = 0; x < size; x++) // diagonal row top left to right bottom
            {
                int y = x;
                if (grid[x, y] != character)
                {
                    PlayerWinning = false;
                    break;
                }
                if (grid[x, y] == character && y < size - 1)
                {
                    continue;
                }
                if (grid[x, y] == character && y == size - 1)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
