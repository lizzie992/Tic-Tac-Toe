using System;
using System.Collections.Generic;
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
    }
}
