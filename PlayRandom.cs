using System;
using MinesweeperLib;

class RandomPlayerProgram {
    static void Main(string[] args) {
        int boardSize = int.Parse(args[0]);
        IPlayer player = new RandomPlayer();
        MinesweeperGame game = new MinesweeperGame(boardSize);
        Console.WriteLine(game.play(player, false));
    }
}
