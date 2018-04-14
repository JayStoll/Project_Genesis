using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;

// TODO fix the output so it only prints as ##.##

namespace Project_Genesis_Source.Classes {

    class CreatePDF {
        public void CreateInvoice(ClientInfo client, LabourInfo labour, PartInfo part, int taxRate) {
            try {
                // create new PDF document
                PdfDocument doc = new PdfDocument();
                doc.Info.Title = "CAJNvoice Generated Invoice";

                // add a new page
                PdfPage page = doc.AddPage();

                // get XGraphics object for drawing
                XGraphics gfx = XGraphics.FromPdfPage(page);

                // Create fonts
                XFont titleFontBold = new XFont("Verdana", 15, XFontStyle.Bold);
                XFont font = new XFont("Verdana", 10, XFontStyle.Regular);

                double leftAlign = 30;
                double printDownPage = 0;
                double downPercent = 15;

                // Print out the PDF text
                #region Print Darwin's Information - Hard coded
                gfx.DrawString("Darwin Eitzen Mechanical", titleFontBold, XBrushes.Black,
                    new XRect(leftAlign, (printDownPage += downPercent), page.Width, page.Height), XStringFormats.TopLeft);
                gfx.DrawString("Box 41", font, XBrushes.Black,
                    new XRect(leftAlign, (printDownPage += downPercent + 5), page.Width, page.Height), XStringFormats.TopLeft);
                gfx.DrawString("Linden, AB T0M 1J0", font, XBrushes.Black,
                    new XRect(leftAlign, (printDownPage += downPercent), page.Width, page.Height), XStringFormats.TopLeft);
                gfx.DrawString("403-352-1560", font, XBrushes.Black,
                    new XRect(leftAlign, (printDownPage += downPercent), page.Width, page.Height), XStringFormats.TopLeft);
                gfx.DrawString("GST/HST Registration No: 110074697RT0001", font, XBrushes.Black,
                    new XRect(leftAlign, (printDownPage += downPercent), page.Width, page.Height), XStringFormats.TopLeft);
                #endregion
                #region Print Client Information
                gfx.DrawString("Invoice To:", titleFontBold, XBrushes.Black,
                    new XRect(leftAlign, (printDownPage += (downPercent * 3)), page.Width, page.Height), XStringFormats.TopLeft);
                double tempSpacing = printDownPage;
                gfx.DrawString(client.ClientFName + " " + client.ClientLName, font, XBrushes.Black,
                    new XRect(leftAlign, (printDownPage += downPercent + 5), page.Width, page.Height), XStringFormats.TopLeft);
                gfx.DrawString(client.Company, font, XBrushes.Black,
                    new XRect(leftAlign, (printDownPage += downPercent), page.Width, page.Height), XStringFormats.TopLeft);

                // TODO make this work
                string coLine = (client.CO != " ") ? client.CO : client.ClientFName + " " + client.ClientLName;

                gfx.DrawString("C/O " + coLine, font, XBrushes.Black,
                    new XRect(leftAlign, (printDownPage += downPercent), page.Width, page.Height), XStringFormats.TopLeft);
                gfx.DrawString(client.BoxNum, font, XBrushes.Black,
                    new XRect(leftAlign, (printDownPage += downPercent), page.Width, page.Height), XStringFormats.TopLeft);
                gfx.DrawString(client.Address + " " + client.PostalCode, font, XBrushes.Black,
                    new XRect(leftAlign, (printDownPage += downPercent), page.Width, page.Height), XStringFormats.TopLeft);
                #endregion
                #region Invoice Info - Hard Coded
                gfx.DrawString("Invoice #", titleFontBold, XBrushes.Black,
                    new XRect(leftAlign * 13, tempSpacing, page.Width, page.Height), XStringFormats.TopLeft);
                gfx.DrawString("Date", titleFontBold, XBrushes.Black,
                    new XRect(leftAlign * 13, tempSpacing + downPercent, page.Width, page.Height), XStringFormats.TopLeft);
                gfx.DrawString("Due Date", titleFontBold, XBrushes.Black,
                    new XRect(leftAlign * 13, tempSpacing + (downPercent * 2), page.Width, page.Height), XStringFormats.TopLeft);
                gfx.DrawString("Terms", titleFontBold, XBrushes.Black,
                    new XRect(leftAlign * 13, tempSpacing + (downPercent * 3), page.Width, page.Height), XStringFormats.TopLeft);
                #endregion
                #region Fill Invoice Info - only thing to do on this one is get the invoice number
                gfx.DrawString("1", font, XBrushes.Black,
                    new XRect(leftAlign * 17, tempSpacing + 5, page.Width, page.Height), XStringFormats.TopLeft);
                gfx.DrawString(DateTime.Now.ToString("dd/MM/yyyy"), font, XBrushes.Black,
                    new XRect(leftAlign * 17, tempSpacing + downPercent, page.Width, page.Height), XStringFormats.TopLeft);
                gfx.DrawString(DateTime.Now.AddDays(20).ToString("dd/MM/yyyy"), font, XBrushes.Black,
                    new XRect(leftAlign * 17, tempSpacing + (downPercent * 2), page.Width, page.Height), XStringFormats.TopLeft);
                gfx.DrawString("Due on receipt", font, XBrushes.Black,
                    new XRect(leftAlign * 17, tempSpacing + (downPercent * 3), page.Width, page.Height), XStringFormats.TopLeft);
                #endregion
                #region Information Bar - Hard Coded
                gfx.DrawString("Activity", font, XBrushes.Black,
                    new XRect(leftAlign, printDownPage += downPercent * 4, page.Width, page.Height), XStringFormats.TopLeft);
                gfx.DrawString("QTY", font, XBrushes.Black,
                    new XRect(leftAlign * 7, printDownPage, page.Width, page.Height), XStringFormats.TopLeft);
                gfx.DrawString("Rate", font, XBrushes.Black,
                    new XRect(leftAlign * 10, printDownPage, page.Width, page.Height), XStringFormats.TopLeft);
                gfx.DrawString("Tax", font, XBrushes.Black,
                    new XRect(leftAlign * 13, printDownPage, page.Width, page.Height), XStringFormats.TopLeft);
                gfx.DrawString("Amount", font, XBrushes.Black,
                    new XRect(leftAlign * 16, printDownPage, page.Width, page.Height), XStringFormats.TopLeft);
                #endregion
                #region Fill Labour Information 
                gfx.DrawString("Labour", titleFontBold, XBrushes.Black,
                    new XRect(leftAlign, (printDownPage + (downPercent + 5)), page.Width, page.Height), XStringFormats.TopLeft);
                gfx.DrawString(labour.QtyAmount, font, XBrushes.Black,
                    new XRect(leftAlign * 7, (printDownPage + (downPercent + 5)), page.Width, page.Height), XStringFormats.TopLeft);
                gfx.DrawString(labour.Rate, font, XBrushes.Black,
                    new XRect(leftAlign * 10, (printDownPage + (downPercent + 5)), page.Width, page.Height), XStringFormats.TopLeft);
                gfx.DrawString(labour.Tax, font, XBrushes.Black,
                    new XRect(leftAlign * 13, (printDownPage + (downPercent + 5)), page.Width, page.Height), XStringFormats.TopLeft);
                double labourTotal = (double.Parse(labour.QtyAmount) * double.Parse(labour.Rate));
                gfx.DrawString(labourTotal.ToString(), font, XBrushes.Black,
                    new XRect(leftAlign * 16, (printDownPage += (downPercent + 5)), page.Width, page.Height), XStringFormats.TopLeft);

                printDownPage += 5;
                // sets the limit of how far the line can go
                int limit = (int)leftAlign + 5;
                string labourInfo = labour.Labour;
                // gets all the labour information and splits it into a string array
                string[] words = labourInfo.Split(new char[] { ' ' });
                IList<string> sentenceParts = new List<string> {
                string.Empty
            };
                int partCounter = 0;

                foreach (string word in words) {
                    // if line length is at the limit go to the next line
                    if ((sentenceParts[partCounter] + word).Length > limit) {
                        partCounter++;
                        sentenceParts.Add(string.Empty);
                    }
                    // add the word to the list
                    sentenceParts[partCounter] += word + " ";
                }

                // print out the list to the PDF
                foreach (string x in sentenceParts) {
                    gfx.DrawString(x, font, XBrushes.Black,
                        new XRect(leftAlign, (printDownPage += downPercent), page.Width, page.Height), XStringFormats.TopLeft);
                }
                #endregion
                #region Fill Part Information
                printDownPage += 5;
                string partInfo = part.PartsUsed;
                // gets all the part information and splits it into a string array
                string[] partWords = partInfo.Split(new char[] { ' ' });
                IList<string> partWord = new List<string> {
                string.Empty
            };
                int counter = 0;

                foreach (string i in partWords) {
                    // if line length is at the limit go to the next line
                    if ((partWord[counter] + i).Length > limit) {
                        counter++;
                        partWord.Add(string.Empty);
                    }
                    // add the word to the list
                    partWord[counter] += i + " ";
                }

                gfx.DrawString("Part", titleFontBold, XBrushes.Black,
                        new XRect(leftAlign, (printDownPage + downPercent), page.Width, page.Height), XStringFormats.TopLeft);
                gfx.DrawString(part.AmountOfParts, font, XBrushes.Black,
                    new XRect(leftAlign * 7, (printDownPage + (downPercent + 5)), page.Width, page.Height), XStringFormats.TopLeft);
                gfx.DrawString(part.PartTotal, font, XBrushes.Black,
                    new XRect(leftAlign * 10, (printDownPage + (downPercent + 5)), page.Width, page.Height), XStringFormats.TopLeft);
                gfx.DrawString(labour.Tax, font, XBrushes.Black,
                    new XRect(leftAlign * 13, (printDownPage + (downPercent + 5)), page.Width, page.Height), XStringFormats.TopLeft);
                gfx.DrawString(part.PartTotal, font, XBrushes.Black,
                    new XRect(leftAlign * 16, (printDownPage += (downPercent + 5)), page.Width, page.Height), XStringFormats.TopLeft);

                // print out the list to the PDF
                foreach (string y in partWord) {
                    gfx.DrawString(y, font, XBrushes.Black,
                        new XRect(leftAlign, (printDownPage += downPercent), page.Width, page.Height), XStringFormats.TopLeft);
                }
                gfx.DrawString(client.Vehicle, font, XBrushes.Black,
                        new XRect(leftAlign, (printDownPage += (downPercent * 2)), page.Width, page.Height), XStringFormats.TopLeft);
                #endregion
                #region Print Total Text - Hard Coded
                double newTemp = printDownPage + (downPercent * 20);
                gfx.DrawString("SUBTOTAL", titleFontBold, XBrushes.Black,
                        new XRect(leftAlign * 10, (printDownPage + (downPercent * 20)), page.Width, page.Height), XStringFormats.TopLeft);
                gfx.DrawString("GST/HST @ " + taxRate.ToString() + "%", titleFontBold, XBrushes.Black,
                        new XRect(leftAlign * 10, (printDownPage += (downPercent * 20) + (downPercent + 5)), page.Width, page.Height), XStringFormats.TopLeft);
                gfx.DrawString("TOTAL", titleFontBold, XBrushes.Black,
                        new XRect(leftAlign * 10, printDownPage += (downPercent + 5), page.Width, page.Height), XStringFormats.TopLeft);
                gfx.DrawString("BALANCE DUE", titleFontBold, XBrushes.Black,
                        new XRect(leftAlign * 10, printDownPage += (downPercent + 5), page.Width, page.Height), XStringFormats.TopLeft);
                #endregion
                #region Print Total Info
                double subtotal = (labourTotal + double.Parse(part.PartTotal));
                gfx.DrawString(subtotal.ToString(), font, XBrushes.Black,
                        new XRect(leftAlign * 17, newTemp, page.Width, page.Height), XStringFormats.TopLeft);
                gfx.DrawString((subtotal / taxRate).ToString(), font, XBrushes.Black,
                        new XRect(leftAlign * 17, (newTemp += (downPercent + 5)), page.Width, page.Height), XStringFormats.TopLeft);
                double total = subtotal + (subtotal / taxRate);
                gfx.DrawString(total.ToString(), font, XBrushes.Black,
                        new XRect(leftAlign * 17, newTemp += (downPercent + 5), page.Width, page.Height), XStringFormats.TopLeft);
                gfx.DrawString(total.ToString(), titleFontBold, XBrushes.Black,
                        new XRect(leftAlign * 17, newTemp += (downPercent + 5), page.Width, page.Height), XStringFormats.TopLeft);
                #endregion

                // set the file to print the document
                string filename = @"invoices\" + client.ClientFName + " " + client.ClientLName + @"\" + client.ClientFName + client.ClientLName + DateTime.Now.ToString("dd/MM/yyyy") + ".pdf";
                // creates a new directory if one is not present
                System.IO.FileInfo file = new System.IO.FileInfo(filename);
                file.Directory.Create();  // Skips this if the file path is found
                                          
                doc.Save(filename);       // save the PDF in the specified file path
                // auto open the PDF - this can be optional
                Process.Start(filename);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }

    /// <summary>
    /// Set the information of the Client
    /// </summary>
    class ClientInfo {
        public string ClientFName { get; set; }
        public string ClientLName { get; set; }
        public string Company { get; set; }
        public string CO { get; set; }
        public string BoxNum { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string Vehicle { get; set; }
    }

    /// <summary>
    /// Set the information of the labour
    /// </summary>
    class LabourInfo {
        public string QtyAmount { get; set; }
        public string Rate { get; set; }
        public string Tax { get; set; }
        public string Labour { get; set; }
    }

    /// <summary>
    /// Set the information of the part
    /// </summary>
    class PartInfo {
        public string AmountOfParts { get; set; }
        public string PartTotal { get; set; }
        public string PartsUsed { get; set; }
    }
}
