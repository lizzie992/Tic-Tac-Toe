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

            for (int i = 0; i < sizeOfGrid * sizeOfGrid; i++)
            {
                int numberOfRowFromPlayer = UserInterface.PlayerPlaysItsNextRow();
                int numberOfColumnFromPlayer = UserInterface.PlayerPlaysItsNextColumn();
                grid[numberOfRowFromPlayer, numberOfColumnFromPlayer] = PLAYERCHARACTER;
                UserInterface.PrintGrid(grid);

                UserInterface.ComputerPlays();
                int numberOfRowFromComputer = LogicalCode.ComputerPlaysItsNextRow();
                int numberOfColumnFromComputer = LogicalCode.ComputerPlaysItsNextColumn();
                grid[numberOfRowFromComputer, numberOfColumnFromComputer] = COMPUTERCHARACTER;
                UserInterface.PrintGrid(grid);

            }
        }
    }
}
