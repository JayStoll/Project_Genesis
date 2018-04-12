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

        DatabaseConnection dc = new DatabaseConnection();
        int partsAdded = 0;              // keeps track of the amount of parts being added into the invoice
        double totalCostOfParts = 0.00;  // keeps track of the total cost of parts

        public CreateInvoice1() {
            InitializeComponent();

            GetClientInfo();
            FillPartInfo();
        }

        private void GetClientInfo() {
            // create a variable that will store the connection string stuff
            var conn = dc.conn;

            using (conn = new SqlConnection(dc.connString)) {
                try {
                    // get the first and last name of the client from the database
                    string sqlString = "SELECT Cus_FName, Cus_LName FROM Customer";

                    SqlCommand customerAdapter = new SqlCommand(sqlString, conn);
                    conn.Open();
                    SqlDataReader fillComboBox = customerAdapter.ExecuteReader();
                    // fill the combobox with all the queried information
                    while (fillComboBox.Read())
                        // TODO - sort the information alphabetically
                        ClientDropDown.Items.Add(fillComboBox["Cus_FName"] + " " + fillComboBox["Cus_LName"]);
                    fillComboBox.Close();
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.ToString());
                }
                finally {
                    conn.Close();
                }
            }
        }

        private void FillPartInfo() {
            var conn = dc.conn;
            string partQuery = "SELECT Part_Name FROM Part";

            using (conn = new SqlConnection(dc.connString)) {
                conn.Open();
                SqlCommand command = new SqlCommand(partQuery, conn);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) {
                    PartDropDown.Items.Add(reader["Part_Name"]);
                }
            }
        }

        //Client DropDowns
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            // clears the combobox when a new client is selected
            VehicleDropDown.Items.Clear();
            var conn = dc.conn;

            // Gets the first and last name of the entered client - slpits at a space
            string[] names = ClientDropDown.SelectedItem.ToString().Split(null);
            // MessageBox.Show(names[0] + " " + names[1]);
            
            string getClientInfo = @"SELECT Customer.*, Vehicle.* 
                                    FROM Customer, Vehicle 
                                    WHERE Cus_FName = '" + names[0] + "' AND Cus_LName = '" + names[1] + "' AND Vehicle.Cus_ID=Customer.Cus_ID";

            using (conn = new SqlConnection(dc.connString)) {
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
            var conn = dc.conn;
            try {
                string vehicle = VehicleDropDown.SelectedItem.ToString();

                // MessageBox.Show(vehicle);
                string getVehicleInfo = @"SELECT * FROM  Vehicle WHERE Vehicle_Type = '" + vehicle + "'";

                using (conn = new SqlConnection(dc.connString)) {
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
            catch (Exception ex) {
                // when an error happens - just clear the text
                VehicleTxt.Text = "";
                VehicleSerialNumtxt.Text = "";
            }
        }

        // part dropdown
        private void PartSelectionChanged(object sender, SelectionChangedEventArgs e) {
            var conn = dc.conn;

            try {
                string selectedPart = PartDropDown.SelectedItem.ToString();
                string getSelectedPartInfo = "SELECT * FROM Part WHERE Part_Name='" + selectedPart + "'";

                using (conn = new SqlConnection(dc.connString)) {
                    conn.Open();
                    SqlCommand command = new SqlCommand(getSelectedPartInfo, conn);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read()) {
                        PartTxt.Text = reader["Part_Name"].ToString();
                        PriceTxt.Text = reader["Part_Price"].ToString();
                    }
                }
            }
            catch (Exception ex) {
                PartTxt.Text = "";
                PriceTxt.Text = "";
            }   
        }

        private void AddPart(object sender, RoutedEventArgs e) {
            // add the price of the part to the total cost
            totalCostOfParts += dc.GetPartPrice(PartDropDown.SelectedItem.ToString());

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
                        totalCostOfParts -= dc.GetPartPrice(temp);
                    } 
                    catch (Exception ex) { }

                    // deletes the entered part from the list
                    PartsAddedList.Items.RemoveAt(PartsAddedList.SelectedIndex);
                    partsAdded--;
                    totalCosttxt.Content = totalCostOfParts.ToString();
                }
                catch (Exception ex) {
                    MessageBox.Show("No Item selected!");
                }
            }
        }

        private void CreateInvoice(object sender, RoutedEventArgs e) {
            GeneratePDF();
        }

        private void GeneratePDF() {
            string[] missingInfo = dc.ReturnMissingClientInfo(CusFNameTxt.Text, CusLnameTxt.Text);
            MessageBox.Show(c_oBoxTxt.Text);
            MessageBox.Show(missingInfo[0] + " " + missingInfo[1] + " " + missingInfo[2]);
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

            LabourInfo labour = new LabourInfo {
                QtyAmount = hoursWorkedTxt.Text,
                Rate = rateTxt.Text,
                Labour = LabourTxt.Text,
                Tax = gstTxt.Text
            };

            string partsUsed = string.Empty;

            foreach (var item in PartsAddedList.Items) {
                partsUsed += item + ", ";
            }

            PartInfo part = new PartInfo {
                AmountOfParts = partsAdded.ToString(),
                PartsUsed = partsUsed,
                PartTotal = totalCosttxt.Content.ToString()
            };

            CreatePDF invoice = new CreatePDF();
            invoice.CreateInvoice(client, labour, part, int.Parse(rateTxt.Text));
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
    }
}
