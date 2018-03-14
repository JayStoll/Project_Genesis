# Author Jayden Stoll
# Date March 11 2018
# Reason Allow for easy conversion of the information given into a database

# reportlab needed in-order to run this script

import datetime
from reportlab.pdfgen import canvas
from Definitions import PrintPDF
from GetFileInfo import words

c = canvas.Canvas(words[0] + words[1] + datetime.datetime.today().strftime('-%d-%m-%Y') + ".pdf")

PrintPDF(c)  # Print all the information to the PDF file
c.showPage()
c.save()

print("Created a new PDF!")  # Used as Debug just to let us know when the PDF file is created
