using System;
using System.IO;
using System.Xml;
using MinesweeperLib;
using SharpNeat.Core;
using SharpNeat.Genomes.Neat;
using SharpNeat.Phenomes;
using log4net.Config;

class AIProgram {

    MinesweeperExperiment experiment;

    public AIProgram(int boardSize) {
        experiment = new MinesweeperExperiment(boardSize);
        // Initialise log4net (log to console).
        XmlConfigurator.Configure(new FileInfo("log4net.properties"));

        // Load config XML.
        XmlDocument xmlConfig = new XmlDocument();
        xmlConfig.Load("minesweeper.config.xml");
        experiment.Initialize("Minesweeper", xmlConfig.DocumentElement);

    }

    private IBlackBox readFromFile(string filename, int ann_ins_outs) {
        FileStream fs = new FileStream(filename, FileMode.Open);
        XmlReader xr = XmlReader.Create(fs);
        NeatGenomeFactory factory = new NeatGenomeFactory(ann_ins_outs, ann_ins_outs);
        var genome = NeatGenomeXmlIO.ReadCompleteGenomeList(xr, false, factory)[0];
        var genomeDecoder = experiment.CreateGenomeDecoder();
        var phenome = genomeDecoder.Decode(genome);
        return phenome; 
    } 

    static void Main(string[] args) {
        if (args.Length != 2 && args.Length != 3) {
            Console.WriteLine(String.Join(Environment.NewLine,
                "Arguments:","evolved player xml filename",
                "board size (must match board size used while evolving)",
                    "(optional) print boards (supply 't' for true)"));
            System.Environment.Exit(0);
        }
        string filename = args[0];
        int boardSize = int.Parse(args[1]);
        AIProgram prog = new AIProgram(boardSize);
        IBlackBox brain = prog.readFromFile(filename, boardSize*boardSize);
        IPlayer player = new NeatPlayer(brain);
        MinesweeperGame game = new MinesweeperGame(boardSize);
        bool printBoards = false;        
        if (args.Length == 3) {
            printBoards = args[2] == "t";
        }
        Console.WriteLine(game.play(player, printBoards));
    }
}
