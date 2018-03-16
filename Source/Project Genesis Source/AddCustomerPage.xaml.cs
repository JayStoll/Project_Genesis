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
using System.Windows.Shapes;

namespace Project_Genesis_Source
{
    /// <summary>
    /// Interaction logic for AddCustomerPage.xaml
    /// </summary>
    public partial class AddCustomerPage : Window
    {
        //DatabaseConnection class variable
        DatabaseConnection dataConnect = new DatabaseConnection();

        public AddCustomerPage()
        {
            InitializeComponent();
        }

        private void homeTab_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Add_Customer_Click(object sender, RoutedEventArgs e)
        {
            //setup strings
            string cusFName = (FnameTxt.Text);
            string cusLName = (LnameTxt.Text);
            string cusAddress = (AddressTxt.Text);
            string cusPhone = (PhoneNumTxt.Text);
            string cusEmail = (EmailTxt.Text);

            //check if Email is null
            if (cusEmail is null)
            {
                dataConnect.AddNewClient(cusFName, cusLName, cusAddress, cusPhone);
            }
            else
            {
                dataConnect.AddNewClient(cusFName, cusLName, cusAddress, cusPhone, cusEmail);
            }
        }
    }
}
