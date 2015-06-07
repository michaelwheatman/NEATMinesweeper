common = IPlayer.cs MinesweeperEvaluator.cs MinesweeperExperiment.cs MinesweeperSquare.cs NeatPlayer.cs RandomPlayer.cs MinesweeperBoard.cs MinesweeperGame.cs Move.cs SimpleNeatExperiment.cs
libs = -r:SharpNeatLib.dll -r:SharpNeatDomains.dll -r:log4net.dll

all: $(common) MinesweeperEvolver.cs PlayRandom.cs PlayAI.cs
	mcs $(common) MinesweeperEvolver.cs $(libs) -out:Evolver.exe
	mcs $(common) PlayRandom.cs $(libs) -out:Random.exe
	mcs $(common) PlayAI.cs $(libs) -out:AI.exe

evolver: $(common) MinesweeperEvolver.cs
	mcs $(common) MinesweeperEvolver.cs $(libs) -out:Evolver.exe

random: $(common) PlayRandom.cs
	mcs $(common) PlayRandom.cs $(libs) -out:Random.exe

ai: $(common) PlayAI.cs
	mcs $(common) PlayAI.cs $(libs) -out:AI.exe

clean:
	rm *.exe *.mdb