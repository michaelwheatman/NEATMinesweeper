using System;

namespace MinesweeperLib {
	/// <summary>
    /// A Player for Minesweeper that chooses the next cell randomly
    /// </summary>
    public class RandomPlayer : IPlayer {
		private Random random = new Random();
		public Move GetMove(MinesweeperSquare[,] board) {
			int x = random.Next(board.GetLength(1));
			int y = random.Next(board.GetLength(0));
			Move move = new Move(x, y);
			return move;
		}
    }
}