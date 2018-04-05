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

        // SqlDataAdapter customerAdapter;
        SqlCommand customerAdapter;
        DatabaseConnection dc = new DatabaseConnection();

        public CreateInvoice1() {
            InitializeComponent();

            GetClientInfo();
        }

        private void GetClientInfo() {
            var conn = dc.conn;

            using (conn = new SqlConnection(dc.connString)) {
                try {
                    string sqlString = "SELECT Cus_FName, Cus_LName FROM Customer";

                    customerAdapter = new SqlCommand(sqlString, conn);
                    conn.Open();
                    SqlDataReader fillComboBox = customerAdapter.ExecuteReader();
                    while (fillComboBox.Read()) 
                        ClientDropDown.Items.Add(fillComboBox["Cus_FName"] + " " + fillComboBox["Cus_LName"]);
                    fillComboBox.Close();
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.ToString());
                }

            }
            
            conn.Close();
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
            string[] names = ClientDropDown.SelectedItem.ToString().Split(null);
            CusFNameTxt.Text = names[0];
            CusLnameTxt.Text = names[1];
        }

        //Vehicle DropDown
        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e) {

        }


        //AJ Santillan March 28, 2018
        //Watermarks

/*
        //First Search Bar for Searching Client Names
        //This one dont work at the moment Needs fixing
        private void SearchBar1_LostFocus(object sender, RoutedEventArgs e) {
            if (string.IsNullOrEmpty(SearchBar1.Text)) {
                SearchBar1.Visibility = System.Windows.Visibility.Collapsed;
                SearchBar1Watermark.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void SearchBar1Watermark_GotFocus(object sender, RoutedEventArgs e) {
            SearchBar1Watermark.Visibility = System.Windows.Visibility.Collapsed;
            SearchBar1.Visibility = System.Windows.Visibility.Visible;
            SearchBar1.Focus();
        }*/



        //watermark on type
        private void typeTxt_LostFocus(object sender, RoutedEventArgs e) {
            if (string.IsNullOrEmpty(typeTxt.Text)) {
                typeTxt.Visibility = System.Windows.Visibility.Collapsed;
                typeTxtWatermark.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void typeTxtWatermark_GotFocus(object sender, RoutedEventArgs e) {
            typeTxtWatermark.Visibility = System.Windows.Visibility.Collapsed;
            typeTxt.Visibility = System.Windows.Visibility.Visible;
            typeTxt.Focus();
        }


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
        private void gstTxt_LostFocus(object sender, RoutedEventArgs e) {
            if (string.IsNullOrEmpty(gstTxt.Text)) {
                gstTxt.Visibility = System.Windows.Visibility.Collapsed;
                gstTxtWatermark.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void gstTxtWatermark_GotFocus(object sender, RoutedEventArgs e) {
            gstTxtWatermark.Visibility = System.Windows.Visibility.Collapsed;
            gstTxt.Visibility = System.Windows.Visibility.Visible;
            gstTxt.Focus();
        }
    }
}
