evolver: *.cs
	mcs *.cs -main:MinesweeperEvolver -r:SharpNeatLib.dll -r:SharpNeatDomains.dll -r:log4net.dll -out:Evolver.exe

random: *.cs
	mcs *.cs -main:PlayRandom -r:SharpNeatLib.dll -r:SharpNeatDomains.dll -r:log4net.dll -out:Random.exe