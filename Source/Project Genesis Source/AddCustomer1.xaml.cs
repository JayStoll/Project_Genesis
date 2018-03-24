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
    }
}
