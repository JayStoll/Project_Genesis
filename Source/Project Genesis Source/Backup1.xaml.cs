using Microsoft.Win32;
using Project_Genesis_Source.Classes;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace Project_Genesis_Source
{
    /// <summary>
    /// Interaction logic for Backup1.xaml
    /// </summary>
    public partial class Backup1 : Page
    {
        DatabaseConnection dataConn = new DatabaseConnection();

        // get the path of the database
        static string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        string dbName = path + @"\CAJNData\GenesisDB.mdf";
        string backupDestination = path + @"\CAJNBackup\";

        // SQL manipulation
        SqlConnection sql = new SqlConnection();
        SqlCommand command = new SqlCommand();
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable data = new DataTable();

        public Backup1()
        {
            InitializeComponent();
        }

        private void BackupDatabase(object sender, RoutedEventArgs e) {
            sql.ConnectionString = dataConn.connString;

            

            // create backup directory if it doesn't exsist
            if (!System.IO.Directory.Exists(backupDestination))     System.IO.Directory.CreateDirectory(backupDestination);

            try {
                sql.Open();
                // creates the backup file
                command = new SqlCommand("BACKUP DATABASE [" + dbName + "] TO DISK='" + backupDestination + DateTime.Now.ToString("dd-MM-yyyy") + ".bak'", sql);
                command.ExecuteNonQuery();
                sql.Close();
                MessageBox.Show("Backup successful!");
            }
            catch (Exception ex){
                MessageBox.Show(ex.Message + " " + command.CommandText);
            }
        }

        private void RecoverData(object sender, RoutedEventArgs e) {
            sql.ConnectionString = dataConn.connString;

            try {
                OpenFileDialog file = new OpenFileDialog();
                file.Filter = "Backup File | *.bak";
                if (file.ShowDialog() == true) {
                    // creates the backup file
                    string sqlCom = "ALTER DATABASE [" + dbName + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;";
                    sqlCom += "RESTORE DATABASE [" + dbName + "] FROM DISK='" + file.FileName + "' WITH REPLACE";
                    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB; Initial Catalog=master;Integrated Security=True");
                    command = new SqlCommand(sqlCom, con);

                    con.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Recover successful!");
                    con.Close();
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
