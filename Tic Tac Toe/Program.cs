namespace Tic_Tac_Toe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[,] grid = new string[Constants.SIZE_OF_GRID, Constants.SIZE_OF_GRID];

            LogicalCode.CreateEmptyGrid(grid);

            UserInterface.PrintGrid(grid);

            do
            {
                UserInterface.ClearTheScreen();
                UserInterface.PressButtonToMoveOn();

                int numberOfRowFromPlayer = UserInterface.GetPlayerRow();
                int numberOfColumnFromPlayer = UserInterface.GetPLayerColumn();

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

                if (LogicalCode.CheckCharacterOverlap(grid, numberOfRowFromPlayer, numberOfColumnFromPlayer))
                {
                    do
                    {
                        UserInterface.PrintPlayAgain();
                        numberOfRowFromPlayer = UserInterface.GetPlayerRow();
                        numberOfColumnFromPlayer = UserInterface.GetPLayerColumn();
                    } while (LogicalCode.CheckCharacterOverlap(grid, numberOfRowFromPlayer, numberOfColumnFromPlayer));
                }

                grid[numberOfRowFromPlayer, numberOfColumnFromPlayer] = Constants.PLAYER_CHARACTER;
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
                grid[numberOfRowFromComputer, numberOfColumnFromComputer] = Constants.COMPUTER_CHARACTER;
                UserInterface.PrintGrid(grid);

                if (LogicalCode.CheckTie(grid, Constants.UNDERLINE) == true)
                {
                    UserInterface.PrintTie();
                    break;
                }

            } while (LogicalCode.CheckWinHorizontal(grid, Constants.PLAYER_CHARACTER) == false && LogicalCode.CheckWinVertical(grid, Constants.PLAYER_CHARACTER) == false && LogicalCode.CheckWinDiagonal(grid, Constants.PLAYER_CHARACTER) == false &&
            LogicalCode.CheckWinHorizontal(grid, Constants.COMPUTER_CHARACTER) == false && LogicalCode.CheckWinVertical(grid, Constants.COMPUTER_CHARACTER) == false && LogicalCode.CheckWinDiagonal(grid, Constants.COMPUTER_CHARACTER) == false);



            if (LogicalCode.CheckWinHorizontal(grid, Constants.PLAYER_CHARACTER) || LogicalCode.CheckWinVertical(grid, Constants.PLAYER_CHARACTER) || LogicalCode.CheckWinDiagonal(grid, Constants.PLAYER_CHARACTER))
            {
                UserInterface.PrintWonByPlayer();
            }
            if (LogicalCode.CheckWinHorizontal(grid, Constants.COMPUTER_CHARACTER) || LogicalCode.CheckWinVertical(grid, Constants.COMPUTER_CHARACTER) || LogicalCode.CheckWinDiagonal(grid, Constants.COMPUTER_CHARACTER))
            {
                UserInterface.PrintWonByComputer();
            }
        }
    }
}
