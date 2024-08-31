namespace Tic_Tac_Toe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int SIZE_OF_GRID = 3;
            string[,] grid = new string[SIZE_OF_GRID, SIZE_OF_GRID];
            const string UNDERLINE = " _ ";
            const string PLAYER_CHARACTER = " X ";
            const string COMPUTER_CHARACTER = " O ";

            int numberOfRowFromPlayer = 9;
            int numberOfColumnFromPlayer = 9;
            int numberOfRowFromComputer = 9;
            int numberOfColumnFromComputer = 9;

            LogicalCode.CreateEmptyGrid(grid);

            UserInterface.PrintGrid(grid);

            do
            {
                UserInterface.ClearTheScreen();

                numberOfRowFromPlayer = UserInterface.PlayerPlaysItsNextRow();
                numberOfColumnFromPlayer = UserInterface.PlayerPlaysItsNextColumn();

                if (LogicalCode.SomeoneOverwritesACharacter(numberOfRowFromComputer, numberOfRowFromPlayer, numberOfColumnFromComputer, numberOfColumnFromPlayer) == true)
                {
                    do
                    {
                        UserInterface.PlayAgain();
                        numberOfRowFromPlayer = UserInterface.PlayerPlaysItsNextRow();
                        numberOfColumnFromPlayer = UserInterface.PlayerPlaysItsNextColumn();
                    } while (LogicalCode.SomeoneOverwritesACharacter(numberOfRowFromComputer, numberOfRowFromPlayer, numberOfColumnFromComputer, numberOfColumnFromPlayer) == true);
                }

                if (UserInterface.IsTheNumberValid(numberOfRowFromPlayer) == false)
                {
                    do
                    {
                        numberOfRowFromPlayer = UserInterface.PlayerPlaysItsNextRow();
                    } while (UserInterface.IsTheNumberValid(numberOfRowFromPlayer) == false);
                }

                if (UserInterface.IsTheNumberValid(numberOfColumnFromPlayer) == false)
                {
                    do
                    {
                        numberOfColumnFromPlayer = UserInterface.PlayerPlaysItsNextColumn();
                    } while (UserInterface.IsTheNumberValid(numberOfColumnFromPlayer) == false);
                }

                grid[numberOfRowFromPlayer, numberOfColumnFromPlayer] = PLAYER_CHARACTER;
                UserInterface.PrintGrid(grid);

                UserInterface.ComputerPlays();
                numberOfRowFromComputer = LogicalCode.ComputerPlaysItsNextRow();
                numberOfColumnFromComputer = LogicalCode.ComputerPlaysItsNextColumn();
                if (LogicalCode.SomeoneOverwritesACharacter(numberOfRowFromComputer, numberOfRowFromPlayer, numberOfColumnFromComputer, numberOfColumnFromPlayer) == true)
                {
                    do
                    {
                        numberOfRowFromComputer = LogicalCode.ComputerPlaysItsNextRow();
                        numberOfColumnFromComputer = LogicalCode.ComputerPlaysItsNextColumn();
                    } while (LogicalCode.SomeoneOverwritesACharacter(numberOfRowFromComputer, numberOfRowFromPlayer, numberOfColumnFromComputer, numberOfColumnFromPlayer) == true);
                }
                grid[numberOfRowFromComputer, numberOfColumnFromComputer] = COMPUTER_CHARACTER;
                UserInterface.PrintGrid(grid);

                if (LogicalCode.NoOneWinning(grid, UNDERLINE) == true)
                {
                    UserInterface.ItIsATie();
                    break;
                }

            } while (LogicalCode.Winning(grid, PLAYER_CHARACTER, SIZE_OF_GRID) == false && LogicalCode.Winning(grid, COMPUTER_CHARACTER, SIZE_OF_GRID) == false);



            if (LogicalCode.Winning(grid, PLAYER_CHARACTER, SIZE_OF_GRID))
            {
                UserInterface.WonByPlayer();
            }
            if (LogicalCode.Winning(grid, COMPUTER_CHARACTER, SIZE_OF_GRID))
            {
                UserInterface.WonByComputer();
            }
        }
    }
}
