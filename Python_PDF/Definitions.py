# Author Jayden Stoll
# Date March 13 2018
# Reason Creates the functions that will be used to print to the page

import datetime

from GetFileInfo import firstClientPageSort, labourInformation, hoursWorked, rate, tax
from GetFileInfo import partInformation, qtyAmount, rate1, tax1, invoiceInformation, taxPercent
from calculations import labourAmount, subtotal

taxRate = taxPercent

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
        c.setFont('Helvetica', 10)
    if num == 3:
        c.setFont('Helvetica-Bold', 15)


# Super function - used to print all of the other functions to make it less work in CreatePDF.py script
def PrintPDF(c):
    darwinAddress(c)
    ClientAddress(c)
    ClientInvoiceInfo(c)
    FillInvoiceInformation(c)
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
    ca = 670
    while i < len(firstClientPageSort):
        c.drawString(leftAlign, ca, firstClientPageSort[i])
        ca -= 15
        i += 1


def ClientInvoiceInfo(c):
    ChangeFont(1, c)
    c.drawString(taxAlign, 700, "INVOICE #")
    c.drawString(taxAlign, 685, "DATE")
    c.drawString(taxAlign, 670, "DUE DATE")
    c.drawString(taxAlign, 655, "TERMS")
    ChangeFont(2, c)


def FillInvoiceInformation(c):
    c.drawString(taxAlign + 75, 700, invoiceInformation[0])
    c.drawString(taxAlign + 75, 685, datetime.datetime.today().strftime('%d-%m-%Y'))
    c.drawString(taxAlign + 75, 670, invoiceInformation[1])  # TODO look at making this calculated automatically
    c.drawString(taxAlign + 75, 655, invoiceInformation[2])


def TitleBar(c):
    c.drawString(leftAlign, 575, "ACTIVITY")
    c.drawString(QTYAlign, 575, "QTY")
    c.drawString(rateAlign, 575, "RATE")
    c.drawString(taxAlign, 575, "TAX")
    c.drawString(amountAlign, 575, "AMOUNT")


def FillLabourTime(c):
    ChangeFont(1, c)
    c.drawString(leftAlign, 550, "Labour")
    ChangeFont(2, c)
    i = 0
    align = 535
    partAlign = 0
    while i < len(labourInformation):
        c.drawString(leftAlign, align, labourInformation[i])
        align -= 15
        partAlign = align
        i += 1
    c.drawString(QTYAlign, 550, str(hoursWorked))
    c.drawString(rateAlign, 550, str("%.2f" % rate))
    c.drawString(taxAlign, 550, tax)
    c.drawString(amountAlign, 550, str("%.2f" % labourAmount))
    # Fill the part information
    ChangeFont(1, c)
    c.drawString(leftAlign, align, "Parts")
    ChangeFont(2, c)
    index = 0
    while index < len(partInformation):
        partAlign -= 15
        c.drawString(leftAlign, partAlign, partInformation[index])
        index += 1
    c.drawString(QTYAlign, align, str(qtyAmount))
    c.drawString(rateAlign, align, str(rate1))
    c.drawString(taxAlign, align, tax1)
    c.drawString(amountAlign, align, str(rate1))  # The rate is already calculated in the C# application


def totalsLable(c):
    ChangeFont(1, c)
    c.drawString(QTYAlign + 43, 100, "SUBTOTAL")
    c.drawString(QTYAlign + 43, 85, "GST/HST @ " + str(taxRate * 100) + "%")
    c.drawString(QTYAlign + 43, 70, "TOTAL")
    c.drawString(QTYAlign + 43, 55, "BALANCE DUE")
    ChangeFont(2, c)


def printTotals(c):
    c.drawString(amountAlign, 100, str(subtotal))
    taxAmount = taxRate * subtotal
    c.drawString(amountAlign, 85, str("%.2f" % taxAmount))
    total = taxAmount + subtotal
    c.drawString(amountAlign, 70, str("%.2f" % total))
    ChangeFont(3, c)
    c.drawString(amountAlign, 55, str("%.2f" % total))
