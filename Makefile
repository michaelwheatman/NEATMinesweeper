common = IPlayer.cs MinesweeperEvaluator.cs MinesweeperExperiment.cs MinesweeperSquare.cs NeatPlayer.cs RandomPlayer.cs MinesweeperBoard.cs MinesweeperGame.cs Move.cs SimpleNeatExperiment.cs

evolver: *.cs
	mcs $(common) MinesweeperEvolver.cs -r:SharpNeatLib.dll -r:SharpNeatDomains.dll -r:log4net.dll -out:Evolver.exe

random: *.cs
	mcs $(common) PlayRandom.cs -r:SharpNeatLib.dll -r:SharpNeatDomains.dll -r:log4net.dll -out:Random.exe
