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

        string dbName = "GenesisDB.mdf";
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

            string backupDestination = @"CAJNBackup\";

            if (!System.IO.Directory.Exists(backupDestination))     System.IO.Directory.CreateDirectory(backupDestination);

            try {
                sql.Open();
                command = new SqlCommand("backup database " + dbName + " to disk='" + backupDestination + DateTime.Now.ToString("ddMMyyyy_HHmmss") + ".Bak'", sql);
                command.ExecuteNonQuery();
                sql.Close();
                MessageBox.Show("Backup successful!");
            }
#pragma warning disable CS0168 // Variable is declared but never used
            catch (Exception ex){
#pragma warning restore CS0168 // Variable is declared but never used
                MessageBox.Show("error during backup");
            }
        }
    }
}
