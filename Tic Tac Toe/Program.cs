namespace Tic_Tac_Toe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //define variables:
            const int sizeOfGrid = 3;
            string[,] grid = new string[sizeOfGrid, sizeOfGrid];

            const string PLAYERCHARACTER = " X ";
            const string COMPUTERCHARACTER = " O ";

            //create the empty grid that we will fill up with characters:
            LogicalCode.CreateEmptyGrid(grid);

            //and print it:
            UserInterface.PrintGrid(grid);

            //now add the first move from the player:
            int numberOfRow = UserInterface.PlayerMoveRow();
            int numberOfColumn = UserInterface.PlayerMoveColumn();
            grid[numberOfRow, numberOfColumn] = PLAYERCHARACTER;
            UserInterface.PrintGrid(grid);
        }
    }
}
