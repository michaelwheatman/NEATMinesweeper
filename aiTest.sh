rm aiPlayer.txt
for i in {1..100}
do
	mono AI.exe minesweeper_champion.xml >> aiPlayer.txt
done