using System;
using SharpNeat.Phenomes;


namespace MinesweeperLib {
    public class NeatPlayer : IPlayer {
		//creates a new neat player with the specified brain
		public NeatPlayer(IBlackBox brain) {
			Brain = brain;
		}
		
		public Move GetMove(MinesweeperSquare[,] board) {
			int height = board.GetLength(1);
			int width = board.getLength(0);
			for (var i = 0; i < height; i++) {
                for (var j = 0; j < width; j++) {
                    Brain.InputSignalArray[i + j*height] = board[i,j];
                }
            }
			Brain.Activate();
			Move move = null;
			double min = double.maxValue;
			for (var i = 0; i < height; i++) {
                for (var j = 0; j < width; j++) {
					if (board[i, j].Revealed)
						continue;
					
					double score = Brain.OutputSignalArray[j*height + i];
					if (move = null) {
						move = newMove(i, j);
						max = score;
					} else if (max < score) {
						move.X = i;
						move.Y = j;
						max = score;
					}
				}
			}
			return move;
		}
    }
}