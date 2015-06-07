using System;

namespace MinesweeperLib {
    /// <summary>
    /// Simple Minesweeper game class
    /// </summary>
    public class MinesweeperGame {

        public MinesweeperGame() {
        }
		
        public int play(IPlayer player) {
            return play(player, false);
        }

		public int play(IPlayer player, bool printBoard) {
			MinesweeperBoard b = new MinesweeperBoard(5, 5);
            string fitnessEvaluation = "clicks";
            while (true) {
				Move nextMove = player.GetMove(b.Board);
				int x = nextMove.X;
				int y = nextMove.Y;
                GameStatus status = b.ClickSquare(x, y);
                if (printBoard) {
                    b.PrintBoard();
                }
				switch (status) {
                    case GameStatus.Exploded: {
                        return b.EvaluateFitness(fitnessEvaluation);
                    }
                    case GameStatus.Won: {
                        return b.EvaluateFitness(fitnessEvaluation);
                    }
                    case GameStatus.Updated: {continue;}
                }
            }
		}
	}
}