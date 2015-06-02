using System;

namespace MinesweeperLib
{
    /// <summary>
    /// Interface that all Minesweeper agents must define.
    /// </summary>
    public interface IPlayer {
        Move GetMove(MinesweeperSquare[,] board);
    }
}