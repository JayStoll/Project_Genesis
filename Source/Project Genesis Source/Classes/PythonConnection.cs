/*
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

namespace Project_Genesis_Source.Classes {
    public class PythonConnection {
        TextWriter tw;

        string clientFileInfo = @"clientInfo.txt";
        string invoiceFileInfo = @"invoiceInfo.txt";
        string labourFileInfo = @"labourInfo.txt";
        string partFileInfo = @"partInfo.txt";

        // TODO give arguemtents
        public void CreateClientInfoFile() {
            //File.Create(clientFileInfo);
            tw = new StreamWriter(clientFileInfo);
            tw.Write("Kerry Eitzen.Spring Coulee Pullets Ltd.c/o Kerry Eitzen.Box 282.Linden AB T0M 1J0."); // TODO Get the information from the database
            tw.Close();
        }
        
        // TODO give arguemtents
        public void CreateInvoiceInfoFile() {
            //File.Create(invoiceFileInfo);
            tw = new StreamWriter(invoiceFileInfo);
            tw.WriteLine("635"); // TODO Get the information from the database
            //tw.WriteLine("12-10-2017");
            tw.WriteLine("01-11-2017");
            tw.WriteLine("Due on receipt");
            tw.Write("0.05");
            tw.Close();
        }

        // TODO give arguemtents
        public void CreateLabourInforFile() {
            //File.Create(labourFileInfo);
            tw = new StreamWriter(labourFileInfo);
            tw.WriteLine("Remove fuel tank to clean out"); // TODO Get the information from the database
            tw.WriteLine("Install new fuel line");
            tw.WriteLine("Repair air leak at air filters");
            tw.WriteLine("and install new air filters");
            tw.WriteLine("17");
            tw.WriteLine("75.00");
            tw.Write("G");
            tw.Close();
        }

        // TODO give arguemtents
        public void CreatePartInfoFile() {
            //File.Create(partFileInfo);
            tw = new StreamWriter(partFileInfo);
            tw.WriteLine("NAPA: Filters and fuel line"); // TODO Get the information from the database
            tw.WriteLine("1");
            tw.WriteLine("75.56");
            tw.Write("G"); 
            tw.Close();
        }

        /// <summary>
        /// Create a PDF file
        /// </summary>
        public void CreatePDF() {
            string fileName = @"C:\Users\Owner\Documents\Project_Genesis\Python_PDF\CreatePDF.py";

            Process p = new Process();
            p.StartInfo = new ProcessStartInfo(@"C:\Users\Owner\AppData\Local\Programs\Python\Python36-32\python.exe", fileName) {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            p.Start();

            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            // Debug purposes only
            Console.WriteLine(output);
            Console.ReadLine();
        }
    }
}
