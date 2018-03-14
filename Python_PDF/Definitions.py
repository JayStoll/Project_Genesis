# Author Jayden Stoll
# Date March 13 2018
# Reason Creates the functions that will be used to print to the page

from GetFileInfo import words

# Used to align the words on the page
leftAlign = 34
rightAlign = 450
# used when aligning information with the title
QTYAlign = leftAlign + 200
rateAlign = leftAlign + 300
taxAlign = leftAlign + 375
amountAlign = leftAlign + 450


def ChangeFont(num, c):
    if num == 1:
        c.setFont('Helvetica-Bold', 13)
    if num == 2:
        c.setFont('Helvetica', 12)
    if num == 3:
        c.setFont('Helvetica-Bold', 15)


# Super function - used to print all of the other functions to make it less work in CreatePDF.py script
def PrintPDF(c):
    darwinAddress(c)
    ClientAddress(c)
    TitleBar(c)
    totalsLable(c)
    printTotals(c)


def darwinAddress(c):
    ChangeFont(1, c)
    c.drawString(leftAlign, 800, "Darwin Eitzen Mechanical")
    ChangeFont(2, c)
    c.drawString(leftAlign, 785, "Box 41")
    c.drawString(leftAlign, 770, "403-352-1560")
    c.drawString(leftAlign, 755, "GST/HST Registration No: 110074697RT0001")


# TODO figure out the rest of the client information needed to complete this information
def ClientAddress(c):
    ChangeFont(1, c)
    c.drawString(leftAlign, 715, "INVOICE TO")
    ChangeFont(2, c)
    c.drawString(leftAlign, 700, words[0] + " " + words[1])  # client first and last name


# TODO figure out how to change font better
# def ClientInvoiceInfo(c):


def TitleBar(c):
    c.drawString(leftAlign, 590, "ACTIVITY")
    c.drawString(QTYAlign, 590, "QTY")
    c.drawString(rateAlign, 590, "RATE")
    c.drawString(taxAlign, 590, "TAX")
    c.drawString(amountAlign, 590, "AMOUNT")


def totalsLable(c):
    ChangeFont(1, c)
    c.drawString(QTYAlign + 43, 350, "SUBTOTAL")
    c.drawString(QTYAlign + 43, 335, "GST/HST @ 5%")
    c.drawString(QTYAlign + 43, 320, "TOTAL")
    c.drawString(QTYAlign + 43, 305, "BALANCE DUE")

# TODO get the totals instead of hard coding them
def printTotals(c):
    ChangeFont(2, c)
    c.drawString(amountAlign, 350, "1,350.56")
    c.drawString(amountAlign, 335, "67.53")
    c.drawString(amountAlign, 320, "1,418.09")
    ChangeFont(3, c)
    c.drawString(amountAlign, 305, "1,418.09")
