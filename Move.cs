using System;

namespace MinesweeperLib
{
    /// <summary>
    /// Stores the [x,y] location of a Minesweeper move.
    /// </summary>
    public class Move
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Move(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}