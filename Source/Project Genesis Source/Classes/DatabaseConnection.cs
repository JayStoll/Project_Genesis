using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using System.Windows;
using System.IO;

namespace Project_Genesis_Source.Classes {

    /// <summary>
    /// Connect and create querys to the database
    /// </summary>
    public class DatabaseConnection {
        //initailize 

        // change the path where the program looks for the database
        static string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + @"\CAJNData\GenesisDB.mdf;Integrated Security=True;Connect Timeout=30";

        public SqlConnection conn;
        SqlCommand command;

        /// <summary>
        /// Add a new client to the database
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="mailingAddress">Includes Postal Code</param>
        /// <param name="phoneNumber"></param>
        /// <param name="email"></param>
        public void AddNewClient(string firstName, string lastName, string mailingAddress, string phoneNumber, string email, string boxNum, string postalCode, string company) {
            // send the information to Customer with email

            //insert query to send to cCustomer
            string insertData = @"INSERT INTO Customer(Cus_FName, Cus_LName, Cus_Address, Cus_Phone, Cus_Email, Cus_BoxNum, Cus_PostalCode, Cus_Company)
                                VALUES(@Cus_FName, @Cus_LName, @Cus_Address, @Cus_Phone, @Cus_Email, @Cus_BoxNum, @Cus_PostalCode, @Cus_Company)";

            using (conn = new SqlConnection(connString)) {
                try {
                    conn.Open();
                    command = new SqlCommand(insertData, conn);
                    command.Parameters.AddWithValue(@"Cus_FName", firstName);
                    command.Parameters.AddWithValue(@"Cus_LName", lastName);
                    command.Parameters.AddWithValue(@"Cus_Address", mailingAddress);
                    command.Parameters.AddWithValue(@"Cus_Phone", phoneNumber);
                    command.Parameters.AddWithValue(@"Cus_Email", email);
                    command.Parameters.AddWithValue(@"Cus_BoxNum", boxNum);
                    command.Parameters.AddWithValue(@"Cus_PostalCode", postalCode);
                    command.Parameters.AddWithValue(@"Cus_Company", company);
                    command.ExecuteNonQuery();
                    MessageBox.Show(firstName + " " + lastName + " has been added");
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message + ": Error Occured");
                }
                finally {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// Add a new vehicle to the selected client and then to the database
        /// </summary>
        /// <param name="cusID">Foreign key from CUSTOMER</param>
        /// <param name="serialNumber"></param>
        /// <param name="vehicleType"></param>
        /// <param name="vehicleMake">Optional</param>
        /// <param name="modelNumber">Optional</param>
        /// <param name="vehicleNotes">Optional</param>

        public void AddNewVehicle(string serialNumber, string vehicleType, string vehicleMake, string modelNumber, string vehicleNotes,
           string ownerFName, string ownerLName) {

            // send vehicle information to Vehicle

            //initalize select query command
            SqlCommand selectCommand = new SqlCommand();

            //select query to get Cus_ID
            string selectCusID = @"SELECT Cus_ID FROM Customer WHERE Cus_FName = '" + ownerFName + "' AND Cus_LName = '" + ownerLName + "'";

            //insert query to send to VEHICLE
            string insertVehicleData = @"INSERT INTO Vehicle(Cus_ID, Vehicle_SerialNum, Vehicle_Type, Vehicle_Make, Vehicle_Num, Vehicle_Notes)
                                VALUES(@Cus_ID, @Vehicle_SerialNum, @Vehicle_Type, @Vehicle_Make, @Vehicle_Num, @Vehicle_Notes)";

            using (conn = new SqlConnection(connString)) {
                try {
                    conn.Open();
                    command = new SqlCommand(insertVehicleData, conn);
                    selectCommand = new SqlCommand(selectCusID, conn);

                    //store result of select query
                    int Cus_ID = Convert.ToInt32(selectCommand.ExecuteScalar());

                    command.Parameters.AddWithValue(@"Cus_ID", Cus_ID);
                    command.Parameters.AddWithValue(@"Vehicle_SerialNum", serialNumber);
                    command.Parameters.AddWithValue(@"Vehicle_Type", vehicleType);
                    command.Parameters.AddWithValue(@"Vehicle_Make", vehicleMake);
                    command.Parameters.AddWithValue(@"Vehicle_Num", modelNumber);
                    command.Parameters.AddWithValue(@"Vehicle_Notes", vehicleNotes);
                    command.ExecuteNonQuery();
                    MessageBox.Show(vehicleType + " " + vehicleMake + " " + serialNumber + " has been added");


                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message + ": Error occured while trying to add new vehicle");
                }
                finally {
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// Add a new part to the database
        /// </summary>
        // /// <param name="vehicleID">Foreign key from VEHICLE</param>
        /// <param name="partName"></param>
        /// <param name="serialNumber"></param>
        /// <param name="partNumber">Optional</param>
        /// <param name="partPrice"></param>
        /// <param name="partDescription">Optional</param>
        public void AddNewPart(string partName, string serialNumber, string partNumber, string partPrice, string partDescription) {
            // send the information to Part

            //insert query to send to PART
            string insertPartData = @"INSERT INTO Part(Part_Name, Part_SerialNum, Part_PartNum, Part_Price, Part_Desc)
                                VALUES(@Part_Name, @Part_SerialNum, @Part_PartNum, @Part_Price, @Part_Desc)";

            //send values to Part and catch error
            using (conn = new SqlConnection(connString)) {
                try {
                    conn.Open();

                    command = new SqlCommand(insertPartData, conn);
                    command.Parameters.AddWithValue(@"Part_Name", partName);
                    command.Parameters.AddWithValue(@"Part_SerialNum", serialNumber);
                    command.Parameters.AddWithValue(@"Part_PartNum", partNumber);
                    command.Parameters.AddWithValue(@"Part_Price", partPrice);
                    command.Parameters.AddWithValue(@"Part_Desc", partDescription);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Part added");

                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message + ": Error occured while trying to add part");
                }
                finally {
                    conn.Close();
                }
            }
        }

        ///<summary>
        ///Retrieve information for manage client
        /// </summary>
        public string[] RetrieveNames() {
            //select query to retrieve first and last name
            string selectFName = @"SELECT Cus_FName, Cus_LName FROM Customer ORDER BY Cus_FName ASC";

            // Creates a list that will hold all the information in the query
            List<string> fNames = new List<string>();

            using (conn = new SqlConnection(connString)) {
                try {
                    conn.Open();

                    command = new SqlCommand(selectFName, conn);
                    SqlDataReader reader = command.ExecuteReader();

                    int i = 0;
                    while (reader.Read()) {
                        fNames.Insert(i, reader["Cus_FName"].ToString() + " " + reader["Cus_LName"].ToString());
                        ++i;
                    }
                    reader.Close();
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
                finally {
                    conn.Close();
                }
            }

            // returns the list as an array
            return fNames.ToArray();

        }

        ///<summary>
        ///Get Cus_ID
        /// </summary>
        public string GetCus_ID(string Fname, string Lname)
        {

            int cus_ID = 0;
            //query to get cus id
            string selectCusID = @"SELECT Cus_ID FROM Customer WHERE Cus_FName = '" + Fname + "' AND Cus_LName = '" + Lname + "'";

            using (conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    command = new SqlCommand(selectCusID, conn);
                    cus_ID = Convert.ToInt32(command.ExecuteScalar());

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                    
                }
            }

            return Convert.ToString(cus_ID);

        }

        public string[] GetAllClientInformation(string id) {
            string query = "SELECT * FROM Customer WHERE Cus_ID='" + id + "'";

            List<string> clientInfo = new List<string>();

            using (conn = new SqlConnection(connString)) {
                try {
                    conn.Open();
                    //store command then execute
                    command = new SqlCommand(query, conn);
                    SqlDataReader reader = command.ExecuteReader();

                    //while the reader can read, insert into list
                    int i = 0;
                    while (reader.Read()) {
                        clientInfo.Insert(i,reader["Cus_FName"].ToString());
                        i++;
                        clientInfo.Insert(i, reader["Cus_LName"].ToString());
                        i++;
                        clientInfo.Insert(i, reader["Cus_Company"].ToString());
                        i++;
                        clientInfo.Insert(i, reader["Cus_Address"].ToString());
                        i++;
                        clientInfo.Insert(i, reader["Cus_Phone"].ToString());
                        i++;
                        clientInfo.Insert(i, reader["Cus_PostalCode"].ToString());
                        i++;
                        clientInfo.Insert(i, reader["Cus_Email"].ToString());
                        i++;
                        clientInfo.Insert(i, reader["Cus_BoxNum"].ToString());
                        i++;
                    }
                    reader.Close();
                }
                catch (Exception ex) {
                    MessageBox.Show(ex + ":error occured (Db connection)");
                }
                finally {
                    conn.Close();
                }

            }
            //convert list to array then return
            return clientInfo.ToArray();
        }

        ///<summary>
        ///Retrieve Vehicle Names
        /// </summary>
        public string[] RetrieveVehicleInfo (string cus_ID)
        {
            //select query to retrieve vehicle name, type
            string selectVehicle = @"SELECT Vehicle_Make, Vehicle_Type FROM Vehicle WHERE Cus_ID = '" + cus_ID +"'";

            //create list to hold results of query
            List<string> VehicleInfo = new List<string>();

            using (conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    //store command then execute
                    command = new SqlCommand(selectVehicle, conn);
                    SqlDataReader reader = command.ExecuteReader();

                    //while the reader can read, insert into list
                    int i = 0;
                    while (reader.Read())
                    {
                        VehicleInfo.Insert(i, reader["Vehicle_Make"].ToString() + " " + reader["Vehicle_Type"].ToString());
                        i++;
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex + ":error occured (Db connection)");
                }
                finally
                {
                    conn.Close();
                }

            }
            //convert list to array then return
            return VehicleInfo.ToArray();
        }


        ///<summary>
        ///Retrieve Customer Information
        /// </summary>
        public string[] retrieveCusInfo(string fname, string lname)
        {
            //select query for customer info
            string selectCusInfo = @"SELECT Cus_Company, Cus_Address, Cus_Phone, Cus_Email, Cus_BoxNum, Cus_PostalCode FROM Customer
                                        WHERE Cus_FName = '" + fname + "' AND Cus_LName = '" + lname + "'";

            //list to store results
            List<string> cusInfo = new List<string>();

            using (conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    //store command then execute
                    command = new SqlCommand(selectCusInfo, conn);
                    SqlDataReader reader = command.ExecuteReader();

                    //while it can read, insert into list
                    //can this be an array since it will have a static number of indexes??
                    int i = 0;
                    while (reader.Read())
                    {
                        cusInfo.Insert(i, reader["Cus_Company"].ToString() + "\n\n" + reader["Cus_Address"].ToString() + "\n \n" + reader["Cus_Phone"].ToString() + "\n \n"
                                        + reader["Cus_Email"].ToString() + "\n \n" + reader["Cus_BoxNum"].ToString() + "\n \n"
                                        + reader["Cus_PostalCode"]);
                        i++;
                    }
                    reader.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }

            return cusInfo.ToArray();
        } 

        public string[] ReturnMissingClientInfo(string FName, string LName) {
            string query = "SELECT Cus_Company, Cus_PostalCode, Cus_BoxNum " +
                "FROM Customer " +
                "WHERE Cus_FName='" + FName + "' AND Cus_LName='" + LName + "'";

            List<string> vs = new List<string>();

            using (conn = new SqlConnection(connString)) {
                try {
                    conn.Open();
                    //store command then execute
                    command = new SqlCommand(query, conn);
                    SqlDataReader reader = command.ExecuteReader();

                    //while it can read, insert into list
                    int i = 0;
                    while (reader.Read()) {
                        vs.Insert(i, reader["Cus_Company"].ToString());
                        i++;
                        vs.Insert(i, reader["Cus_PostalCode"].ToString());
                        i++;
                        vs.Insert(i, reader["Cus_BoxNum"].ToString());
                    }
                    reader.Close();
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }
                finally {
                    conn.Close();
                }
            }

            return vs.ToArray();
        }
        

        /// <summary>
        /// Deletes all CUSTOMER TABLE data
        /// </summary>
        public void deleteCusFromDb(string FName, string LName)
        {

            //query string to drop customer from table
            string deleteCusQuery = "DELETE FROM Customer WHERE Cus_FName = '" + FName + "' AND Cus_LName = '" + LName + "'";

            using (conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    command = new SqlCommand(deleteCusQuery, conn);
                    command.ExecuteNonQuery();
                    MessageBox.Show(FName + " " + LName + "has been deleted");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
   
        ///<summary>
        ///Deletes all vehicle data for customer to be deleted
        /// </summary>
        public void deleteVehicleFromDb(string FName, string LName)
        {
            //get customer id 
            string cus_ID = GetCus_ID(FName, LName);

            //query to delete vehicle
            string deleteVehicleQuery = "DELETE FROM Vehicle WHERE Cus_ID = '" + cus_ID + "'";

            using (conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    command = new SqlCommand(deleteVehicleQuery, conn);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Vehicles belonging to " + FName + " " + LName + " have been deleted");

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        





        public double GetPartPrice(string selectedPart) {
            string getSelectedPartInfo = "SELECT Part_Price FROM Part WHERE Part_Name='" + selectedPart + "'";

            using (conn = new SqlConnection(connString)) {
                conn.Open();
                SqlCommand command = new SqlCommand(getSelectedPartInfo, conn);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) {
                    double pricePart = Double.Parse(reader["Part_Price"].ToString());
                    return pricePart;
                }
            }

            // only returns if there was an error
            return 0.0;
        }

    }


}
