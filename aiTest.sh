# Remove existing results file 
# Play 100 rounds using the current champion
# Store the results in file
rm aiPlayer.txt
for i in {1..100}
do
	mono AI.exe minesweeper_champion.xml $1 >> aiPlayer.txt
done