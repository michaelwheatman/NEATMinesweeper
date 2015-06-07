using System;

namespace MinesweeperLib {
    /// <summary>
    /// Simple Minesweeper Cell class
    /// </summary>
    public class MinesweeperSquare {
        public int AdjacentMines {get; set;}
        public bool Mined {get; set;}
        public bool Revealed {get; set;}

        public MinesweeperSquare() {
            this.Mined = false;
            this.Revealed = false;
            this.AdjacentMines = 0;
        }
    }
}