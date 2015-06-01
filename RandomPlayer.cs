using System;

namespace MinesweeperLib {
    public class RandomPlayer {
    	static public void Main () {
        	MinesweeperBoard b = new MinesweeperBoard(10, 10);
        	var random = new Random(); 
        	while (true) {
                var x = random.Next(10);
                var y = random.Next(10);
                if (b.Board[x,y].Revealed == false) {
                	Console.WriteLine("The Random Square "+x+" "+y+" is clicked...");
                	GameStatus status = b.ClickSquare(x, y);
                	b.printBoard();
                	switch (status) {
                    	case GameStatus.Exploded: {
                        	Console.WriteLine("you died");
                        	Console.WriteLine("Random player recieved a fitness of "+b.EvaluateFitness());
                        	return;
                    	}
                    	case GameStatus.Won: {
                        	Console.WriteLine("you won!");
                        	Console.WriteLine("Random player recieved a fitness of "+b.EvaluateFitness());
                        	return;
                    	}
                    	case GameStatus.Updated: {
                    		continue;
                    	}
                	}
                }	
            }    
    	}
    }
}