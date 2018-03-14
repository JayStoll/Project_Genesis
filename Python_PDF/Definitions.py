# Author Jayden Stoll
# Date March 13 2018
# Reason Creates the functions that will be used to print to the page

from GetFileInfo import words


leftAlign = 34
rightAlign = 450


def PrintPDF(c):
    darwinAddress(c)
    ClientAddress(c)


def ChangeFont(num, c):
    if num == 1:
        c.setFont('Helvetica-Bold', 13)
    if num == 2:
        c.setFont('Helvetica', 12)


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


# TODO figure out how to change font a little better
# def invoiceInfo(c):

