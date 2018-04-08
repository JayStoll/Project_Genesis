﻿using Project_Genesis_Source.Classes;
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
    /// Interaction logic for AddVehicle1.xaml
    /// </summary>
    public partial class AddVehicle1 : Page
    {
        DatabaseConnection dc = new DatabaseConnection();
        public AddVehicle1()
        {
            InitializeComponent();

            GetClientInfo();
        }

        private void GetClientInfo() {
            // create a variable that will store the connection string stuff
            var conn = dc.conn;

            using (conn = new SqlConnection(dc.connString)) {
                try {
                    // get the first and last name of the client from the database
                    string sqlString = "SELECT Cus_FName, Cus_LName FROM Customer";

                    SqlCommand customerAdapter = new SqlCommand(sqlString, conn);
                    conn.Open();
                    SqlDataReader fillComboBox = customerAdapter.ExecuteReader();
                    // fill the combobox with all the queried information
                    while (fillComboBox.Read())
                        // TODO - sort the information alphabetically
                        clientname.Items.Add(fillComboBox["Cus_FName"] + " " + fillComboBox["Cus_LName"]);
                    fillComboBox.Close();
                }
                catch (Exception ex) {
                    MessageBox.Show(ex.ToString());
                }
                finally {
                    conn.Close();
                }
            }
        }

        private void AddVehicleButton_Click(object sender, RoutedEventArgs e)
        {

            //initialize dataconnection variable
            DatabaseConnection dataConnect = new DatabaseConnection();

            string serialNum = serialNumTxt.Text;
            string type = typeTxt.Text;
            string make = makeTxt.Text;
            string modelNumber = modelNumTxt.Text;
            string notes = notesTxt.Text;
            string[] names = clientname.SelectedItem.ToString().Split(null);

            //TODO Error checking
            //send information to database connection
            dataConnect.AddNewVehicle(serialNum, type, make, modelNumber, notes, names[0], names[1]);
            ClearText();
            

        }

        private void ClearText()
        {

            //clear all text boxes
            serialNumTxt.Text = "";
            typeTxt.Text = "";
            makeTxt.Text = "";
            modelNumTxt.Text = "";
            notesTxt.Text = "";
        }
        //AJ Santillan  March 28, 2018
        //Watermarks Codes


        //vehicle Serial Numbers
        private void serialNumTxtWatermark_GotFocus(object sender, RoutedEventArgs e)
        {
            serialNumTxtWatermark.Visibility = System.Windows.Visibility.Collapsed;
            serialNumTxt.Visibility = System.Windows.Visibility.Visible;
            serialNumTxt.Focus();
        }

        private void serialNumTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(serialNumTxt.Text))
            {
                serialNumTxt.Visibility = System.Windows.Visibility.Collapsed;
                serialNumTxtWatermark.Visibility = System.Windows.Visibility.Visible;
            }
        }


        //vehicle TYPE
        private void typeTxtWatermark_GotFocus(object sender, RoutedEventArgs e)
        {
            typeTxtWatermark.Visibility = System.Windows.Visibility.Collapsed;
            typeTxt.Visibility = System.Windows.Visibility.Visible;
            typeTxt.Focus();
        }

        private void typeTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(typeTxt.Text))
            {
                typeTxt.Visibility = System.Windows.Visibility.Collapsed;
                typeTxtWatermark.Visibility = System.Windows.Visibility.Visible;
            }
        }



        //vehicle MAKE
        private void makeTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(makeTxt.Text))
            {
                makeTxt.Visibility = System.Windows.Visibility.Collapsed;
                makeTxtWatermark.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void makeTxtWatermark_GotFocus(object sender, RoutedEventArgs e)
        {
            makeTxtWatermark.Visibility = System.Windows.Visibility.Collapsed;
            makeTxt.Visibility = System.Windows.Visibility.Visible;
            makeTxt.Focus();
        }


        //vehicle MODEL
        private void modelNumTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(modelNumTxt.Text))
            {
                modelNumTxt.Visibility = System.Windows.Visibility.Collapsed;
                modelNumTxtWatermark.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void modelNumTxtWatermark_GotFocus(object sender, RoutedEventArgs e)
        {
            modelNumTxtWatermark.Visibility = System.Windows.Visibility.Collapsed;
            modelNumTxt.Visibility = System.Windows.Visibility.Visible;
            modelNumTxt.Focus();
        }


        //owners FIRSTNAME
        /*private void ownerFNameTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(ownerFNameTxt.Text))
            {
                ownerFNameTxt.Visibility = System.Windows.Visibility.Collapsed;
                ownerFNameTxtWatermark.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void ownerFNameTxtWatermark_GotFocus(object sender, RoutedEventArgs e)
        {
            ownerFNameTxtWatermark.Visibility = System.Windows.Visibility.Collapsed;
            ownerFNameTxt.Visibility = System.Windows.Visibility.Visible;
            ownerFNameTxt.Focus();
        }


        //owners LASTNAME
        private void ownerLNameTxt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(ownerLNameTxt.Text))
            {
                ownerLNameTxt.Visibility = System.Windows.Visibility.Collapsed;
                ownerLNameTxtWatermark.Visibility = System.Windows.Visibility.Visible;
            }
        }

        private void ownerLNameTxtWatermark_GotFocus(object sender, RoutedEventArgs e)
        {
            ownerLNameTxtWatermark.Visibility = System.Windows.Visibility.Collapsed;
            ownerLNameTxt.Visibility = System.Windows.Visibility.Visible;
            ownerLNameTxt.Focus();
        }*/
    }
}
