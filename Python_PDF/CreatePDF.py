# Author Jayden Stoll
# Date March 11 2018
# Reason Allow for easy conversion of the information given into a database

# reportlab needed in-order to run this script

import datetime
import time

from reportlab.pdfgen import canvas
from Definitions import PrintPDF
from GetFileInfo import clientName

c = canvas.Canvas(clientName[0] + clientName[1] + datetime.datetime.today().strftime('%d-%m-%Y') + ".pdf")

PrintPDF(c)  # Print all the information to the PDF file
c.showPage()
c.save()

print("Created a new PDF!")  # Used as Debug just to let us know when the PDF file is created

start_time = time.time()  # TODO take this out before we ship the project
print("--- %s seconds to complete ---" % (time.time() - start_time))
