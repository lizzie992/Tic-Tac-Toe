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


            LogicalCode.CreateEmptyGrid(grid);

            UserInterface.PrintGrid(grid);

            do
            {
                UserInterface.ClearTheScreen();

                int numberOfRowFromPlayer = UserInterface.GetPlayerRow();
                int numberOfColumnFromPlayer = UserInterface.GetPLayerColumn();

                if (LogicalCode.CheckCharacterOverlap(grid, numberOfRowFromPlayer, numberOfColumnFromPlayer))
                {
                    do
                    {
                        UserInterface.PrintPlayAgain();
                        numberOfRowFromPlayer = UserInterface.GetPlayerRow();
                        numberOfColumnFromPlayer = UserInterface.GetPLayerColumn();
                    } while (LogicalCode.CheckCharacterOverlap(grid, numberOfRowFromPlayer, numberOfColumnFromPlayer));
                }

                if (LogicalCode.CheckPlayerInput(numberOfRowFromPlayer) == false)
                {
                    do
                    {
                        UserInterface.PrintNumberIsNotValid(); 
                        numberOfRowFromPlayer = UserInterface.GetPlayerRow();
                    } while (LogicalCode.CheckPlayerInput(numberOfRowFromPlayer) == false);
                }

                if (LogicalCode.CheckPlayerInput(numberOfColumnFromPlayer) == false)
                {
                    do
                    {
                        UserInterface.PrintNumberIsNotValid();
                        numberOfColumnFromPlayer = UserInterface.GetPLayerColumn();
                    } while (LogicalCode.CheckPlayerInput(numberOfColumnFromPlayer) == false);
                }

                grid[numberOfRowFromPlayer, numberOfColumnFromPlayer] = PLAYER_CHARACTER;
                UserInterface.PrintGrid(grid);

                UserInterface.PrintComputerPlays();
                int numberOfRowFromComputer = LogicalCode.GetComputerRow();
                int numberOfColumnFromComputer = LogicalCode.GetComputerColumn();
                if (LogicalCode.CheckCharacterOverlap(grid, numberOfRowFromComputer, numberOfColumnFromComputer))
                {
                    do
                    {
                        numberOfRowFromComputer = LogicalCode.GetComputerRow();
                        numberOfColumnFromComputer = LogicalCode.GetComputerColumn();
                    } while (LogicalCode.CheckCharacterOverlap(grid, numberOfRowFromComputer, numberOfColumnFromComputer));
                }
                grid[numberOfRowFromComputer, numberOfColumnFromComputer] = COMPUTER_CHARACTER;
                UserInterface.PrintGrid(grid);

                if (LogicalCode.CheckTie(grid, UNDERLINE) == true)
                {
                    UserInterface.PrintTie();
                    break;
                }

            } while (LogicalCode.CheckWinHorizontal(grid, PLAYER_CHARACTER, SIZE_OF_GRID) == false && LogicalCode.CheckWinVertical(grid, PLAYER_CHARACTER, SIZE_OF_GRID) == false && LogicalCode.CheckWinDiagonal(grid, PLAYER_CHARACTER, SIZE_OF_GRID) == false &&
            LogicalCode.CheckWinHorizontal(grid, COMPUTER_CHARACTER, SIZE_OF_GRID) == false && LogicalCode.CheckWinVertical(grid, COMPUTER_CHARACTER, SIZE_OF_GRID) == false && LogicalCode.CheckWinDiagonal(grid, COMPUTER_CHARACTER, SIZE_OF_GRID) == false);



            if (LogicalCode.CheckWinHorizontal(grid, PLAYER_CHARACTER, SIZE_OF_GRID) || LogicalCode.CheckWinVertical(grid, PLAYER_CHARACTER, SIZE_OF_GRID) || LogicalCode.CheckWinDiagonal(grid, PLAYER_CHARACTER, SIZE_OF_GRID))
            {
                UserInterface.PrintWonByPlayer();
            }
            if (LogicalCode.CheckWinHorizontal(grid, COMPUTER_CHARACTER, SIZE_OF_GRID) || LogicalCode.CheckWinVertical(grid, COMPUTER_CHARACTER, SIZE_OF_GRID) || LogicalCode.CheckWinDiagonal(grid, COMPUTER_CHARACTER, SIZE_OF_GRID))
            {
                UserInterface.PrintWonByComputer();
            }
        }
    }
}
