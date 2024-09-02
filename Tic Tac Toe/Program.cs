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

                if (LogicalCode.CheckForCharacterOverlap(numberOfRowFromComputer, numberOfRowFromPlayer, numberOfColumnFromComputer, numberOfColumnFromPlayer))
                {
                    do
                    {
                        UserInterface.PrintMessagePlayAgain();
                        numberOfRowFromPlayer = UserInterface.PlayerPlaysItsNextRow();
                        numberOfColumnFromPlayer = UserInterface.PlayerPlaysItsNextColumn();
                    } while (LogicalCode.CheckForCharacterOverlap(numberOfRowFromComputer, numberOfRowFromPlayer, numberOfColumnFromComputer, numberOfColumnFromPlayer));
                }

                if (LogicalCode.CheckIfTheNumberIsValid(numberOfRowFromPlayer) == false)
                {
                    do
                    {
                        UserInterface.PrintMessageNumberIsNotValid(); 
                        numberOfRowFromPlayer = UserInterface.PlayerPlaysItsNextRow();
                    } while (LogicalCode.CheckIfTheNumberIsValid(numberOfRowFromPlayer) == false);
                }

                if (LogicalCode.CheckIfTheNumberIsValid(numberOfColumnFromPlayer) == false)
                {
                    do
                    {
                        UserInterface.PrintMessageNumberIsNotValid();
                        numberOfColumnFromPlayer = UserInterface.PlayerPlaysItsNextColumn();
                    } while (LogicalCode.CheckIfTheNumberIsValid(numberOfColumnFromPlayer) == false);
                }

                grid[numberOfRowFromPlayer, numberOfColumnFromPlayer] = PLAYER_CHARACTER;
                UserInterface.PrintGrid(grid);

                UserInterface.PrintMessageComputerPlays();
                numberOfRowFromComputer = LogicalCode.ComputerPlaysItsNextRow();
                numberOfColumnFromComputer = LogicalCode.ComputerPlaysItsNextColumn();
                if (LogicalCode.CheckForCharacterOverlap(numberOfRowFromComputer, numberOfRowFromPlayer, numberOfColumnFromComputer, numberOfColumnFromPlayer))
                {
                    do
                    {
                        numberOfRowFromComputer = LogicalCode.ComputerPlaysItsNextRow();
                        numberOfColumnFromComputer = LogicalCode.ComputerPlaysItsNextColumn();
                    } while (LogicalCode.CheckForCharacterOverlap(numberOfRowFromComputer, numberOfRowFromPlayer, numberOfColumnFromComputer, numberOfColumnFromPlayer));
                }
                grid[numberOfRowFromComputer, numberOfColumnFromComputer] = COMPUTER_CHARACTER;
                UserInterface.PrintGrid(grid);

                if (LogicalCode.NoOneWinning(grid, UNDERLINE) == true)
                {
                    UserInterface.PrintMessageItIsATie();
                    break;
                }

            } while (LogicalCode.CheckingForAWinHorizontal(grid, PLAYER_CHARACTER, SIZE_OF_GRID) == false && LogicalCode.CheckingForAWinVertical(grid, PLAYER_CHARACTER, SIZE_OF_GRID) == false && LogicalCode.CheckingForAWinDiagonal(grid, PLAYER_CHARACTER, SIZE_OF_GRID) == false &&
            LogicalCode.CheckingForAWinHorizontal(grid, COMPUTER_CHARACTER, SIZE_OF_GRID) == false && LogicalCode.CheckingForAWinVertical(grid, COMPUTER_CHARACTER, SIZE_OF_GRID) == false && LogicalCode.CheckingForAWinDiagonal(grid, COMPUTER_CHARACTER, SIZE_OF_GRID) == false);



            if (LogicalCode.CheckingForAWinHorizontal(grid, PLAYER_CHARACTER, SIZE_OF_GRID) || LogicalCode.CheckingForAWinVertical(grid, PLAYER_CHARACTER, SIZE_OF_GRID) || LogicalCode.CheckingForAWinDiagonal(grid, PLAYER_CHARACTER, SIZE_OF_GRID))
            {
                UserInterface.PrintMessageWonByPlayer();
            }
            if (LogicalCode.CheckingForAWinHorizontal(grid, COMPUTER_CHARACTER, SIZE_OF_GRID) || LogicalCode.CheckingForAWinVertical(grid, COMPUTER_CHARACTER, SIZE_OF_GRID) || LogicalCode.CheckingForAWinDiagonal(grid, COMPUTER_CHARACTER, SIZE_OF_GRID))
            {
                UserInterface.PrintMessageWonByComputer();
            }
        }
    }
}
