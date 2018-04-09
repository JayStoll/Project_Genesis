﻿/*
 * Author: Jayden Stoll
 * Date: March 12 2018
 * Reason: Allow Connection to the python script and allow the creating of PDF files
 */

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using IronPython.Hosting;

namespace Project_Genesis_Source.Classes {
    public class PythonConnection {
        TextWriter tw;

        string clientFileInfo = @"clientInfo.txt";
        string invoiceFileInfo = @"invoiceInfo.txt";
        string labourFileInfo = @"labourInfo.txt";
        string partFileInfo = @"partInfo.txt";

        // TODO give arguemtents
        public void CreateClientInfoFile(string clientFName, string clientLName, string company, string box, string address, string postalCode) {
            tw = new StreamWriter(clientFileInfo);
            tw.Write(clientFName, ".", clientLName, ".", /*company, ".",*/ box, ".", address, " ", postalCode);
            tw.Close();
        }
        
        // TODO give arguemtents
        public void CreateInvoiceInfoFile() {
            tw = new StreamWriter(invoiceFileInfo);
            // TODO Get the information from the database
            tw.WriteLine("635");                                    // invoice number                                  
            //tw.WriteLine("12-10-2017");                           // this is autotmatically created in the python script
            tw.WriteLine("01-11-2017");                             // due date of the invoice
            //tw.WriteLine("Due on receipt");                       // this is created automatically in the python script
            tw.Write("0.05");                                       // tax rate (0.05 = 5% - converted in the python script)
            tw.Close();
        }

        // TODO give arguemtents
        public void CreateLabourInforFile() {
            tw = new StreamWriter(labourFileInfo);
            // TODO Get the information from the database
            // TODO add the vehcicle that he worked on 
            tw.WriteLine("Remove fuel tank to clean out");          // store this information in an array - broken up by a period? - then printed from an array - work done
            tw.WriteLine("Install new fuel line");
            tw.WriteLine("Repair air leak at air filters");
            tw.WriteLine("and install new air filters");
            tw.WriteLine("17");                                     // hours worked
            tw.WriteLine("75.00");                                  // rate
            tw.Write("G");                                          // tax type 
            tw.Close();
        }

        // TODO give arguemtents
        public void CreatePartInfoFile() {
            tw = new StreamWriter(partFileInfo);
            // TODO Get the information from the database
            tw.WriteLine("NAPA: Filters and fuel line");            // parts used
            tw.WriteLine("1");                                      // amount of parts used - not entered by the user
            tw.WriteLine("75.56");                                  // the total price of all the parts
            tw.WriteLine("Small loader");                           // the type of vehicle it is
            tw.Write("G");                                          // tax type
            tw.Close();
        }

        /// <summary>
        /// Create a PDF file
        /// </summary>
        public void CreatePDF() {
            string fileName = @"python\CreatePDF.py";

            var py = Python.CreateEngine();
            try {
                py.ExecuteFile(fileName);
            } 
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            finally {
                // used to delete the files as to not clutter the file with extra documents
                File.Delete(clientFileInfo);
                File.Delete(invoiceFileInfo);
                File.Delete(labourFileInfo);
                File.Delete(partFileInfo);
            }
            
        }
    }
}
