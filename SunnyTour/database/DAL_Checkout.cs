using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using System.Configuration;

using SunnyTour.model;

namespace SunnyTour
{
    public class DAL_Checkout
    {
        string connectionString = ConfigurationManager.ConnectionStrings["dbSunnyTour"].ConnectionString;
        SqlConnection connection;
        

        public int insertCheckout(Checkout checkout)
        {
            int counter = 0;
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                string query = "INSERT INTO tbCheckOut (serviceType, serviceSeqId, userId, firstName, lastName, phoneNumber, paymentType, nameOnCard" +
                    ",creditCardType, creditCardNumber, expirationMonth, expirationYear, cardVerificationNumber, paidStatus, payAmount, createDate) "
                    + " VALUES('"+ checkout.serviceType + "', '"+ checkout.serviceSeqId + "', '" + checkout.userId + "', '" + checkout.firstName + "'" +
                    ", '"+ checkout.lastName + "', '"+ checkout.phoneNumber + "', '"+ checkout.paymentType + "', '"+ checkout.nameOnCard + "'" +
                    ", '"+ checkout.creditCardType + "', '"+ checkout.creditCardNumber + "', '"+ checkout.expirationMonth + "', '"+ checkout.expirationYear + "'" +
                    ", '"+ checkout.cardVerificationNumber + "', '" + checkout.paidStatus + "', '"+checkout.payAmount+"', GETDATE());";
                SqlCommand command = new SqlCommand(query, connection);
                counter = command.ExecuteNonQuery();

                connection.Close();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.ToString());
            }
            
            return counter;
        }
        
    }
}