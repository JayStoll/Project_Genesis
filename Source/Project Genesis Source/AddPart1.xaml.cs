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
    /// Interaction logic for AddPart1.xaml
    /// </summary>
    public partial class AddPart1 : Page
    {
        public AddPart1()
        {
            InitializeComponent();
        }

        private void AddPartButton_Click(object sender, RoutedEventArgs e)
        {
            string partName = nameTxt.Text;
            string partSerialNum = serialNumTxt.Text;
            string partNum = partNumTxt.Text;
            string partPrice = priceTxt.Text;
            string partNotes = notesTxt.Text;

            //DO we still need this without the relation to Vehicle_Part???
            string partVehicleOwn = ownerVehicleTxt.Text;
            

            //initialize dataconnection variable
            DatabaseConnection dataConnect = new DatabaseConnection();

            dataConnect.AddNewPart(partName, partSerialNum, partNum, partPrice, partNotes);
            
        }
    }
}
