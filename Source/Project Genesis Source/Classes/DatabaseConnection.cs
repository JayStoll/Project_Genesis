using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Genesis_Source.Classes {

    // TODO - Fill in the information into the functions
    // TODO - Change the return types to return the proper information
    public class DatabaseConnection {

        /// <summary>
        /// Add a new client to the database
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="mailingAddress"></param>
        /// <param name="postalCode"></param>
        /// <param name="phoneNumber"></param>
        public void AddNewClient(string firstName, string lastName, string mailingAddress, string postalCode, string phoneNumber) {
            // send the information to the database - setting the email field to null
        }

        /// <summary>
        /// Add a new client to the database
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="mailingAddress"></param>
        /// <param name="postalCode"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="email"></param>
        public void AddNewClient(string firstName, string lastName, string mailingAddress, string postalCode, string phoneNumber, string email) {
            // send the information to the database
        }

        /// <summary>
        /// Add a new vehicle to the selected client and then to the database
        /// </summary>
        /// <param name="clientID"></param>
        /// <param name="serialNumber"></param>
        /// <param name="vehicleType"></param>
        /// <param name="vehicleMake">Optional</param>
        /// <param name="modelNumber">Optional</param>
        /// <param name="vehicleNotes">Optional</param>
        public void AddNewVehicle(int clientID, string serialNumber, string vehicleType, string vehicleMake, string modelNumber, string vehicleNotes) {
            // send the information to the database
        }

        /// <summary>
        /// Add a new part to the database
        /// </summary>
        /// <param name="partName"></param>
        /// <param name="serialNumber"></param>
        /// <param name="partNumber">Optional</param>
        /// <param name="partPrice"></param>
        /// <param name="partDescription">Optional</param>
        public void AddNewPart(string partName, string serialNumber, string partNumber, string partPrice, string partDescription) {
            // send the information to the database
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
    }
}
