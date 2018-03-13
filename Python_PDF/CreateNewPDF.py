# Author Jayden Stoll
# Date March 11 2018
# Reason Allow for easy conversion of the information given into a database

# Reportlab needed inorder to run this script

from reportlab.pdfgen import canvas
from reportlab.lib.units import inch, cm

#Open a file and then loop through the contents of the file and fill it into the new PDF

# Put all the variable names and initalize them to the string from the array created above
textString = "address of client"

c = canvas.Canvas("testPDF.pdf") #only temp file name - get the client name from the file
def Address(c):
	c.drawString(35, 790, textString)

Address(c)
c.showPage()
c.save()

#Used as Debug just to let us know when the PDF file is created
print("Created a new PDF!")