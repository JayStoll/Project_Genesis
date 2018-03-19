# Author Jayden Stoll
# Date March 13 2018
# Reason Gets the information from the file and gives it to the rest of the script
# from curses.ascii import isdigit

ClientInfo = 'clientInfo.txt'
LabourInfo = 'labourInfo.txt'
partInfo = 'partInfo.txt'

# Get the client information
with open(ClientInfo) as f:
    lines = f.readlines()
firstClientPageSort = []
clientName = []
totalClientInfo = []
for s in lines:
    firstClientPageSort += s.split(".")
# Used to get just the first and last name of the client
for t in firstClientPageSort:
    clientName += t.split()


# Get labour information
with open(LabourInfo) as f:
    lines = f.readlines()
labourInformation = []
# split the information from the file at a new line character
for s in lines:
    labourInformation += s.split('\n')
index = 0
hoursWorked = 0
rate = 0
tax = ''
firstDigit = True
while index < len(labourInformation):
    x = labourInformation[index]
    # check to see if the current index is a blank line - if it is delete it
    if x == '':
        labourInformation.remove('')
    if firstDigit is True:
        try:
            value = int(labourInformation[index])
        except ValueError:
            pass
        else:
            # put the information into a variable then remove it
            hoursWorked = value
            firstDigit = False
            labourInformation.remove(labourInformation[index])
    if firstDigit is False:
        try:
            value = float(labourInformation[index])
        except ValueError:
            pass
        else:
            rate = value
            labourInformation.remove(labourInformation[index])
            labourInformation.remove('')
    if labourInformation[index] == labourInformation[-1]:
        tax = labourInformation[index]
        labourInformation.remove(labourInformation[index])
        labourInformation.remove('')
    index += 1


# Part information
with open(partInfo) as f:
    lines = f.readlines()
partInformation = []
for s in lines:
    partInformation += s.split('\n')
i = 0
qtyAmount = 0
rate1 = 0
tax1 = ''
firstNum = True
while i < len(partInformation):
    if partInformation[i] == '':
        partInformation.remove('')
    if firstNum is True:
        try:
            val = int(partInformation[i])
        except ValueError:
            pass
        else:
            qtyAmount = val
            firstNum = False
            partInformation.remove(partInformation[i])
            partInformation.remove('')
    if firstNum is False:
        try:
            val = float(partInformation[i])
        except ValueError:
            pass
        else:
            rate1 = val
            partInformation.remove(partInformation[i])
            partInformation.remove('')
    if partInformation[i] == partInformation[-1]:
        tax1 = partInformation[i]
        partInformation.remove(partInformation[-1])
    i += 1
