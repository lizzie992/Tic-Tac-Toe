namespace Tic_Tac_Toe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //define the grid
            const int sizeOfGrid = 3;
            string[,] grid = new string[sizeOfGrid, sizeOfGrid];

            const string UNDERLINE = " _ ";
            const string PLAYERCHARACTER = " X ";
            const string COMPUTERCHARACTER = " O ";

            //fill it up with empty _ characters so it can be visualized as we fill it out one by one
            for (int x = 0; x < sizeOfGrid; x++)
            {
                for (int y = 0; y < sizeOfGrid; y++)
                {
                    grid[x, y] = UNDERLINE;
                }
            }

            //and print it with the method - at first it will be completely empty
            UserInterface.PrintGrid(grid);
            int numberOfRow = 0;
            int numberOfColumn = 0;

            for (int i = 0; i < sizeOfGrid*sizeOfGrid; i++)
            {
                UserInterface.PlayerMoveRow();
                UserInterface.PlayerMoveColumn();
                grid[numberOfRow, numberOfColumn] = PLAYERCHARACTER;
                UserInterface.PrintGrid(grid);



            }
        }
    }
}
