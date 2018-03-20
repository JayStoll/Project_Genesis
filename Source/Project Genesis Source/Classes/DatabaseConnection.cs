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

namespace Project_Genesis_Source.Classes{

    // TODO - Fill in the information into the functions
    // TODO - Change the return types to return the proper information
    public class DatabaseConnection {

        //initailize 
        string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\GenesisDB.mdf;Integrated Security=True;Connect Timeout=30";
        SqlDataAdapter dataAdapater;
        System.Data.DataTable table;
        SqlCommandBuilder commandBuilder;
        SqlConnection conn;
        SqlCommand command;

        /// <summary>
        /// Add a new client to the database
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="mailingAddress"></param>
        /// <param name="postalCode"></param>
        /// <param name="phoneNumber"></param>
        public void AddNewClient(string firstName, string lastName, string mailingAddress, string phoneNumber) {
            // send the information to Customer - setting the email field to null
            string emailValue = null;

            //insert query to send to Customer
            string insertData = @"INSERT INTO Customer(Cus_FName, Cus_LName, Cus_Address, Cus_Phone, Cus_Email)
                                VALUES(@Cus_FName, @Cus_LName, @Cus_Address, @Cus_Phone, @Cus_Email)";

            using (conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    command = new SqlCommand(insertData, conn);
                    command.Parameters.AddWithValue(@"Cus_FName", firstName);
                    command.Parameters.AddWithValue(@"Cus_LName", lastName);
                    command.Parameters.AddWithValue(@"Cus_Address", mailingAddress);
                    command.Parameters.AddWithValue(@"Cus_Phone", mailingAddress);
                    command.Parameters.AddWithValue(@"Cus_Email", emailValue);
                    
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

        /// <summary>
        /// Add a new client to the database
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="mailingAddress">Includes Postal Code</param>
        /// <param name="phoneNumber"></param>
        /// <param name="email"></param>
        
        public void AddNewClient(string firstName, string lastName, string mailingAddress, string phoneNumber, string email) {
            // send the information to Customer with email
         
            //insert query to send to cCustomer
            string insertData = @"INSERT INTO Customer(Cus_FName, Cus_LName, Cus_Address, Cus_Phone, Cus_Email)
                                VALUES(@Cus_FName, @Cus_LName, @Cus_Address, @Cus_Phone, @Cus_Email)";

            using (conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    command = new SqlCommand(insertData, conn);
                    command.Parameters.AddWithValue(@"Cus_FName", firstName);
                    command.Parameters.AddWithValue(@"Cus_LName", lastName);
                    command.Parameters.AddWithValue(@"Cus_Address", mailingAddress);
                    command.Parameters.AddWithValue(@"Cus_Phone", phoneNumber);
                    command.Parameters.AddWithValue(@"Cus_Email", email);
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



        /// <summary>
        /// Add a new vehicle to the selected client and then to the database
        /// </summary>
        /// <param name="cusID">Foreign key from CUSTOMER</param>
        /// <param name="serialNumber"></param>
        /// <param name="vehicleType"></param>
        /// <param name="vehicleMake">Optional</param>
        /// <param name="modelNumber">Optional</param>
        /// <param name="vehicleNotes">Optional</param>
        public void AddNewVehicle(int cusID, string serialNumber, string vehicleType, string vehicleMake, string modelNumber, string vehicleNotes,
            string ownerFName, string ownerLName) {
            // send the information to the database
            
            //TODO CHANGE TO INT
            //select query to get Cus_ID
            string selectCusID = @"SELECT Cus_ID FROM Customer WHERE Cus_FName = " + ownerFName + "AND Cus_LName = " + ownerLName;

            //insert query to send to VEHICLE
            string insertVehicleData = @"INSERT INTO Vehicle(Cus_ID, Vehicle_SerialNum, Vehicle_Type, Vehicle_Make, Vehicle_Num, Vehicle_Notes)
                                VALUES(@Cus_ID, @Vehicle_SerialNum, @Vehicle_Type, @Vehicle_Make, @Vehicle_Num, @Vehicle_Notes)";

            using (conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    command = new SqlCommand(insertVehicleData, conn);
                    command.Parameters.AddWithValue(@"Cus_ID", selectCusID);
                    command.Parameters.AddWithValue(@"Vehicle_SerialNum", serialNumber);
                    command.Parameters.AddWithValue(@"Vehicle_Type", vehicleType);
                    command.Parameters.AddWithValue(@"Vehicle_Make", vehicleMake);
                    command.Parameters.AddWithValue(@"Vehicle_Num", modelNumber);
                    command.Parameters.AddWithValue(@"Vehicle_Notes", vehicleNotes);
                    
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

    
        /// <summary>
        /// Add a new part to the database
        /// </summary>
        // /// <param name="vehicleID">Foreign key from VEHICLE</param>
        /// <param name="partName"></param>
        /// <param name="serialNumber"></param>
        /// <param name="partNumber">Optional</param>
        /// <param name="partPrice"></param>
        /// <param name="partDescription">Optional</param>
        public void AddNewPart(int partId, string partName, string serialNumber, string partNumber, string partPrice, string partDescription)
        {
            // send the information to the database

            //insert query to send to PART
            string insertPartData = @"INSERT INTO Part(Part_Name, Part_SerialNum, Part_PartNum, Part_Price, Part_Desc)
                                VALUES(@Part_Name, @Part_SerialNum, @Part_PartNum, @Part_Price, @Part_Desc)";

            //insert query to send to VEHICLE_PART
            string insertVehiclePartData = @"INSERT INTO Vehicle_Part(Vehicle_ID, Part_ID)
                                                VALUES (@Vehicle_ID, @Part_ID)";

            //send values to Part and catch error
            using (conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    command = new SqlCommand(insertPartData, conn);
                    command.Parameters.AddWithValue(@"Part_Name", partName);
                    command.Parameters.AddWithValue(@"Part_SerialNum", serialNumber);
                    command.Parameters.AddWithValue(@"Part_PartNum", partNumber);
                    command.Parameters.AddWithValue(@"Part_Price", partPrice);
                    command.Parameters.AddWithValue(@"Part_Desc", partDescription);

                    conn.Close();
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

            //send values to VEHICLE_PART and catch error
            //placeholder for vehicleID until a query is made
            string vehicleID = null;
            using (conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    command = new SqlCommand(insertVehiclePartData, conn);
                    command.Parameters.AddWithValue(@"Vehicle_ID", vehicleID);
                    command.Parameters.AddWithValue(@"Part_ID", partId);

                    conn.Close();

                }
                catch (Exception ex)
                {
                    conn.Close();
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private static string GetInsertCommand(string insertVehiclePartData)
        {
            return insertVehiclePartData;
        }




        /// <summary>
        /// Add invoice information to the database
        /// </summary>
        /// <param name="labourTime"></param>
        /// <param name="labourRate"></param>
        /// <param name="taxRate"></param>
        public void AddNewInvoice(int labourTime, int labourRate, int taxRate) {
            // add the invoice information to the database
            // TODO - Fix this function to use the proper information
        }



        //
    }
}
