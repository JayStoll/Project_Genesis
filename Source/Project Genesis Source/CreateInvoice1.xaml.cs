using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        public CreateInvoice1()
        {
            InitializeComponent();
        }

        private void CustomerSearchTextInput(object sender, TextCompositionEventArgs e)
        {
            //initialize command & connection
            SqlCommand command = new SqlCommand();
            string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\GenesisDB.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection conn = new SqlConnection();

            string nameToSearch = SearchBar1.Text;

            //setup query
            string selectFNameforAutoFill = @"SELECT * From Customer WHERE Cus_FName = " + nameToSearch;

            //setup command with select string
            command = new SqlCommand(selectFNameforAutoFill, conn);
            SqlDataReader dataRead = command.ExecuteReader();

            using (conn = new SqlConnection(connString))
            {
                conn.Open();

                while (dataRead.Read())
                {
                    //get correct data and change textbox
                    string fName = (string)dataRead["Cus_FName"].ToString();
                    CusFNameTxt.Text = fName;

                    string lName = (string)dataRead["Cus_LName"].ToString();
                    CusLnameTxt.Text = lName;

                    string address = (string)dataRead["Cus_Address"].ToString();
                    CusAddressTxt.Text = address;

                    string phoneNum = (string)dataRead["Cus_Phone"].ToString();
                    CusPhoneTxt.Text = phoneNum;

                }
            }
        }
    }
}
