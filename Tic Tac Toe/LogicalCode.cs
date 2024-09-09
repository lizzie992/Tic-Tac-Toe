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
        
        string[,] grid = new string[Constants.SIZE_OF_GRID, Constants.SIZE_OF_GRID];

        /// <summary>
        /// This method created an empty 3x3 grid
        /// </summary>
        /// <param name="grid">add the name of the grid</param>
        public static void CreateEmptyGrid(string[,] grid)
        {
            int x = 0;
            int y = 0;
            for (x = 0; x < Constants.SIZE_OF_GRID; x++)
            {
                for (y = 0; y < Constants.SIZE_OF_GRID; y++)
                {
                    grid[x, y] = Constants.UNDERLINE;
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
            int maxValue = Constants.SIZE_OF_GRID;
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
            int maxValue = Constants.SIZE_OF_GRID;
            Random random = new Random();
            int randomNumber = random.Next(minValue, maxValue);
            return randomNumber;
        }

        /// <summary>
        /// Checking if the input is trying to overlap with an already existing symbol in the grid
        /// </summary>
        /// <param name="grid">Name of the grid</param>
        /// <param name="x">Number for the first index of the grid</param>
        /// <param name="y">Number for the second index of the grid</param>
        /// <returns>True if there is an overlap</returns>
        public static bool CheckCharacterOverlap(string[,] grid, int x, int y)
        {
            if (grid[x, y] == Constants.UNDERLINE) //then it is still an empty place in the grid
            {
                return false;
            }
            else //then it is already occupied with another symbol
            {
                return true;
            }
        }

        /// <summary>
        /// Checking the input from the player, if it is valid for this grid size
        /// </summary>
        /// <param name="number">Index number that we will use in the grid</param>
        /// <returns></returns>
        public static bool CheckPlayerInput(int number)
        {
            int minNumberOfGrid = 0;
            int maxNumberOfGrid = Constants.SIZE_OF_GRID - 1;
            if (number <= maxNumberOfGrid && number >= minNumberOfGrid)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// CHecking if all the fields of the grid are filled up with characters. If everything is filled up and no winning combination, then the game is a tie
        /// </summary>
        /// <param name="grid">Name of the grid</param>
        /// <param name="X">Name of the empty character</param>
        /// <returns></returns>
        public static bool CheckTie(string[,] grid, string UNDERLINE)
        {
            bool noOneWinning = false;
            for (int x = 0; x < Constants.SIZE_OF_GRID; x++)
            {
                for (int y = 0; y < Constants.SIZE_OF_GRID; y++)
                {
                    if (grid[x, y] != Constants.UNDERLINE)
                    {
                        noOneWinning = true;
                    }
                    if (grid[x, y] == Constants.UNDERLINE)
                    {
                        noOneWinning = false;
                        break;
                    }
                }
                if (noOneWinning == false)
                {
                    break;
                }
            }
            if (noOneWinning) //the grid does not contain any more underline characters, so it is a tie
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
        public static bool CheckWinHorizontal(string[,] grid, string character)
        {
            bool playerWinning = false;

            for (int x = 0; x < Constants.SIZE_OF_GRID; x++)
            {
                for (int y = 0; y < Constants.SIZE_OF_GRID; y++)
                {
                    if (grid[x, y] != character)
                    {
                        playerWinning = false;
                        break;
                    }
                    if (grid[x, y] == character && y < Constants.SIZE_OF_GRID - 1)
                    {
                        continue;
                    }
                    if (grid[x, y] == character && y == Constants.SIZE_OF_GRID - 1)
                    {
                        playerWinning = true;
                        break;
                    }
                }
                if (playerWinning == true)
                {
                    break;
                }
            }
            if (playerWinning == true)
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
        public static bool CheckWinVertical(string[,] grid, string character)
        {
            bool playerWinning = false;
            for (int y = 0; y < Constants.SIZE_OF_GRID; y++)
            {
                for (int x = 0; x < Constants.SIZE_OF_GRID; x++)
                {
                    if (grid[x, y] != character)
                    {
                        playerWinning = false;
                        break;
                    }
                    if (grid[x, y] == character && x < Constants.SIZE_OF_GRID - 1)
                    {
                        continue;
                    }
                    if (grid[x, y] == character && x == Constants.SIZE_OF_GRID - 1)
                    {
                        playerWinning = true;
                        break;
                    }
                }
                if (playerWinning == true)
                {
                    break;
                }
            }
            if (playerWinning == true)
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
        public static bool CheckWinDiagonal(string[,] grid, string character)
        {
            bool playerWinning = false;
            int z = Constants.SIZE_OF_GRID;
            for (int x = 0; x < Constants.SIZE_OF_GRID; x++) // diagonal row top right to left bottom
            {
                z--;
                if (grid[x, z] != character)
                {
                    playerWinning = false;
                    break;
                }
                if (grid[x, z] == character && x < Constants.SIZE_OF_GRID - 1)
                {
                    continue;
                }
                if (grid[x, z] == character && x == Constants.SIZE_OF_GRID - 1)
                {
                    return true;
                }
            }
            for (int x = 0; x < Constants.SIZE_OF_GRID; x++) // diagonal row top left to right bottom
            {
                int y = x;
                if (grid[x, y] != character)
                {
                    playerWinning = false;
                    break;
                }
                if (grid[x, y] == character && y < Constants.SIZE_OF_GRID - 1)
                {
                    continue;
                }
                if (grid[x, y] == character && y == Constants.SIZE_OF_GRID - 1)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
