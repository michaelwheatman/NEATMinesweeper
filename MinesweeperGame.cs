using System;

namespace MinesweeperLib {
    /// <summary>
    /// Simple Minesweeper board class
    /// </summary>
    public class MinesweeperGame {

        public MinesweeperGame() {
        }
		
        public int play(IPlayer player) {
            return play(player, false);
        }

		public int play(IPlayer player, bool printBoard) {
			MinesweeperBoard b = new MinesweeperBoard(5, 5);
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
                        return b.EvaluateFitness();
                    }
                    case GameStatus.Won: {
                        return b.EvaluateFitness();
                    }
                    case GameStatus.Updated: {continue;}
                }
            }
		}
	}
}