'''
Michael Wheatman
2015
Minesweeper Game for NEAT Algorithm tests
'''


import random
import sys
 
class Board:
	def __init__(self, size, numMines):
		self.board = [[' ' for x in range(size)] for x in range(size)]
		self.size = size
		self.fitness = size**2 - numMines
		self.numMines = numMines

	def getBoard(self):
		return self.board
	
	def getSize(self):
		return self.size
	
	def getFitness(self):
		return self.fitness

	def placeMines(self):
		for i in range(self.numMines):
			mineLocation = random.randrange(self.size**2)
			if self.board[mineLocation/self.size][mineLocation%self.size] == ' ':
				self.board[mineLocation/self.size][mineLocation%self.size] = '*'
			else:
				i-=1

	def endGame(self):
		print "You lost. Your Fitness was: " + self.fitness

	def calculateAdjacentMines(self, x, y):
		count = 0
		for i,j in [[x-1, y-1], [x-1,y] , [x-1, y+1],
					[x, y-1], [x, y+1],
					[x+1, y-1], [x+1,y] , [x+1, y+1]]:
			if i>-1 and j >-1 and i<10 and j < 10:
				if self.board[i][j] == '*':
					count+=1
		if count == 0:
			self.board[x][y] = count
			self.handleAdjacent(x,y)
		else:
			self.board[x][y] = count

	def handleAdjacent(self, x, y):
		for i,j in [[x-1, y-1], [x-1,y] , [x-1, y+1],
					[x, y-1], [x, y+1],
					[x+1, y-1], [x+1,y] , [x+1, y+1]]:
			if i>-1 and j >-1 and i<10 and j < 10:
				if self.board[i][j] == ' ':
						self.click(i,j)

	def click(self, x, y):
		if self.board[x][y] == '*':
			self.board[x][y] = '!'
			self.endGame()
			return 1
		elif self.board[x][y] == ' ':
			self.fitness-=1
			self.calculateAdjacentMines(x,y)
			
		else:
			print "You've already discovered this cell"
		return 0
	
	def initialClick(self,x,y):
		self.board[x][y] = '_'
		self.placeMines()
		self.fitness-=1
		self.calculateAdjacentMines(x,y)

	def printBoard(self):
		header = "y \\ x\t"
		for i in range(self.size):
			header+="  "+`i`+ " "
		print header
		for y in range(self.size):
			sys.stdout.write(`y`+"\t"+ "|")
			line = "\n\t"
			for x in range(self.size):
				out = str(self.board[x][y])
				line+="  - "
				if out == '*':
					out = '*'
				sys.stdout.write(" "+out+" |")
			print line
		print self.fitness

def main():
	board = Board(10,3)
	loop = 0
	started = 0
	while loop == 0:
		board.printBoard()
		coords = raw_input('Enter the coordinates: ').split()
		x = int(coords[0])
		y = int(coords[1])
		if started == 0:
			board.initialClick(x,y)
		else:
			loop = board.click(x,y);
		if board.getFitness() == 0:
			print "You Win!"
			loop = 1

if __name__ == "__main__":
	main()
