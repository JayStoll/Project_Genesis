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


        //Watermark Owners Vehicle
        private void ownerVehicleTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(ownerVehicleTxt.Text))
            {
                ownerVehicleTxt.Visibility = System.Windows.Visibility.Collapsed;
                ownerVehicleTxtWatermark.Visibility = System.Windows.Visibility.Visible;
            }

        }

        private void ownerVehicleTxtWatermark_GotFocus(object sender, RoutedEventArgs e)
        {
            ownerVehicleTxtWatermark.Visibility = System.Windows.Visibility.Collapsed;
            ownerVehicleTxt.Visibility = System.Windows.Visibility.Visible;
            ownerVehicleTxt.Focus();
        }
    }
}
