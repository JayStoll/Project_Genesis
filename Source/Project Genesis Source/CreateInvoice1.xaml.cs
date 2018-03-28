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

        SqlDataAdapter customerAdapter;
        DatabaseConnection dc = new DatabaseConnection();

        public CreateInvoice1()
        {
            InitializeComponent();
        }

        private void GetClientInfo() {
            string sqlString = @"SELECT Cus_FName, Cus_LName from Customer";

            customerAdapter = new SqlDataAdapter(sqlString, dc.connString);
            GenesisDBDataSet set = new GenesisDBDataSet();
            customerAdapter.Fill(set, "Customer");
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
