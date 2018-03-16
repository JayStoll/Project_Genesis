# Author Jayden Stoll
# Date March 13 2018
# Reason Gets the information from the file and gives it to the rest of the script

# TODO Figure out how to read from single file

ClientInfo = 'clientInfo.txt'
LabourInfo = 'labourInfo.txt'

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
for l in lines:
    totalClientInfo += l.split(".")


# Get labour information
with open(LabourInfo) as f:
    lines = f.readlines()
labourInformation = []
for s in lines:
    labourInformation += s.split('*')
