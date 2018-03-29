# Author Jayden Stoll
# Date March 13 2018
# Reason Gets the information from the file and gives it to the rest of the script
# from curses.ascii import isdigit

# TODO clean this script up

ClientInfo = 'clientInfo.txt'
invoiceInfo = 'invoiceInfo.txt'
LabourInfo = 'labourInfo.txt'
partInfo = 'partInfo.txt'

# error catch - used to print to the application if the files were found or not
try:
    # Get the client information
    with open(ClientInfo) as f:
        lines = f.readlines()
    firstClientPageSort = []
    clientName = []
    for s in lines:
        firstClientPageSort += s.split(".")
    # Used to get just the first and last name of the client
    for t in firstClientPageSort:
        clientName += t.split()

    # Get the invoice information
    with open(invoiceInfo) as f:
        lines = f.readlines()
    invoiceInformation = []
    for s in lines:
        invoiceInformation += s.split('\n')
    j = 0
    taxPercent = 0
    while j < len(invoiceInformation):
        if invoiceInformation[j] == '':
            invoiceInformation.remove('')
        try:
            val1 = float(invoiceInformation[j])
        except ValueError:
            pass
        else:
            taxPercent = val1
        j += 1

    # Get labour information
    # TODO get the vehicle from the file and print it at the bottom of the invoice
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
    vehicle = ''
    firstNum = True
    isVehicle = False
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
                isVehicle = True
        if isVehicle is True:
            vehicle = partInformation[i]
            partInformation.remove(partInformation[i])
            partInformation.remove('')
        if partInformation[i] == partInformation[-1]:
            tax1 = partInformation[i]
            partInformation.remove(partInformation[-1])
        i += 1
except:
    print("Error one or more files not found!")
