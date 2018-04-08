using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Genesis_Source.Classes {

    class CreatePDF {
        public void CreateInvoice() {  // TODO put the arguments it will need in here
            // create new PDF document
            PdfDocument doc = new PdfDocument();
            doc.Info.Title = "Test document";

            // add a new page
            PdfPage page = doc.AddPage();

            // get XGraphics object for drawing
            XGraphics gfx = XGraphics.FromPdfPage(page);

            // Create a font
            XFont titleFontBold = new XFont("Verdana", 15, XFontStyle.Bold);
            XFont font = new XFont("Verdana", 10, XFontStyle.Regular);

            double leftAlign = 30;
            double printDownPage = 0;
            double downPercent = 15;

            #region Print Darwin's Information
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
            // TODO Get this information from a class
            gfx.DrawString("Invoice To:", titleFontBold, XBrushes.Black,
                new XRect(leftAlign, (printDownPage += (downPercent * 3)), page.Width, page.Height), XStringFormats.TopLeft);
            double tempSpacing = printDownPage;
            gfx.DrawString("Kerry Eitzen", font, XBrushes.Black,
                new XRect(leftAlign, (printDownPage += downPercent + 5), page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("Spring Coulee Pullets Ltd", font, XBrushes.Black,
                new XRect(leftAlign, (printDownPage += downPercent), page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("c/o Kerry Eitzen", font, XBrushes.Black,
                new XRect(leftAlign, (printDownPage += downPercent), page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("Box 282", font, XBrushes.Black,
                new XRect(leftAlign, (printDownPage += downPercent), page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("Linden, AB T0M 1J0", font, XBrushes.Black,
                new XRect(leftAlign, (printDownPage += downPercent), page.Width, page.Height), XStringFormats.TopLeft);
            #endregion
            #region Invoice Info
            gfx.DrawString("Invoice #", titleFontBold, XBrushes.Black,
                new XRect(leftAlign * 13, tempSpacing, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("Date", titleFontBold, XBrushes.Black,
                new XRect(leftAlign * 13, tempSpacing + downPercent, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("Due Date", titleFontBold, XBrushes.Black,
                new XRect(leftAlign * 13, tempSpacing + (downPercent * 2), page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("Terms", titleFontBold, XBrushes.Black,
                new XRect(leftAlign * 13, tempSpacing + (downPercent * 3), page.Width, page.Height), XStringFormats.TopLeft);
            #endregion
            #region Fill Invoice Info
            gfx.DrawString("1", font, XBrushes.Black,
                new XRect(leftAlign * 17, tempSpacing + 5, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString(DateTime.Now.ToString("dd/mm/yyyy"), font, XBrushes.Black,
                new XRect(leftAlign * 17, tempSpacing + downPercent, page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString(DateTime.Now.AddDays(20).ToString("dd/mm/yyyy"), font, XBrushes.Black,
                new XRect(leftAlign * 17, tempSpacing + (downPercent * 2), page.Width, page.Height), XStringFormats.TopLeft);
            gfx.DrawString("Due on receipt", font, XBrushes.Black,
                new XRect(leftAlign * 17, tempSpacing + (downPercent * 3), page.Width, page.Height), XStringFormats.TopLeft);
            #endregion
            #region Information Bar
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

            // Save the document
            string filename = @"invoices\test.pdf";
            // creates a new directory if one is not present
            System.IO.FileInfo file = new System.IO.FileInfo(filename);
            file.Directory.Create();
            doc.Save(filename);
            // start a viewer - this can be optional
            Process.Start(filename);
        }
    }
}
