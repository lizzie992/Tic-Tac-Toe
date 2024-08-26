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

            int numberOfRowFromPlayer = 0;
            int numberOfColumnFromPlayer = 0;
            int numberOfRowFromComputer = 0;
            int numberOfColumnFromComputer = 0;

            //create the empty grid that we will fill up with characters:
            LogicalCode.CreateEmptyGrid(grid);

            //and print it:
            UserInterface.PrintGrid(grid);

            do
            {
                numberOfRowFromPlayer = UserInterface.PlayerPlaysItsNextRow();
                numberOfColumnFromPlayer = UserInterface.PlayerPlaysItsNextColumn();
                if (numberOfRowFromComputer == numberOfRowFromPlayer && numberOfColumnFromComputer == numberOfColumnFromPlayer)
                    do 
                    {
                        UserInterface.PlayAgain();
                        numberOfRowFromPlayer = UserInterface.PlayerPlaysItsNextRow();
                        numberOfColumnFromPlayer = UserInterface.PlayerPlaysItsNextColumn();
                    } while (numberOfRowFromComputer == numberOfRowFromPlayer && numberOfColumnFromComputer == numberOfColumnFromPlayer);
                grid[numberOfRowFromPlayer, numberOfColumnFromPlayer] = PLAYERCHARACTER;
                UserInterface.PrintGrid(grid);

                UserInterface.ComputerPlays();
                numberOfRowFromComputer = LogicalCode.ComputerPlaysItsNextRow();
                numberOfColumnFromComputer = LogicalCode.ComputerPlaysItsNextColumn();
                if (numberOfRowFromComputer == numberOfRowFromPlayer && numberOfColumnFromComputer == numberOfColumnFromPlayer)
                {
                    do
                    {
                        numberOfRowFromComputer = LogicalCode.ComputerPlaysItsNextRow();
                        numberOfColumnFromComputer = LogicalCode.ComputerPlaysItsNextColumn();
                    } while (numberOfRowFromComputer == numberOfRowFromPlayer && numberOfColumnFromComputer == numberOfColumnFromPlayer);
                }
                grid[numberOfRowFromComputer, numberOfColumnFromComputer] = COMPUTERCHARACTER;
                UserInterface.PrintGrid(grid);

                UserInterface.ClearTheScreen();

            } while (LogicalCode.ComputerWinning() == false && LogicalCode.PlayerWinning() == false);


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
