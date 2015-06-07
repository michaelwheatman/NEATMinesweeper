# NEATMinesweeper
by Michael Wheatman, Brian Charous, David Pickart, and Oliver Heywood

## Evolutionary Computation and Artificial Life Final Project
Neural Network based Minesweeper player.

## Goal
Our goal in this project is to create a neural network based minesweeper player. The player should be able to outperform a random player.
## Description of Evolutionary Algorithm
We decided to use the NEAT algorithm. NEAT stands for Neuroevolution of Augmenting Topologies. The algorithm works by evolving artificial neural networks by evolving both the structure and weighting parameters of the network. The process of evolving the networks strikes a balance between finding individuals with the best fitness and maintaining diversity.
### Representation and Initialization
We represent our evolved player as a neural network with 25 inputs and 25 outputs. The minesweeper board is a 5 x 5 grid, so each input and output of the neural network corresponds to a position on the board. The network accepts the current board state and returns a list of values for board positions. The player than clicks the unclicked cell with the highest value.  
### Parameters
Be chose to represent the board as a 5 x 5 grid.
We store the best neural network as an xml file called minesweeper_champion.xml. We configure the evolver to favor complexity in the neural network over simplicity by entering a complexity threshold of 2000.
### How We Chose Parameters
We chose the grid size for two reasons. For one, five by five is the smallest grid that remains at least somewhat interesting. Additionally, a five by five grid is required to analyze with certainty if a square is able to be clicked.
We settled on the complexity threshold via trial and error.
### A Good Individual
<!-- language: lang-xml -->
	<Root>
	  <ActivationFunctions>
	    <Fn id="0" name="SteepenedSigmoid" prob="1" />
	  </ActivationFunctions>
	  <Networks>
	    <Network id="3994" birthGen="49" fitness="1226">
	      <Nodes>
	        <Node type="bias" id="0" />
	        <Node type="in" id="1" />
	        <Node type="in" id="2" />
	        <Node type="in" id="3" />
	        <Node type="in" id="4" />
	        <Node type="in" id="5" />
	        <Node type="in" id="6" />
	        <Node type="in" id="7" />
	        <Node type="in" id="8" />
	        <Node type="in" id="9" />
	        <Node type="in" id="10" />
	        <Node type="in" id="11" />
	        <Node type="in" id="12" />
	        <Node type="in" id="13" />
	        <Node type="in" id="14" />
	        <Node type="in" id="15" />
	        <Node type="in" id="16" />
	        <Node type="in" id="17" />
	        <Node type="in" id="18" />
	        <Node type="in" id="19" />
	        <Node type="in" id="20" />
	        <Node type="in" id="21" />
	        <Node type="in" id="22" />
	        <Node type="in" id="23" />
	        <Node type="in" id="24" />
	        <Node type="in" id="25" />
	        <Node type="out" id="26" />
	        <Node type="out" id="27" />
	        <Node type="out" id="28" />
	        <Node type="out" id="29" />
	        <Node type="out" id="30" />
	        <Node type="out" id="31" />
	        <Node type="out" id="32" />
	        <Node type="out" id="33" />
	        <Node type="out" id="34" />
	        <Node type="out" id="35" />
	        <Node type="out" id="36" />
	        <Node type="out" id="37" />
	        <Node type="out" id="38" />
	        <Node type="out" id="39" />
	        <Node type="out" id="40" />
	        <Node type="out" id="41" />
	        <Node type="out" id="42" />
	        <Node type="out" id="43" />
	        <Node type="out" id="44" />
	        <Node type="out" id="45" />
	        <Node type="out" id="46" />
	        <Node type="out" id="47" />
	        <Node type="out" id="48" />
	        <Node type="out" id="49" />
	        <Node type="out" id="50" />
	      </Nodes>
	      <Connections>
	        <Con id="79" src="1" tgt="29" wght="1.8236978491768241" />
	        <Con id="98" src="1" tgt="48" wght="-3.6572724207161733" />
	        <Con id="110" src="2" tgt="35" wght="3.4294551216058409" />
	        <Con id="121" src="2" tgt="46" wght="0.86504699662327766" />
	        <Con id="124" src="2" tgt="49" wght="-0.788778896291023" />
	        <Con id="157" src="4" tgt="32" wght="-2.1856011496856809" />
	        <Con id="158" src="4" tgt="33" wght="-5" />
	        <Con id="170" src="4" tgt="45" wght="-3.2089704530259895" />
	        <Con id="181" src="5" tgt="31" wght="-2.0499415043741465" />
	        <Con id="194" src="5" tgt="44" wght="2.253386227302614" />
	        <Con id="207" src="6" tgt="32" wght="3.7916759932966704" />
	        <Con id="240" src="7" tgt="40" wght="-2.4081872077658772" />
	        <Con id="261" src="8" tgt="36" wght="4.0013220114633441" />
	        <Con id="271" src="8" tgt="46" wght="0.5426889567986628" />
	        <Con id="294" src="9" tgt="44" wght="-4.838166830580878" />
	        <Con id="305" src="10" tgt="30" wght="1.7833991901224491" />
	        <Con id="326" src="11" tgt="26" wght="2.5331369182094932" />
	        <Con id="349" src="11" tgt="49" wght="1.4954507770016789" />
	        <Con id="379" src="13" tgt="29" wght="-4.2677580611780286" />
	        <Con id="407" src="14" tgt="32" wght="-0.24935462977737188" />
	        <Con id="411" src="14" tgt="36" wght="-4.0342844789847732" />
	        <Con id="439" src="15" tgt="39" wght="4.8131109280283733" />
	        <Con id="451" src="16" tgt="26" wght="3.2391401185065507" />
	        <Con id="495" src="17" tgt="45" wght="-2.3616682039573789" />
	        <Con id="513" src="18" tgt="38" wght="0.50697089476323276" />
	        <Con id="516" src="18" tgt="41" wght="-4.5178502872251673" />
	        <Con id="549" src="19" tgt="49" wght="-4.8895017262102769" />
	        <Con id="568" src="20" tgt="43" wght="0.41897411666084805" />
	        <Con id="608" src="22" tgt="33" wght="3.1111826320362419" />
	        <Con id="619" src="22" tgt="44" wght="-4.0650202679752114" />
	        <Con id="654" src="24" tgt="29" wght="-0.90245186784916454" />
	        <Con id="666" src="24" tgt="41" wght="0.51185904617439681" />
	      </Connections>
	    </Network>
	  </Networks>
	</Root>

## Original Hypothesis
We know from playing Minesweeper ourselves that it is possible to build a Neural Network that can play Minesweeper. After all, human brains are just very large neural networks. Additionally, we know that it is possible to build a AI solver for Minesweeper that works with a high degree of success. We thus originally hypothesized that our evolved solver would be better than a random player. We hoped that it could perform as well as a deterministic approach.
### Compared To Random
To test our evolved player, we had it and a random player attempt 100 randomly generated boards with a board size of 25 cells. Using a fitness evaluation based on the number of squares revealed, the evolved player attained an average fitness of 18.31, which means that it found 13 unmined squares before losing on average. The random player had an average fitness of 13.99, which means that it found 9 squares on average before losing on average. This means that our evolved player performed 30.9% better than random.

We also attempted a fitness evaluation based on the number of clicks the player makes. Using this evaluation with a board size of 25 cells, the evolved player averaged 6.28 clicks over 100 trials while the random player averaged 3.71 clicks. This means that our evolved player performed 69.3% better than random. Using click count evaluation with a board size of 100 cells, the evolved player averaged 4.94 clicks over 100 trials while the random player averaged 3.08 clicks. This means that out evolved player performed 60.4% better than random.

| Board Size| Fitness Eval Type | Random | Evolved | Evolved Better Than Random By | 
| ----------|-------------------| -------|---------|-------------------|
| 25 Cells  | Squares Revealed  | 13.99  | 18.31   | 30.9%             |
| 25 Cells  | Clicks            | 3.71   | 6.28    | 69.3%             |
| 100 Cells | Clicks            | 3.08   | 4.94    | 60.4%             |

## Thoughts on the Project
### How Well did we succeed
We were successful at evolving players that were better than random. However, from research and experience, we know that there are deterministic algorithms that are able to solve minesweeper boards to a greater degree.
### Problems Encountered
Our NEAT implementation seems to avoid increasing the number of hidden nodes. We attempted to address this by raising the complexity threshold but this didn't seem to have any effect.

## Sources
We used [this tutorial](http://www.nashcoding.com/2010/07/17/tutorial-evolving-neural-networks-with-sharpneat-2-part-1/): http://www.nashcoding.com/2010/07/17/tutorial-evolving-neural-networks-with-sharpneat-2-part-1/

We used the [SharpNEAT](http://sharpneat.sourceforge.net/) C# Library: http://sharpneat.sourceforge.net/

We also used the following sources:

Randall, T., Cowling, P., Baker, R., & Jiang, P. (2009). Using neural networks for strategy selection in real-time strategy games. In Symposium on AI &amp.

[NEAT Wikipedia Page](http://en.wikipedia.org/wiki/Neuroevolution_of_augmenting_topologies):
http://en.wikipedia.org/wiki/Neuroevolution_of_augmenting_topologies

## How to Run
On OS X:

- [Get Mono](http://www.mono-project.com/download/): http://www.mono-project.com/download/
- Compile: `make`
- Run the neural network `mono Evolver.exe <board size>`
- Press `Enter` to end the evolver when the fitness has stabilized.
- To run Random Player `mono Random.exe <board size> <optional flag 't' to print boards>`
- To run Evolved Player `mono AI.exe minesweeper_champion.xml <board size> <optional flag 't' to print boards>`
- For more complicated analysis, you can run multiple trials, average results, change board size, etc.
- Example of how to run multiple trials of Evolved Player on a 5x5 board and print average fitness `./aiTest.sh 5 && cat aiPlayer.txt | python3 average.py`
