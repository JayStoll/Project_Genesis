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

        public CreateInvoice1() {
            InitializeComponent();

            GetClientInfo();
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

        private void CreateInvoice_Click(object sender, RoutedEventArgs e) {
            // get the information from the text boxes
            // send that information to the correct method in the PythonConnection class
            // when all the functions were called
            // create a new PDF file
            // store the PDF in the database - maybe?
        }

        //Client DropDowns
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var conn = dc.conn;
            string[] names = ClientDropDown.SelectedItem.ToString().Split(null);
            // MessageBox.Show(names[0] + " " + names[1]);
            string getClientInfo = @"SELECT * FROM Customer WHERE Cus_FName = '" + names[0] + "' AND Cus_LName = '" + names[1] + "'";

            using (conn = new SqlConnection(dc.connString)) {
                try {
                    conn.Open();
                    SqlCommand getClientQuery = new SqlCommand(getClientInfo, conn);
                    SqlDataReader fillInfo = getClientQuery.ExecuteReader();
                    while (fillInfo.Read()) {
                        CusFNameTxt.Text = fillInfo["Cus_FName"].ToString();
                        CusLnameTxt.Text = fillInfo["Cus_LName"].ToString();
                        CusAddressTxt.Text = fillInfo["Cus_Address"].ToString();
                        CusPhoneTxt.Text = fillInfo["Cus_Phone"].ToString();
                    }
                    fillInfo.Close();
                } catch (Exception ex) {
                    MessageBox.Show(ex.ToString());
                }
                finally {
                    conn.Close();
                }
            }
        }

        //Vehicle DropDown
        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e) {

        }




        //AJ Santillan March 28, 2018
        //Watermarks

        //watermark on type
  


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
