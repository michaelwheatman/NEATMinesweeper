using System;

namespace MinesweeperLib {

    public enum GameStatus {
        Exploded, Won, Updated
    }

    /// <summary>
    /// Simple Minesweeper board class
    /// </summary>
    public class MinesweeperBoard {
        public MinesweeperSquare[,] Board {get; private set;}        
        public int Height {get{return Board.GetLength(0);}}
        public int Width {get{return Board.GetLength(1);}}
        private bool HasClickedOnce;
		private Random random = new Random();

        public MinesweeperBoard(int n, int m) {
            Board = new MinesweeperSquare[n, m];
            // setup board
            ForEachSquare((i, j) => {
                Board[i, j] = new MinesweeperSquare();
            });
            // remember if the player has clicked so you can't die on the first click
            HasClickedOnce = false;
        }

        // place mines randomly on the board
        private void InitMines(double weight, int excludeX, int excludeY) {
            HasClickedOnce = true;
            int numMines = (int)(weight * Height * Width);
            for (var i = 0; i < numMines; i++) {
                var x = random.Next(Width);
                var y = random.Next(Height);
                if (!Board[x, y].Mined && x != excludeX && y != excludeY) {
                    Board[x, y].Mined = true;
                }
                else {
                    i--;
                }
            }
            ForEachSquare((i, j) => {
                Board[i, j].AdjacentMines = AdjacentMines(i, j);
            });
        }

        // calculate number of bombs adjacent to a square
        private int AdjacentMines(int i, int j) {
            int mines = 0;
            ForEachNeighbor(i, j, (x, y) => {
                if (Board[x, y].Mined) {
                    mines++;
                }
            });
            return mines;
        }

        // helper to iterate over each square
        private void ForEachSquare(Action<int, int> action) {
            for (var i = 0; i < this.Height; i++) {
                for (var j = 0; j < this.Width; j++) {
                    action(i, j);
                }
            }
        }

        // returns the number of non-mined squares you failed to reveal
        public int EvaluateFitness() {
            int fitness = Height*Width;
            ForEachSquare((i, j) => {
                if (Board[i,j].Mined == true || Board[i,j].Revealed == true) {
                    fitness--;
                }
            });
            return fitness;
        }

        // check if a given index is in bounds of the board
        private bool IndexInBounds(int i, int j) {
            return i >= 0 && i < Height && j >= 0 && j < Width;
        }

        // helper to iterate over all neighbors of a square
        private void ForEachNeighbor(int i, int j, Action<int, int> action) {
            for (var x = i-1; x <= i+1; x++) {
                for (var y = j-1; y <= j+1; y++) {
                    if (IndexInBounds(x, y)) {
                        action(x, y);
                    }
                }
            }
        }

        // reveal all squares without bombs around index
        private void RevealSquaresAround(int i, int j) {
            Board[i, j].Revealed = true;
            ForEachNeighbor(i, j, (x, y) => {
                MinesweeperSquare s = Board[x, y];
                if (!s.Mined && !s.Revealed && Board[i,j].AdjacentMines == 0) {
                    RevealSquaresAround(x, y);
                }
            });
        }

        public bool PlayerDidWin() {
            for (var i = 0; i < this.Height; i++) {
                for (var j = 0; j < this.Width; j++) {
                    if (!Board[i, j].Mined && !Board[i, j].Revealed) {
                        return false;
                    }
                }
            }
            return true;
        }

        // click on a square
        public GameStatus ClickSquare(int i, int j) {
            if (!HasClickedOnce) {
                // setup the mines
                InitMines(0.05, i, j);
            }
            if (IndexInBounds(i, j)) {
                if (Board[i, j].Mined) {
                    return GameStatus.Exploded;
                }
                else {
                    RevealSquaresAround(i, j);
                    if (PlayerDidWin()) {
                        return GameStatus.Won;
                    }
                    else {
                        return GameStatus.Updated;
                    }
                }
            }
            else {
                return GameStatus.Updated;
            }
        }

        public void PrintBoard() {
			String top = "X\\Y\t";
			for (var i = 0; i < Width; i++) {
                    top+="  "+i+" ";
                }
			Console.Write(top+"\n");
            for (var i = 0; i < Height; i++) {
				Console.Write(i+"\t");
                Console.Write("|");
                for (var j = 0; j < Width; j++) {
                    String square = "";
					if (Board[i,j].Mined) {
						square = "@";
					}
                    else if (!Board[i, j].Revealed) {
                        square = "*";
                    }
                    else {
                        square = square + Board[i, j].AdjacentMines;
                    }
                    Console.Write(" " + square + " |");
                }
                Console.WriteLine();
            }
        }
    }

}