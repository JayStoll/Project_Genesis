using Project_Genesis_Source.Classes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Project_Genesis_Source
{
    /// <summary>
    /// Interaction logic for AddVehicle1.xaml
    /// </summary>
    public partial class AddVehicle1 : Page
    {
        DatabaseConnection dc = new DatabaseConnection();
        public AddVehicle1()
        {
            InitializeComponent();

            GetClientInfo();
        }

        private void GetClientInfo() {
            // get the first and last name of the clients
            string[] names = dc.RetrieveNames();

            for (int i = 0; i < names.Length; i++) {
                // add all the clients to the drop down
                clientname.Items.Add(names[i]);
            }
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
            string[] names = clientname.SelectedItem.ToString().Split(null);

            //TODO Error checking
            //send information to database connection
            dataConnect.AddNewVehicle(serialNum, type, make, modelNumber, notes, names[0], names[1]);
            AddVehicle1 create = new AddVehicle1();
            NavigationService.Navigate(create);


        }

        private void ClearText()
        {

            //clear all text boxes
            serialNumTxt.Text = "";
            typeTxt.Text = "";
            makeTxt.Text = "";
            modelNumTxt.Text = "";
            notesTxt.Text = "";
        }
        //AJ Santillan  March 28, 2018
        //Watermarks Codes


        //vehicle Serial Numbers
        private void serialNumTxtWatermark_GotFocus(object sender, RoutedEventArgs e)
        {
            serialNumTxtWatermark.Visibility = System.Windows.Visibility.Collapsed;
            serialNumTxt.Visibility = System.Windows.Visibility.Visible;
            serialNumTxt.Focus();
        }

        private void serialNumTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(serialNumTxt.Text))
            {
                serialNumTxt.Visibility = System.Windows.Visibility.Collapsed;
                serialNumTxtWatermark.Visibility = System.Windows.Visibility.Visible;
            }
        }


        //vehicle TYPE
        private void typeTxtWatermark_GotFocus(object sender, RoutedEventArgs e)
        {
            typeTxtWatermark.Visibility = System.Windows.Visibility.Collapsed;
            typeTxt.Visibility = System.Windows.Visibility.Visible;
            typeTxt.Focus();
        }

        private void typeTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(typeTxt.Text))
            {
                typeTxt.Visibility = System.Windows.Visibility.Collapsed;
                typeTxtWatermark.Visibility = System.Windows.Visibility.Visible;
            }
        }



        //vehicle MAKE
        private void makeTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(makeTxt.Text))
            {
                makeTxt.Visibility = System.Windows.Visibility.Collapsed;
                makeTxtWatermark.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void makeTxtWatermark_GotFocus(object sender, RoutedEventArgs e)
        {
            makeTxtWatermark.Visibility = System.Windows.Visibility.Collapsed;
            makeTxt.Visibility = System.Windows.Visibility.Visible;
            makeTxt.Focus();
        }


        //vehicle MODEL
        private void modelNumTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(modelNumTxt.Text))
            {
                modelNumTxt.Visibility = System.Windows.Visibility.Collapsed;
                modelNumTxtWatermark.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void modelNumTxtWatermark_GotFocus(object sender, RoutedEventArgs e)
        {
            modelNumTxtWatermark.Visibility = System.Windows.Visibility.Collapsed;
            modelNumTxt.Visibility = System.Windows.Visibility.Visible;
            modelNumTxt.Focus();
        }


        //owners FIRSTNAME
        /*private void ownerFNameTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(ownerFNameTxt.Text))
            {
                ownerFNameTxt.Visibility = System.Windows.Visibility.Collapsed;
                ownerFNameTxtWatermark.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void ownerFNameTxtWatermark_GotFocus(object sender, RoutedEventArgs e)
        {
            ownerFNameTxtWatermark.Visibility = System.Windows.Visibility.Collapsed;
            ownerFNameTxt.Visibility = System.Windows.Visibility.Visible;
            ownerFNameTxt.Focus();
        }


        //owners LASTNAME
        private void ownerLNameTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(ownerLNameTxt.Text))
            {
                ownerLNameTxt.Visibility = System.Windows.Visibility.Collapsed;
                ownerLNameTxtWatermark.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void ownerLNameTxtWatermark_GotFocus(object sender, RoutedEventArgs e)
        {
            ownerLNameTxtWatermark.Visibility = System.Windows.Visibility.Collapsed;
            ownerLNameTxt.Visibility = System.Windows.Visibility.Visible;
            ownerLNameTxt.Focus();
        }*/
    }
}
