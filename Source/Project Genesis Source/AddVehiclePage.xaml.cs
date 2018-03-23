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
    /// Interaction logic for AddVehicle.xaml
    /// </summary>
    public partial class AddVehicle : Window
    {
        public AddVehicle()
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

        private void createInv_Click(object sender, RoutedEventArgs e)
        {
            CreateInvoicePage createInvoicePage = new CreateInvoicePage();
            createInvoicePage.Show();
            this.Close();
        }

        private void customerAdd_Click(object sender, RoutedEventArgs e)
        {
            AddCustomerPage addCustomerPage = new AddCustomerPage();
            addCustomerPage.Show();
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

        //add vehicle button click event
        private void Add_Vehicle_Click(object sender, RoutedEventArgs e)
        {
            //intialize variables
            string vehicleSerialNum = (serialNumTxt.Text);
            string vehicleType = (vehicleTypeTxt.Text);
            string vehicleMake = (vehicleMakeTxt.Text);
            string vehicleModelNum = (vehicleModelNumTxt.Text);
            string vehicleNotes = (vehicleNotesTxt.Text);
            //fill these with split name from ownerTxt
            string ownerFName = null, ownerLName = null;

            DatabaseConnection dataConnect = new DatabaseConnection();

            dataConnect.AddNewVehicle(vehicleSerialNum, vehicleType, vehicleMake, vehicleModelNum, vehicleNotes, ownerFName, ownerLName);

            


        }
    }
}
