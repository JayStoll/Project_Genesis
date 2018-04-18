using Project_Genesis_Source.Classes;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace Project_Genesis_Source {
    /// <summary>
    /// Interaction logic for Update.xaml
    /// </summary>
    public partial class Update : Window {
        DatabaseConnection data = new DatabaseConnection();

        // SQL manipulation
        SqlConnection sql = new SqlConnection();
        SqlCommand command = new SqlCommand();
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable dt = new DataTable();

        public string cusID;
        public Update(string id) {
            InitializeComponent();
            cusID = id;
            FillTextBoxes();
        }

        private void FillTextBoxes() {
            string[] fill = data.GetAllClientInformation(cusID);

            fNametxt.Text = fill[0];
            lNameTxt.Text = fill[1];
            CompanyTxt.Text = fill[2];
            addressTxt.Text = fill[3];
            phoneNumTxt.Text = fill[4];
            postalCodeTxt.Text = fill[5];
            emailTxt.Text = fill[6];
            boxNumtxt.Text = fill[7];
        }

        private void CloseForm(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void UpdateClient(object sender, RoutedEventArgs e) {
            sql.ConnectionString = data.connString;

            string query = "UPDATE Customer " +
                            "SET Cus_FName='" + fNametxt.Text
                            + "', Cus_LName='" + lNameTxt.Text
                            + "', Cus_Company='" + CompanyTxt.Text
                            + "', Cus_Address='" + addressTxt.Text
                            + "', Cus_Phone='" + phoneNumTxt.Text
                            + "', Cus_PostalCode='" + postalCodeTxt.Text
                            + "', Cus_Email='" + emailTxt.Text
                            + "', Cus_BoxNum='" + boxNumtxt.Text 
                            + "' " +
                            "WHERE Cus_ID='" + cusID + "'";

            try {
                sql.Open();
                // creates the backup file
                command = new SqlCommand(query, sql);
                command.ExecuteNonQuery();
                sql.Close();
                MessageBox.Show("Client info changed correctly!");
                this.Close();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message + " " + command.CommandText);
            }
        }

        //close button
        private void Close_Click(object sender, RoutedEventArgs e)
        {

        }

        //drag and drop code
        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
