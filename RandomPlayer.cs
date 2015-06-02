using System;

namespace MinesweeperLib {
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