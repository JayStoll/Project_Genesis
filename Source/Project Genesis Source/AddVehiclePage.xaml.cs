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
    /// Interaction logic for AddVehicle.xaml
    /// </summary>
    public partial class AddVehicle : Window
    {
        public AddVehicle()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            this.Close();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            new CreateInvoicePage().Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new AddCustomerPage().Show();
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //itself
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //add part
        }
    }
}
