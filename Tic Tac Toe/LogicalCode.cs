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
        const int sizeOfGrid = 3;
        string[,] grid = new string[sizeOfGrid, sizeOfGrid];

        /// <summary>
        /// This method created an empty 3x3 grid
        /// </summary>
        /// <param name="grid">add the name of the grid</param>
        public static void CreateEmptyGrid(string[,] grid)
        {
            const string UNDERLINE = " _ ";
            int x = 0;
            int y = 0;
            for (x = 0; x < sizeOfGrid; x++)
            {
                for (y = 0; y < sizeOfGrid; y++)
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
    }
}
