minesweepaer: *.cs
	mcs *.cs -r:SharpNeatLib.dll -r:SharpNeatDomains.dll -r:log4net.dll -o Minesweeper.exe
