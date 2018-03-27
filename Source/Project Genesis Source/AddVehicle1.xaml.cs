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
    /// Interaction logic for AddVehicle1.xaml
    /// </summary>
    public partial class AddVehicle1 : Page
    {
        public AddVehicle1()
        {
            InitializeComponent();
        }

        private void AddVehicleButton_Click(object sender, RoutedEventArgs e)
        {

            //initialize dataconnection variable
            DatabaseConnection dataConnect = new DatabaseConnection();

            string serialNum = serialNumTxt.Text;
            string type = typeTxt.Text;
            string make = makeTxt.Text;
            string modelNumber = modelNumTxt.Text;
            string notes = notesTxt.Text;
            string ownerFName = ownerFNameTxt.Text;
            string ownerLName = ownerLNameTxt.Text;

            if (notes == null)
            {
                dataConnect.AddNewVehicle(serialNum, type, make, modelNumber, ownerFName, ownerLName);
            }
            else
            {
                dataConnect.AddNewVehicle(serialNum, type, make, modelNumber, notes, ownerFName, ownerLName);
            }

        }
    }
}
