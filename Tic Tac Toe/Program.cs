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

            int numberOfRowFromPlayer = 9;
            int numberOfColumnFromPlayer = 9;
            int numberOfRowFromComputer = 9;
            int numberOfColumnFromComputer = 9;

            //create the empty grid that we will fill up with characters:
            LogicalCode.CreateEmptyGrid(grid);

            //and print it:
            UserInterface.PrintGrid(grid);

            do
            {
                numberOfRowFromPlayer = UserInterface.PlayerPlaysItsNextRow();
                numberOfColumnFromPlayer = UserInterface.PlayerPlaysItsNextColumn();

                if (UserInterface.PlayerOverwritesComputer(numberOfRowFromComputer, numberOfRowFromPlayer, numberOfColumnFromComputer, numberOfColumnFromPlayer) == true)
                {
                    do
                    {
                        UserInterface.PlayAgain();
                        numberOfRowFromPlayer = UserInterface.PlayerPlaysItsNextRow();
                        numberOfColumnFromPlayer = UserInterface.PlayerPlaysItsNextColumn();
                    } while (UserInterface.PlayerOverwritesComputer(numberOfRowFromComputer, numberOfRowFromPlayer, numberOfColumnFromComputer, numberOfColumnFromPlayer) == true);
                }
                grid[numberOfRowFromPlayer, numberOfColumnFromPlayer] = PLAYERCHARACTER;
                UserInterface.PrintGrid(grid);

                UserInterface.ComputerPlays();
                numberOfRowFromComputer = LogicalCode.ComputerPlaysItsNextRow();
                numberOfColumnFromComputer = LogicalCode.ComputerPlaysItsNextColumn();
                if (LogicalCode.ComputerOverwritesPLayer(numberOfRowFromComputer, numberOfRowFromPlayer, numberOfColumnFromComputer, numberOfColumnFromPlayer) == true)
                {
                    do
                    {
                        numberOfRowFromComputer = LogicalCode.ComputerPlaysItsNextRow();
                        numberOfColumnFromComputer = LogicalCode.ComputerPlaysItsNextColumn();
                    } while (LogicalCode.ComputerOverwritesPLayer(numberOfRowFromComputer, numberOfRowFromPlayer, numberOfColumnFromComputer, numberOfColumnFromPlayer) == true);
                }
                grid[numberOfRowFromComputer, numberOfColumnFromComputer] = COMPUTERCHARACTER;
                UserInterface.PrintGrid(grid);

                UserInterface.ClearTheScreen();

            } while (numberOfRowFromComputer < 10); //(LogicalCode.ComputerWinning() == false && LogicalCode.PlayerWinning() == false);


            if (LogicalCode.ComputerWinning() == true)
            {
                UserInterface.WonByComputer();
            }

            if (LogicalCode.PlayerWinning() == true)
            {
                UserInterface.WonByPlayer();
            }

        }
    }
}
