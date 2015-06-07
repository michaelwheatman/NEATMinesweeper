using System;
using MinesweeperLib;

class RandomPlayerProgram {
    static void Main(string[] args) {
        if (args.Length != 1 && args.Length != 2) {
            Console.WriteLine("Arguments:\nboard size\n(optional) print boards (supply 't' for true)");
            System.Environment.Exit(0);
        }
        int boardSize = int.Parse(args[0]);
        IPlayer player = new RandomPlayer();
        MinesweeperGame game = new MinesweeperGame(boardSize);
        bool printBoards = false;
        if (args.Length == 2) {
            printBoards = args[1] == "t";
        }
        Console.WriteLine(game.play(player, printBoards));
    }
}
