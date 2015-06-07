# Remove existing results file 
# Play 100 rounds using the current champion
# Store the results in file
rm randomPlayer.txt
for i in {1..100}
do
	mono Random.exe >> randomPlayer.txt
done