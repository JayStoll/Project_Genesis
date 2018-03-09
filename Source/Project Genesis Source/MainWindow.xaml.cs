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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        // **AJ Santillan** -March 8 2018-//

        //connects each pages in button clicked
        //buttons arent named correctly at the moment but they basically go to where they are supposed to

        //Create Invoice Button -- so on and so fort
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //this opens up a the new page in another form instead of updating the same form into that page
            //needs to be changed so it updates the form instead of showing another form
            new CreateInvoicePage().Show();
            this.Close();
        }

        // this one leads back to itself so theres no code for it
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            new AddCustomerPage().Show();
            this.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            new AddVehicle().Show();
            this.Close();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            //page doesnt load up
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            //page doesnt load up
        }
    }
}
