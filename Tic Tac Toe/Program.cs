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
                int numberOfRowFromPlayer = UserInterface.GetPlayerRow();
                int numberOfColumnFromPlayer = UserInterface.GetPLayerColumn();

                if (LogicalCode.CheckPlayerInput(numberOfRowFromPlayer))
                {
                    do
                    {
                        UserInterface.PrintNumberIsNotValid(); 
                        numberOfRowFromPlayer = UserInterface.GetPlayerRow();
                    } while (LogicalCode.CheckPlayerInput(numberOfRowFromPlayer));
                }

                if (LogicalCode.CheckPlayerInput(numberOfColumnFromPlayer))
                {
                    do
                    {
                        UserInterface.PrintNumberIsNotValid();
                        numberOfColumnFromPlayer = UserInterface.GetPLayerColumn();
                    } while (LogicalCode.CheckPlayerInput(numberOfColumnFromPlayer));
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

                if (LogicalCode.CheckTie(grid))
                {
                    UserInterface.PrintTie();
                    break;
                }

                UserInterface.PressButtonToMoveOn();
                UserInterface.ClearTheScreen();

            } while (!LogicalCode.IsWinHorizontal(grid, Constants.PLAYER_CHARACTER) && !LogicalCode.IsWinVertical(grid, Constants.PLAYER_CHARACTER) && !LogicalCode.IsWinDiagonal(grid, Constants.PLAYER_CHARACTER) &&
            !LogicalCode.IsWinHorizontal(grid, Constants.COMPUTER_CHARACTER) && !LogicalCode.IsWinVertical(grid, Constants.COMPUTER_CHARACTER) && !LogicalCode.IsWinDiagonal(grid, Constants.COMPUTER_CHARACTER));



            if (LogicalCode.IsWinHorizontal(grid, Constants.PLAYER_CHARACTER) || LogicalCode.IsWinVertical(grid, Constants.PLAYER_CHARACTER) || LogicalCode.IsWinDiagonal(grid, Constants.PLAYER_CHARACTER))
            {
                UserInterface.PrintWonByPlayer();
            }
            if (LogicalCode.IsWinHorizontal(grid, Constants.COMPUTER_CHARACTER) || LogicalCode.IsWinVertical(grid, Constants.COMPUTER_CHARACTER) || LogicalCode.IsWinDiagonal(grid, Constants.COMPUTER_CHARACTER))
            {
                UserInterface.PrintWonByComputer();
            }
        }
    }
}
