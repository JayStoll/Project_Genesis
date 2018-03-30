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
    /// Interaction logic for AddCustomer1.xaml
    /// </summary>
    public partial class AddCustomer1 : Page
    {
        public AddCustomer1()
        {
            InitializeComponent();
        }

        private void Add_Customer_Click(object sender, RoutedEventArgs e)
        {
            //initialize strings from textboxes
            string fName = fNametxt.Text;
            string lName = lNameTxt.Text;
            string address = addressTxt.Text;
            string boxNum = boxNumtxt.Text;
            string phoneNum = phoneNumTxt.Text;
            string email = emailTxt.Text;
            string postalCode = postalCodeTxt.Text;

            //initialize database connection variable
            DatabaseConnection dataConnect = new DatabaseConnection();

            if (email == null)
            {
                dataConnect.AddNewClient(fName, lName, address, phoneNum, boxNum, postalCode);
            }
            else
            {
                dataConnect.AddNewClient(fName, lName, address, phoneNum, email, boxNum, postalCode);
            }
        }


        //AJ Santillan March 28, 2018
        //Watermarks


        //First Name Watermark
        private void fNametxt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(fNametxt.Text))
            {
                fNametxt.Visibility = System.Windows.Visibility.Collapsed;
                fNametxtWatermark.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void fNametxtWatermark_GotFocus(object sender, RoutedEventArgs e)
        {
            fNametxtWatermark.Visibility = System.Windows.Visibility.Collapsed;
            fNametxt.Visibility = System.Windows.Visibility.Visible;
            fNametxt.Focus();
        }


        //Last Name
        private void lNameTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(lNameTxt.Text))
            {
                lNameTxt.Visibility = System.Windows.Visibility.Collapsed;
                lNameTxtWatermark.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void lNameTxtWatermark_GotFocus(object sender, RoutedEventArgs e)
        {
            lNameTxtWatermark.Visibility = System.Windows.Visibility.Collapsed;
            lNameTxt.Visibility = System.Windows.Visibility.Visible;
            lNameTxt.Focus();
        }


        //Address
        private void addressTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(addressTxt.Text))
            {
                addressTxt.Visibility = System.Windows.Visibility.Collapsed;
                addressTxtWatermark.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void addressTxtWatermark_GotFocus(object sender, RoutedEventArgs e)
        {
            addressTxtWatermark.Visibility = System.Windows.Visibility.Collapsed;
            addressTxt.Visibility = System.Windows.Visibility.Visible;
            addressTxt.Focus();
        }


        //Phone Number
        private void phoneNumTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(phoneNumTxt.Text))
            {
                phoneNumTxt.Visibility = System.Windows.Visibility.Collapsed;
                phoneNumTxtWatermark.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void phoneNumTxtWatermark_GotFocus(object sender, RoutedEventArgs e)
        {
            phoneNumTxtWatermark.Visibility = System.Windows.Visibility.Collapsed;
            phoneNumTxt.Visibility = System.Windows.Visibility.Visible;
            phoneNumTxt.Focus();
        }


        //Postal Code
        private void postalCodeTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(postalCodeTxt.Text))
            {
                postalCodeTxt.Visibility = System.Windows.Visibility.Collapsed;
                postalCodeTxtWatermark.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void postalCodeTxtWatermark_GotFocus(object sender, RoutedEventArgs e)
        {
            postalCodeTxtWatermark.Visibility = System.Windows.Visibility.Collapsed;
            postalCodeTxt.Visibility = System.Windows.Visibility.Visible;
            postalCodeTxt.Focus();
        }


        //Email
        private void emailTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(emailTxt.Text))
            {
                emailTxt.Visibility = System.Windows.Visibility.Collapsed;
                emailTxtWatermark.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void emailTxtWatermark_GotFocus(object sender, RoutedEventArgs e)
        {
            emailTxtWatermark.Visibility = System.Windows.Visibility.Collapsed;
            emailTxt.Visibility = System.Windows.Visibility.Visible;
            emailTxt.Focus();
        }

        //Box Number
        private void boxNumtxt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(boxNumtxt.Text))
            {
                boxNumtxt.Visibility = System.Windows.Visibility.Collapsed;
                boxNumtxtWatermark.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void boxNumtxtWatermark_GotFocus(object sender, RoutedEventArgs e)
        {
            boxNumtxtWatermark.Visibility = System.Windows.Visibility.Collapsed;
            boxNumtxt.Visibility = System.Windows.Visibility.Visible;
            boxNumtxt.Focus();
        }
    }
}
