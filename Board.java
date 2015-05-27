import java.util.*;
import java.io.*;

public class Board {
    // board private vars
	private char[][] board;
    private int xdim, ydim, size, fitness, numMines;
    private Random rgen;

    // create a board with the given dimensions and number of mines
    public Board(int xdim, int ydim, int numMines) {
        this.xdim = xdim;
        this.ydim = ydim;
        this.numMines = numMines;
		this.size = xdim*ydim;
		this.fitness = this.size - numMines;
		this.rgen = new Random();
        this.board = new char[xdim][ydim];
        // initially fill the grid with zeros
        for (int i=0; i<xdim; i++) {
            for (int j=0; j<ydim; j++) {
                board[i][j] = ' ';
			}
		}
    }
	
	public int getFitness() {
		return this.fitness;
	}
	
	public void placeMines() {
		int mineLocation, i;
		for (i=0; i<numMines; i++){
			mineLocation = rgen.nextInt(size);
			
			// If I reimplement this in C, do something smart like only get the address
			// of the cell once and use it twice.
			if (board[mineLocation/xdim][mineLocation%ydim] == ' ') {
				board[mineLocation/xdim][mineLocation%ydim] = '*';
			} else {
				i--;
			}
		}
	}
	
	public void endGame() {
		System.out.println("😵 You lost. Your Fitness was: " + fitness);
	}
	
	public void calculateAdjacentMines(int x, int y) {
		int count = 0;
		for (int i = x-1; i < x+2; i++) {
			for (int j = y-1; j < y+2; j++) {
				if (i == x && j == y) {
					continue;
				} else {
					try {
						if (board[i][j] == '*') {
							count++;
						}
					}
					catch (IndexOutOfBoundsException e) {
						continue;
					}
				}
			}
		}

		board[x][y] = Integer.toString(count).charAt(0);
		if (count == 0) {
			handleAdjacent(x,y);
		}
	}
	
	public void handleAdjacent(int x, int y) {
		for (int i = x-1; i < x+2; i++) {
			for (int j = y-1; j < y+2; j++) {
				try {
					if (i == x && j == y) {
						continue;
					} else if (board[i][j] == ' ') {
							click(i,j);
					}
				} catch (IndexOutOfBoundsException e) {
					continue;
				}
			}
		}
	}
	
	public int click(int x, int y) {
		if (board[x][y] == '*') {
			board[x][y] = '!';
			endGame();
			return 1;
		}
		else if (board[x][y] == ' ')
			{
			calculateAdjacentMines(x,y);
			fitness--;
		} else {
			System.out.println("You've already discovered this cell");
		}
		return 0;
	}
	
    public void print() {
        print(System.out);
    }

    // print the current state of the grid, showing blocks and the dozer 
    // pointing in the correct direction
    public void print(PrintStream os) {
        for (int y=0; y<ydim; y++) {
            os.print("|");
			String line = "\n";
            for (int x=0; x<xdim; x++) {
                char out = board[x][y];
				line+="  - ";
				if (out == '*') {
					out = ' ';
				}
                os.print(" " + out+" |");
            }
            os.println (line);
        }
        os.println();
		os.println("Fitness = " + fitness);
    }

	public static void main(String[] args) {
		Board board = new Board(10,10,10);
		board.placeMines();
		board.print();
		Scanner reader = new Scanner(System.in);
		int x,y;
		int loop = 0;
		while (loop == 0) {
			System.out.println("Enter the coordinates");
			x = reader.nextInt();
			y = reader.nextInt();
			loop = board.click(x,y);
			board.print();
			if (board.getFitness() == 0) {
				System.out.println(" 😎 You Win!");
				loop = 1;
			}
		}
	}
}