﻿//AJ Santillan March 8  2018//

//buttons arent named correctly but they get the job done

// **AJ Santillan** -March 8 2018-//

//connects each pages in button clicked
//buttons arent named correctly at the moment but they basically go to where they are supposed to

//Create Invoice Button -- so on and so fort
 
using System.Windows;
using System.Windows.Input;

namespace Project_Genesis_Source
{

    // initial code by: AJ Santillan 
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        public MainWindow() {
            InitializeComponent();
        }

        //connects each pages together on a button click

        private void customerAdd_Click(object sender, RoutedEventArgs e)
        {


            Main.Content = new AddCustomer1();

        }
        
        private void vehicleAdd_Click(object sender, RoutedEventArgs e)
        {


            Main.Content = new AddVehicle1();

        }

        private void addPart_Click(object sender, RoutedEventArgs e)
        {

            Main.Content = new AddPart1();

        }

        private void clientManage_Click(object sender, RoutedEventArgs e)
        {


            Main.Content = new ManageClients1();
        }

        private void backupTab_Click(object sender, RoutedEventArgs e)
        {

            Main.Content = new Backup1();

        }

        private void createInv_Click(object sender, RoutedEventArgs e)
        {
    

            Main.Content = new CreateInvoice1();
        }

        private void createInv1_Click(object sender, RoutedEventArgs e)
        {
   

            Main.Content = new CreateInvoice1();

        }

        private void home1_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main1 = new MainWindow();
            main1.Show();
            this.Close();
        }

        private void createInvB_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new CreateInvoice1();
        }

        private void addCustomerB_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new AddCustomer1();
        }

        private void addVehicleB_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new AddVehicle1();
        }

        private void addPartB_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new AddPart1();
        }

        private void ManageClientsB_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new ManageClients1();
        }

        private void backupB_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Backup1();
        }

        private void aboutUs_Click(object sender, RoutedEventArgs e)
        {
            AboutUs AU = new AboutUs();
            AU.Show();

        }

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Exit1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        //drag and drop code
        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
