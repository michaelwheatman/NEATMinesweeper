using System;

namespace MinesweeperLib {
    /// <summary>
    /// Simple Minesweeper board class
    /// </summary>
    public class MinesweeperGame {

        public MinesweeperGame() {
        }
		
		public int play(IPlayer player) {
			MinesweeperBoard b = new MinesweeperBoard(5, 5);
            while (true) {
				Move nextMove = player.GetMove(b.Board);
				int x = nextMove.X;
				int y = nextMove.Y;
                GameStatus status = b.ClickSquare(x, y);
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
	// class Program {
 //        static void Main() {
	// 		IPlayer player = new RandomPlayer();
	// 		MinesweeperGame game = new MinesweeperGame();
	// 		Console.WriteLine(game.play(player));
 //        }
 //    }
}