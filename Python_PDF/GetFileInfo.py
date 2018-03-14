# Author Jayden Stoll
# Date March 13 2018
# Reason Gets the information from the file and gives it to the rest of the script

fileName = 'test.txt'  # change this to the actual file we will be reading from

with open(fileName) as f:
    lines = f.readlines()

words = []
for s in lines:
    words += s.split()