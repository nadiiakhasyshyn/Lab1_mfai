namespace Lab1_ai
{
    public class AnnealingAlgorithm
    {
        private int BoardSize;
        private double MaxTemperature;
        private double MinTemperature;
        private double TemperatureDecreaseFactor;
        private int IterationsPerTemperature;

        public AnnealingAlgorithm(int boardSize, double maxTemperature, double minTemperature, double temperatureDecreaseFactor, int iterationsPerTemperature)
        {
            BoardSize = boardSize;
            MaxTemperature = maxTemperature;
            MinTemperature = minTemperature;
            TemperatureDecreaseFactor = temperatureDecreaseFactor;
            IterationsPerTemperature = iterationsPerTemperature;
        }

        private Board GetInitialBoard()
        {
            Board board = new Board(BoardSize);
            for (int i = 0; i < BoardSize; i++)
            {
                board.PlaceQueenOnSquare(i, 0);
            }
            return board;
        }

        private Board GenerateNextBoard(Board currentBoard)
        {
            Random r = new Random();
            int row = r.Next(0, BoardSize);
            int col = r.Next(0, BoardSize);
            while (currentBoard.IsQueenOnSquare(row, col))
            {
                row = r.Next(0, BoardSize);
                col = r.Next(0, BoardSize);
            }
            Board newBoard = new Board(BoardSize);
            for (int i = 0; i < BoardSize; i++)
            {
                if (i == row)
                {
                    newBoard.PlaceQueenOnSquare(i, col);
                }
                else
                {
                    newBoard.PlaceQueenOnSquare(i, currentBoard.GetQueenColumnForRow(i));
                }
            }
            return newBoard;
        }

        public Board Solve()
        {
            Board currentBoard = GetInitialBoard();
            Console.WriteLine("\n___Початкове розташування ферзей на шаховiй дошцi___\n");
            currentBoard.Print();
            double temperature = MaxTemperature;
            while (temperature > MinTemperature)
            {
                for (int i = 0; i < IterationsPerTemperature; i++)
                {
                    Board nextBoard = GenerateNextBoard(currentBoard);
                    int deltaE = nextBoard.GetAttackingPairs() - currentBoard.GetAttackingPairs();
                    if (deltaE <= 0 || Math.Exp(-deltaE / temperature) > new Random().NextDouble())
                    {
                        currentBoard = nextBoard;
                    }
                }
                temperature *= TemperatureDecreaseFactor;
            }
            return currentBoard;
        }
    }
}
