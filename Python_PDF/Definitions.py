# Author Jayden Stoll
# Date March 13 2018
# Reason Creates the functions that will be used to print to the page

from GetFileInfo import firstClientPageSort, totalClientInfo, labourInformation

taxRate = '5'  # TODO get this from a file and not hard coded

# Used to align the words on the page
leftAlign = 34
rightAlign = 450
# used when aligning information with the title
QTYAlign = leftAlign + 200
rateAlign = leftAlign + 300
taxAlign = leftAlign + 375
amountAlign = leftAlign + 450

clientArr = [0, 670, 655, 640, 625, 610, 595]
labourInfoArr = [535, 520, 505, 490, 475, 460, 445, 430, 415, 400]  # TODO expand this array with more numbers


def ChangeFont(num, c):
    if num == 1:
        c.setFont('Helvetica-Bold', 13)
    if num == 2:
        c.setFont('Helvetica', 10)
    if num == 3:
        c.setFont('Helvetica-Bold', 15)


# Super function - used to print all of the other functions to make it less work in CreatePDF.py script
def PrintPDF(c):
    darwinAddress(c)
    ClientAddress(c)
    ClientInvoiceInfo(c)
    TitleBar(c)
    FillLabourTime(c)
    totalsLable(c)
    printTotals(c)


def darwinAddress(c):
    ChangeFont(1, c)
    c.drawString(leftAlign, 800, "Darwin Eitzen Mechanical")
    ChangeFont(2, c)
    c.drawString(leftAlign, 785, "Box 41")
    c.drawString(leftAlign, 770, "Linden AB T0M 1J0")
    c.drawString(leftAlign, 755, "403-352-1560")
    c.drawString(leftAlign, 740, "GST/HST Registration No: 110074697RT0001")


def ClientAddress(c):
    ChangeFont(1, c)
    c.drawString(leftAlign, 700, "INVOICE TO")
    ChangeFont(2, c)
    c.drawString(leftAlign, 685, firstClientPageSort[0])  # client first and last name
    i = 1
    while i < len(totalClientInfo):
        c.drawString(leftAlign, clientArr[i], totalClientInfo[i])
        i += 1


def ClientInvoiceInfo(c):
    ChangeFont(1, c)
    c.drawString(taxAlign, 700, "INVOICE #")
    c.drawString(taxAlign, 685, "DATE")
    c.drawString(taxAlign, 670, "DUE DATE")
    c.drawString(taxAlign, 655, "TERMS")
    ChangeFont(2, c)


# def FillInvoiceInformation(c):

def TitleBar(c):
    c.drawString(leftAlign, 575, "ACTIVITY")
    c.drawString(QTYAlign, 575, "QTY")
    c.drawString(rateAlign, 575, "RATE")
    c.drawString(taxAlign, 575, "TAX")
    c.drawString(amountAlign, 575, "AMOUNT")


# TODO fill the information from a single file
def FillLabourTime(c):
    ChangeFont(1, c)
    c.drawString(leftAlign, 550, "Labour")
    ChangeFont(2, c)
    i = 0
    while i < len(labourInformation):
        c.drawString(leftAlign, labourInfoArr[i], labourInformation[i])
        i += 1


def totalsLable(c):
    ChangeFont(1, c)
    c.drawString(QTYAlign + 43, 100, "SUBTOTAL")
    c.drawString(QTYAlign + 43, 85, "GST/HST @ " + taxRate + "%")
    c.drawString(QTYAlign + 43, 70, "TOTAL")
    c.drawString(QTYAlign + 43, 55, "BALANCE DUE")
    ChangeFont(2, c)


# TODO get the totals instead of hard coding them
def printTotals(c):
    c.drawString(amountAlign, 100, "1,350.56")
    c.drawString(amountAlign, 85, "67.53")
    c.drawString(amountAlign, 70, "1,418.09")
    ChangeFont(3, c)
    c.drawString(amountAlign, 55, "1,418.09")
