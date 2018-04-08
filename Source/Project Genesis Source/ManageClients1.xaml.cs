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

namespace Project_Genesis_Source {

    /// <summary>
    /// Interaction logic for ManageClients1.xaml
    /// </summary>
    public partial class ManageClients1 : Page {
        DatabaseConnection dataConnect = new DatabaseConnection();

        public ManageClients1() {
            InitializeComponent();

            // Debug to find what the error was
            // MessageBox.Show(dataConnect.RetrieveFNames().Length.ToString());

            // Get the list of names
            string[] fnames = dataConnect.RetrieveFNames();

            if (fnames.Length == 0) {
                MessageBox.Show("No first names to populate with");
            }
            else {
                // print all the names in the array
                for (int i = 0; i < fnames.Length; i++) {
                    // TODO - sort the clients alphabetical order
                    nameOutputBox.Items.Add(fnames[i]);
                }
            }

            //Get list of VehicleInfo
            string[] vehicleInfo = dataConnect.RetrieveVehicleInfo();

            if (vehicleInfo.Length == 0)
            {
                MessageBox.Show("No vehicle information to populate with");
            }
            else
            {
                //print all vehicleinfo
                for (int i = 0; i <vehicleInfo.Length; i++)
                {
                    VehicleList.Items.Add(vehicleInfo[i]);
                }
            }

        }
    }
}
