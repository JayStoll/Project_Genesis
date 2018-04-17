using Microsoft.Win32;
using Project_Genesis_Source.Classes;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace Project_Genesis_Source {
    /// <summary>
    /// Interaction logic for Backup1.xaml
    /// </summary>
    public partial class Backup1 : Page {
        DatabaseConnection dataConn = new DatabaseConnection();

        // get the path of the database
        static string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        string dbName = path + @"\CAJNData\GenesisDB.mdf";

        // SQL manipulation
        SqlConnection sql = new SqlConnection();
        SqlCommand command = new SqlCommand();
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable data = new DataTable();

        public Backup1() {
            InitializeComponent();
        }

        // Backup database into a .bak file
        private void BackupDatabase(object sender, RoutedEventArgs e) {
            sql.ConnectionString = dataConn.connString;

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Backup File | *.bak";

            progressReport.Items.Clear();

            progressReport.Items.Add("Backing up your data please wait...");


            try {
                if (save.ShowDialog() == true) {
                    sql.Open();
                    // creates the backup file
                    command = new SqlCommand("BACKUP DATABASE [" + dbName + "] TO DISK='" + Path.GetFullPath(save.FileName) + "'", sql);
                    command.ExecuteNonQuery();
                    sql.Close();
                    MessageBox.Show("Backup successful!");
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message + " " + command.CommandText);
            }
            finally {
                progressReport.Items.Clear();
            }
        }

        // Recover the database with a .bak file
        private void RecoverData(object sender, RoutedEventArgs e) {
            sql.ConnectionString = dataConn.connString;
            progressReport.Items.Clear();

            try {
                OpenFileDialog file = new OpenFileDialog();
                file.Filter = "Backup File | *.bak";

                progressReport.Items.Add("Recovering your data please wait...");
                if (file.ShowDialog() == true) {
                    // sets up the database to be altered
                    string sqlCom = "ALTER DATABASE [" + dbName + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;";
                    // restore the database with the given .bak file
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
            finally {
                progressReport.Items.Clear();
            }
        }
    }
}
