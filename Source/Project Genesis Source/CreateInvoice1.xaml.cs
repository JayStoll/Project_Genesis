using Project_Genesis_Source.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.Sql;
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
    /// Interaction logic for CreateInvoice1.xaml
    /// </summary>
    public partial class CreateInvoice1 : Page {

        DatabaseConnection dataConnection = new DatabaseConnection();
        int partsAdded = 0;              // keeps track of the amount of parts being added into the invoice
        double totalCostOfParts = 0.00;  // keeps track of the total cost of parts

        public CreateInvoice1() {
            InitializeComponent();

            GetClientInfo();
            FillPartInfo();
        }

        private void GetClientInfo() {
            // get the first and last name of the clients
            string[] names = dataConnection.RetrieveNames();

            for (int i = 0; i < names.Length; i++) {
                // add all the clients to the drop down
                ClientDropDown.Items.Add(names[i]);
            }
        }

        private void FillPartInfo() {
            var conn = dataConnection.conn;
            string partQuery = "SELECT Part_Name FROM Part ORDER BY Part_Name ASC";

            using (conn = new SqlConnection(dataConnection.connString)) {
                conn.Open();
                SqlCommand command = new SqlCommand(partQuery, conn);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) {
                    // add all the parts to the part combobox
                    PartDropDown.Items.Add(reader["Part_Name"]);
                }
            }
            
        }

        //Client DropDowns
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            // clears the combobox when a new client is selected
            VehicleDropDown.Items.Clear();
            var conn = dataConnection.conn;

            // Gets the first and last name of the entered client - splits at a space
            string[] names = ClientDropDown.SelectedItem.ToString().Split(null);
            
            string getClientInfo = @"SELECT Customer.*, Vehicle.* 
                                    FROM Customer, Vehicle 
                                    WHERE Cus_FName = '" + names[0] + "' AND Cus_LName = '" + names[1] + "' AND Vehicle.Cus_ID=Customer.Cus_ID";

            using (conn = new SqlConnection(dataConnection.connString)) {
                try {
                    conn.Open();
                    // gets the query and puts it in the database
                    SqlCommand getClientQuery = new SqlCommand(getClientInfo, conn);
                    // executes and creates a reader based on the executed query
                    SqlDataReader fillInfo = getClientQuery.ExecuteReader();
                    // fill out the text boxes based off the information
                    while (fillInfo.Read()) {
                        CusFNameTxt.Text = fillInfo["Cus_FName"].ToString();
                        CusLnameTxt.Text = fillInfo["Cus_LName"].ToString();
                        CusAddressTxt.Text = fillInfo["Cus_Address"].ToString();
                        CusPhoneTxt.Text = fillInfo["Cus_Phone"].ToString();

                        // fill the second combobox with information from the vehicle table
                        VehicleDropDown.Items.Add(fillInfo["Vehicle_Type"]);
                    }
                    fillInfo.Close();
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.ToString());
                }
                finally {
                    conn.Close();
                }
            }
        }

        // vehicle dropdown
        private void VehicleSelectionChanged(object sender, SelectionChangedEventArgs e) {
            var conn = dataConnection.conn;

            try {
                string vehicle = VehicleDropDown.SelectedItem.ToString();

                // MessageBox.Show(vehicle);
                string getVehicleInfo = @"SELECT * FROM  Vehicle WHERE Vehicle_Type = '" + vehicle + "'";

                using (conn = new SqlConnection(dataConnection.connString)) {
                    try {
                        conn.Open();
                        SqlCommand command = new SqlCommand(getVehicleInfo, conn);
                        SqlDataReader fillInfo = command.ExecuteReader();
                        while (fillInfo.Read()) {
                            VehicleTxt.Text = fillInfo["Vehicle_Type"].ToString();
                            VehicleSerialNumtxt.Text = fillInfo["Vehicle_SerialNum"].ToString();
                        }
                        fillInfo.Close();
                    }
                    catch (Exception ex) {
                        MessageBox.Show(ex.ToString());
                    }
                    finally {
                        conn.Close();
                    }
                }
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (Exception ex) {
#pragma warning restore CS0168 // Variable is declared but never used
                // when an error happens - just clear the text
                VehicleTxt.Text = "";
                VehicleSerialNumtxt.Text = "";
            }
        }

        // part dropdown
        private void PartSelectionChanged(object sender, SelectionChangedEventArgs e) {
            var conn = dataConnection.conn;

            try {
                string selectedPart = PartDropDown.SelectedItem.ToString();
                string getSelectedPartInfo = "SELECT * FROM Part WHERE Part_Name='" + selectedPart + "'";

                using (conn = new SqlConnection(dataConnection.connString)) {
                    conn.Open();
                    SqlCommand command = new SqlCommand(getSelectedPartInfo, conn);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read()) {
                        PartTxt.Text = reader["Part_Name"].ToString();
                        var price = reader["Part_Price"];
                        PriceTxt.Text = string.Format("{0:F2}", price);
                    }
                }
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (Exception ex) {
#pragma warning restore CS0168 // Variable is declared but never used
                PartTxt.Text = "";
                PriceTxt.Text = "";
            }   
        }

        private void AddPart(object sender, RoutedEventArgs e) {
            // add the price of the part to the total cost
            totalCostOfParts += dataConnection.GetPartPrice(PartDropDown.SelectedItem.ToString());

            totalCosttxt.Content = totalCostOfParts.ToString();
            // adds the part name to the total cost of parts
            PartsAddedList.Items.Add(PartDropDown.SelectedItem.ToString());
            PartDropDown.SelectedIndex = -1;
            partsAdded++;
        }

        private void RemovePart(object sender, RoutedEventArgs e) { 
            // sends error if there are no parts to be removed
            if (partsAdded == 0)
                MessageBox.Show("No parts to remove!");
            else {
                try {
                    try {
                        // deletes the price of the entered part
                        string temp = PartsAddedList.SelectedItem.ToString();
                        totalCostOfParts -= dataConnection.GetPartPrice(temp);
                    } 
#pragma warning disable CS0168 // Variable is declared but never used
                    catch (Exception ex) { }
#pragma warning restore CS0168 // Variable is declared but never used

                    // deletes the entered part from the list
                    PartsAddedList.Items.RemoveAt(PartsAddedList.SelectedIndex);
                    partsAdded--;
                    totalCosttxt.Content = totalCostOfParts.ToString();
                }
#pragma warning disable CS0168 // Variable is declared but never used
                catch (Exception ex) {
#pragma warning restore CS0168 // Variable is declared but never used
                    MessageBox.Show("No Item selected!");
                }
            }
        }

        private void CreateInvoice(object sender, RoutedEventArgs e) {
            GeneratePDF();
        }

        private void GeneratePDF() {
            string[] missingInfo = dataConnection.ReturnMissingClientInfo(CusFNameTxt.Text, CusLnameTxt.Text);

            // fill the client info class
            ClientInfo client = new ClientInfo {
                ClientFName = CusFNameTxt.Text,
                ClientLName = CusLnameTxt.Text,
                Address = CusAddressTxt.Text,
                CO = c_oBoxTxt.Text,
                Company = missingInfo[0],
                PostalCode = missingInfo[1],
                BoxNum = missingInfo[2],
                Vehicle = VehicleDropDown.SelectedItem.ToString()
            };

            // fill the labour info class
            LabourInfo labour = new LabourInfo {
                QtyAmount = hoursWorkedTxt.Text,
                Rate = rateTxt.Text,
                Labour = LabourTxt.Text,
                Tax = gstTxt.Text
            };

            // get a list of the parts used
            string partsUsed = string.Empty;
            foreach (var item in PartsAddedList.Items) {
                partsUsed += item + ", ";
            }

            // fills in the part info class
            PartInfo part = new PartInfo {
                AmountOfParts = partsAdded.ToString(),
                PartsUsed = partsUsed,
                PartTotal = totalCosttxt.Content.ToString()
            };

            // creates a new invoice
            CreatePDF invoice = new CreatePDF();
            invoice.CreateInvoice(client, labour, part, int.Parse(taxRateTxt.Text));
        }



        //AJ Santillan March 28, 2018
        //Watermarks

        //watermark for rate
        private void rateTxt_LostFocus(object sender, RoutedEventArgs e) {
            if (string.IsNullOrEmpty(rateTxt.Text)) {
                rateTxt.Visibility = System.Windows.Visibility.Collapsed;
                rateTxtWatermark.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void rateTxtWatermark_GotFocus(object sender, RoutedEventArgs e) {
            rateTxtWatermark.Visibility = System.Windows.Visibility.Collapsed;
            rateTxt.Visibility = System.Windows.Visibility.Visible;
            rateTxt.Focus();
        }


        //watermark for GST TAX
        private void gstTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(gstTxt.Text)) {
                gstTxt.Visibility = System.Windows.Visibility.Collapsed;
                gstTxtWatermark.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void gstTxtWatermark_GotFocus(object sender, RoutedEventArgs e)
        {
            gstTxtWatermark.Visibility = System.Windows.Visibility.Collapsed;
            gstTxt.Visibility = System.Windows.Visibility.Visible;
            gstTxt.Focus();
        }

        //C/O Box
        private void c_oBoxTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(c_oBoxTxt.Text))
            {
                c_oBoxTxt.Visibility = System.Windows.Visibility.Collapsed;
                c_oBoxTxtWatermark.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void c_oBoxTxtWatermark_GotFocus(object sender, RoutedEventArgs e)
        {
            c_oBoxTxtWatermark.Visibility = System.Windows.Visibility.Collapsed;
            c_oBoxTxt.Visibility = System.Windows.Visibility.Visible;
            c_oBoxTxt.Focus();
        }


        //Hours worked
        private void hoursWorkedTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(hoursWorkedTxt.Text))
            {
                hoursWorkedTxt.Visibility = System.Windows.Visibility.Collapsed;
                hoursWorkedTxtWatermark.Visibility = System.Windows.Visibility.Visible;
            }

        }

        private void hoursWorkedTxtWatermark_GotFocus(object sender, RoutedEventArgs e)
        {
            hoursWorkedTxtWatermark.Visibility = System.Windows.Visibility.Collapsed;
            hoursWorkedTxt.Visibility = System.Windows.Visibility.Visible;
            hoursWorkedTxt.Focus();
        }


        //TaxRate
        private void taxRateTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(taxRateTxt.Text))
            {
                taxRateTxt.Visibility = System.Windows.Visibility.Collapsed;
                taxRateTxtWatermark.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void taxRateTxtWatermark_GotFocus(object sender, RoutedEventArgs e)
        {
            taxRateTxtWatermark.Visibility = System.Windows.Visibility.Collapsed;
            taxRateTxt.Visibility = System.Windows.Visibility.Visible;
            taxRateTxt.Focus();
        }
    }
}
