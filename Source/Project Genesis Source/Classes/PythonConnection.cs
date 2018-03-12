using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Genesis_Source.Classes
{
    class PythonConnection
    {
        PythonConnection() {
            Console.WriteLine("Python information being set up...");
        }

        // TODO create a function that will create the txt file that will be read by the python script (only if needed)

        /// <summary>
        /// Create a PDF file
        /// </summary>
        public void CreatePDF() {
            string fileName = @"C:\Users\Owner\Documents\Project_Genesis\Python_PDF\CreateNewPDF.py";

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
