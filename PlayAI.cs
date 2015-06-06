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

    public AIProgram() {
        experiment = new MinesweeperExperiment();
        // Initialise log4net (log to console).
        XmlConfigurator.Configure(new FileInfo("log4net.properties"));

        // Load config XML.
        XmlDocument xmlConfig = new XmlDocument();
        xmlConfig.Load("minesweeper.config.xml");
        experiment.Initialize("Minesweeper", xmlConfig.DocumentElement);

    }

    private IBlackBox readFromFile(string filename) {
        FileStream fs = new FileStream(filename, FileMode.Open);
        XmlReader xr = XmlReader.Create(fs);
        NeatGenomeFactory factory = new NeatGenomeFactory(25, 25);
        var genome = NeatGenomeXmlIO.ReadCompleteGenomeList(xr, false, factory)[0];
        var genomeDecoder = experiment.CreateGenomeDecoder();
        var phenome = genomeDecoder.Decode(genome);
        return phenome; 
    } 

    static void Main(string[] args) {
        string filename = args[0];
        AIProgram prog = new AIProgram();
        IBlackBox brain = prog.readFromFile(filename);
        IPlayer player = new NeatPlayer(brain);
        MinesweeperGame game = new MinesweeperGame();
        Console.WriteLine(game.play(player, false));
        // IPlayer player = new RandomPlayer();
        // MinesweeperGame game = new MinesweeperGame();
        // Console.WriteLine(game.play(player, true));
    }
}
