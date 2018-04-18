using Project_Genesis_Source.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project_Genesis_Source
{
    /// <summary>
    /// Interaction logic for AddPart1.xaml
    /// </summary>
    public partial class AddPart1 : Page
    {
        public AddPart1()
        {
            InitializeComponent();
        }

        private void AddPartButton_Click(object sender, RoutedEventArgs e)
        {
            string partName = nameTxt.Text;
            string partSerialNum = serialNumTxt.Text;
            string partNum = partNumTxt.Text;
            string partPrice = priceTxt.Text;
            string partNotes = notesTxt.Text;
     
            //initialize dataconnection variable
            DatabaseConnection dataConnect = new DatabaseConnection();

            if (nameTxt.Text.Trim() == string.Empty)
            {
                checkForMissingFeild(partName, partSerialNum, partNum, partPrice);
            }

            dataConnect.AddNewPart(partName, partSerialNum, partNum, partPrice, partNotes);
            ClearText();

        }

        private void ClearText()
        {

            nameTxt.Text = "";
            serialNumTxt.Text = "";
            partNumTxt.Text = "";
            priceTxt.Text = "";
            notesTxt.Text = "";


        }

        //for testing and debugging
        private void showText()
        {
            MessageBox.Show(nameTxt.Text);
            MessageBox.Show(serialNumTxt.Text);
            MessageBox.Show(partNumTxt.Text);
            MessageBox.Show(priceTxt.Text);

        }

        private void checkForMissingFeild(string partName, string partSerialNum, string partNum, string partPrice)
        {
            int i = 0;
            //initialize text feilds into an array
            string[] textFeilds = { partName, partSerialNum, partNum, partPrice };

            foreach (string element in textFeilds)
            {
                if (textFeilds[i] == "")
                {
                    MessageBox.Show(textFeilds[i] + ": Feild is missing");
                }
            }
            
        }

        //AJ Santillan March 28, 2018
        //Watermarks


        //watermark Name
        private void nameTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(nameTxt.Text))
            {
                nameTxt.Visibility = System.Windows.Visibility.Collapsed;
                nameTxtWatermark.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void nameTxtWatermark_GotFocus(object sender, RoutedEventArgs e)
        {
            nameTxtWatermark.Visibility = System.Windows.Visibility.Collapsed;
            nameTxt.Visibility = System.Windows.Visibility.Visible;
            nameTxt.Focus();
        }


        //Watermark SerialNumber
        private void serialNumTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(serialNumTxt.Text))
            {
                serialNumTxt.Visibility = System.Windows.Visibility.Collapsed;
                serialNumTxtWatermark.Visibility = System.Windows.Visibility.Visible;
            }

        }

        private void serialNumTxtWatermark_GotFocus(object sender, RoutedEventArgs e)
        {
            serialNumTxtWatermark.Visibility = System.Windows.Visibility.Collapsed;
            serialNumTxt.Visibility = System.Windows.Visibility.Visible;
            serialNumTxt.Focus();
        }



        //Watermark Part Number
        private void partNumTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(partNumTxt.Text))
            {
                partNumTxt.Visibility = System.Windows.Visibility.Collapsed;
                partNumTxtWatermark.Visibility = System.Windows.Visibility.Visible;
            }

        }

        private void partNumTxtWatermark_GotFocus(object sender, RoutedEventArgs e)
        {
            partNumTxtWatermark.Visibility = System.Windows.Visibility.Collapsed;
            partNumTxt.Visibility = System.Windows.Visibility.Visible;
            partNumTxt.Focus();
        }


        //Watermark Price
        private void priceTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(priceTxt.Text))
            {
                priceTxt.Visibility = System.Windows.Visibility.Collapsed;
                priceTextWatermark.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void priceTextWatermark_GotFocus(object sender, RoutedEventArgs e)
        {
            priceTextWatermark.Visibility = System.Windows.Visibility.Collapsed;
            priceTxt.Visibility = System.Windows.Visibility.Visible;
            priceTxt.Focus();
        }

    }
}
