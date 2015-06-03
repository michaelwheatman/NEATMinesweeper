using System;
using SharpNeat.Phenomes;


namespace MinesweeperLib {
    public class NeatPlayer : IPlayer {
		public IBlackBox Brain {get; set; }
		//creates a new neat player with the specified brain
		public NeatPlayer(IBlackBox brain) {
			Brain = brain;
		}
		
		public Move GetMove(MinesweeperSquare[,] board) {
			int height = board.GetLength(1);
			int width = board.GetLength(0);
			for (var i = 0; i < height; i++) {
                for (var j = 0; j < width; j++) {
					int status = -1;
					if (board[i,j].Revealed) {
						status = board[i,j].AdjacentMines;
					}
                    Brain.InputSignalArray[i + j*height] = (double) status;
                }
            }
			Brain.Activate();
			Move move = null;
			double min = double.MinValue;
			for (var i = 0; i < height; i++) {
                for (var j = 0; j < width; j++) {
					if (board[i, j].Revealed)
						continue;
					
					double score = Brain.OutputSignalArray[j*height + i];
					if (move == null) {
						move = new Move(i, j);
						min = score;
					} else if (min < score) {
						move.X = i;
						move.Y = j;
						min = score;
					}
				}
			}
			return move;
		}
    }
}