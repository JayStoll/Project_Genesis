# Author Jayden Stoll
# Date March 16 2018
# Reason do all the calculations that will need to be done within the invoice

from GetFileInfo import rate, hoursWorked
from GetFileInfo import rate1, qtyAmount

labourAmount = rate * hoursWorked
partAmount = rate1 * qtyAmount

subtotal = labourAmount + partAmount
