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
    /// Interaction logic for AddPart.xaml
    /// </summary>
    public partial class AddPart : Window
    {
        public AddPart()
        {
            InitializeComponent();
        }

        private void homeTab_Click(object sender, RoutedEventArgs e)
        {
            MainWindow maineWindow = new MainWindow();
            maineWindow.Show();
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

        private void vehicleAdd_Click(object sender, RoutedEventArgs e)
        {
            AddVehicle addVehicle = new AddVehicle();
            addVehicle.Show();
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
