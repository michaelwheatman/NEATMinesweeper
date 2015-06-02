# NEATMinesweeper
Minesweeper implementation for testing NEAT Algorithm

[This tutorial will be helpful.](http://www.nashcoding.com/2010/07/17/tutorial-evolving-neural-networks-with-sharpneat-2-part-1/)

To run on OSX:

- [Get Mono](http://www.mono-project.com/download/)
- [Acquire SharpNeat.](http://sharpneat.sourceforge.net//) Copy the ShapNeatLib.dll from `bin` into the project directory.
- Compile: `mcs -r:SharpNeatLib.dll *.cs`
- Run .exe: `mono Minesweeper.exe`
