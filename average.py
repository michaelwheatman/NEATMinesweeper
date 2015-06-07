import fileinput
sum = 0
count = 0
for line in fileinput.input():
	sum += int(line)
	count += 1
print(sum/count)
