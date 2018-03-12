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

        //AJ Santillan March 8  2018//

            //buttons arent named correctly but they get the job done

        // **AJ Santillan** -March 8 2018-//

        //connects each pages in button clicked
        //buttons arent named correctly at the moment but they basically go to where they are supposed to

        //Create Invoice Button -- so on and so fort
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //this opens up a the new page in another form instead of updating the same form into that page
            //needs to be changed so it updates the form instead of showing another form
        //these buttons are the ones on the side 

        //connects straight away to the CreateInvoice Page so on and so fort
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //closes the current page and opens a new page
            new CreateInvoicePage().Show();
            this.Close();
        }

        // this one leads back to itself so theres no code for it
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            new AddCustomerPage().Show();
            this.Close();
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
            new AddVehicle().Show();
            this.Close();
        }


        //from here on out the buttons are the big buttons

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {

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
