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



namespace Project_Genesis_Source
{
    /// <summary>
    /// Interaction logic for CreateInvoice1.xaml
    /// </summary>
    public partial class CreateInvoice1 : Page
    {

        // SqlDataAdapter customerAdapter;
        SqlCommand customerAdapter;
        DatabaseConnection dc = new DatabaseConnection();

        public CreateInvoice1()
        {
            InitializeComponent();

            GetClientInfo();
        }

        private void GetClientInfo() {
            var conn = dc.conn;

            using (conn = new SqlConnection(dc.connString)) {
                try {
                    string sqlString = "SELECT Cus_FName from Customer";

                    customerAdapter = new SqlCommand(sqlString, conn);
                    conn.Open();
                    SqlDataReader test = customerAdapter.ExecuteReader();
                    while (test.Read()) {
                        //MessageBox.Show(test["Cus_FName"].ToString());
                        //GenesisDBDataSet set = new GenesisDBDataSet();
                        //customerAdapter.Fill(set, "Customer");
                        //Client.DisplayMemberPath = "CustomerName";
                        //Client.DataContext = test["Cus_FName"];
                        Client.Items.Add(test["Cus_FName"]);
                    }
                } catch (Exception ex) {
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
    }
}
