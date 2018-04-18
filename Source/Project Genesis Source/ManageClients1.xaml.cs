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
    /// Interaction logic for ManageClients1.xaml
    /// </summary>
    public partial class ManageClients1 : Page
    {
        DatabaseConnection dataConnect = new DatabaseConnection();

        public ManageClients1()
        {
            InitializeComponent();

            // Get the list of names
            string[] fnames = dataConnect.RetrieveNames();

            if (fnames.Length == 0)
            {
                MessageBox.Show("No first names to populate with");
            }
            else
            {
                // print all the names in the array
                for (int i = 0; i < fnames.Length; i++)
                {
                    // TODO - sort the clients alphabetical order
                    nameOutputBox.Items.Add(fnames[i]);
                }
            }  
        }


        private void selectedName(object sender, SelectionChangedEventArgs e)
        {   
            /*
            
            */
        }

        private void EditBtnClick(object sender, RoutedEventArgs e)
        {
            if (nameOutputBox.SelectedItem == null) {
                MessageBox.Show("No client selected!");
            } else {
                string[] vs = nameOutputBox.SelectedItem.ToString().Split(null);

                Update update = new Update {
                    cusID = dataConnect.GetCus_ID(vs[0], vs[1])
                };
                update.Show();
            }
        }

        private void DeleteBtnClick(object sender, RoutedEventArgs e)
        {
            //get name and split and store
            string selectedName = nameOutputBox.SelectedItem.ToString();
            string[] firstAndLast = selectedName.Split(null);

            
            //delete all vehicles relating to the customer from db
            dataConnect.deleteVehicleFromDb(firstAndLast[0], firstAndLast[1]);

            //delete customer from db
            dataConnect.deleteCusFromDb(firstAndLast[0], firstAndLast[1]);


        }

        // when a client name is selected change the information displayed to that client
        private void ChangeClient(object sender, SelectionChangedEventArgs e) {
            //clear listboxes
            CusInformationListBox.Items.Clear();
            VehicleList.Items.Clear();

            //store selected name, then split it into first and last and store in array
            string selectedName = nameOutputBox.SelectedItem.ToString();
            string[] firstAndLast = selectedName.Split(null);

            //retrieve Cus_ID for retrieve vehicle, message box for debug
            string cus_ID = dataConnect.GetCus_ID(firstAndLast[0], firstAndLast[1]);
            MessageBox.Show(cus_ID);


            //Get array of VehicleInfo
            string[] vehicleInfo = dataConnect.RetrieveVehicleInfo(cus_ID);

            if (vehicleInfo.Length == 0) {
                MessageBox.Show("No vehicle information to populate with");
            }
            else {
                //print all vehicleinfo
                for (int i = 0; i < vehicleInfo.Length; i++) {
                    VehicleList.Items.Add(vehicleInfo[i]);
                }
            }

            //get array of cusinfo
            string[] cusInfo = dataConnect.retrieveCusInfo(firstAndLast[0], firstAndLast[1]);

            if (cusInfo.Length == 0) {
                MessageBox.Show("No customer information to populate with");
            }
            else {
                //print all cusinfo
                for (int i = 0; i < cusInfo.Length; i++) {
                    CusInformationListBox.Items.Add(firstAndLast[0] + " " + firstAndLast[1] + "\n");
                    CusInformationListBox.Items.Add(cusInfo[i]);
                }
            }
        }
    }
}
