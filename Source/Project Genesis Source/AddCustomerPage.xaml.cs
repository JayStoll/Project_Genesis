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

    // initial code by: AJ Santillan 
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

        //connects each pages together on a button click

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

        private void createInv_Click(object sender, RoutedEventArgs e)
        {
            CreateInvoicePage createInvoicePage = new CreateInvoicePage();
            createInvoicePage.Show();
            this.Close();
        }

        private void vehicleAdd_Click(object sender, RoutedEventArgs e)
        {
            AddVehicle addVehicle = new AddVehicle();
            addVehicle.Show();
            this.Close();
        }

        private void addPart_Click(object sender, RoutedEventArgs e)
        {
            AddPart addPart = new AddPart();
            addPart.Show();
            this.Close();
        }

        private void clientManage_Click(object sender, RoutedEventArgs e)
        {
            ManageClients manageClients = new ManageClients();
            manageClients.Show();
            this.Close();
        }

        private void backupTab_Click(object sender, RoutedEventArgs e)
        {
            BnApage backup = new BnApage();
            backup.Show();
            this.Close();
        }
    }
}
