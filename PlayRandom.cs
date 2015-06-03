using System;
using MinesweeperLib;

class RandomPlayerProgram {
    static void Main(string[] args) {
        IPlayer player = new RandomPlayer();
        MinesweeperGame game = new MinesweeperGame();
        Console.WriteLine(game.play(player, true));
    }
}
