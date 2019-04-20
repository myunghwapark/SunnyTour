using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using System.Configuration;

namespace SunnyTour
{
    public class DAL_Shuttle
    {
        SqlConnection connection;
        public DAL_Shuttle()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["dbSunnyTour"].ConnectionString;
                connection = new SqlConnection(connectionString);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.ToString());
            }
            
        }

        public int addShuttleBooking(string userId, string shuttleType, string pickupLocation, string dropOffLocation, int passengerNumber, string pickupTime)
        {
            int counter = 0;
            try
            {
                connection.Open();
                string query = "Insert into tbShuttleBooking (userId, bookingStatus, shuttleType, pickupLocation, dropOffLocation, passengerNumber, pickupTime, createDate)"
                    + " values('" + userId + "', 'G001_001', '" + shuttleType + "', '" + pickupLocation + "', '" + dropOffLocation + "', " + passengerNumber + ", '" + pickupTime + "', GETDATE())";
                SqlCommand command = new SqlCommand(query, connection);
                counter = command.ExecuteNonQuery();

                //connection.Close();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.ToString());
            }
            return counter;

        }

        public SqlDataReader getShuttleList()
        {
            SqlDataReader reader = null;
            try
            {
                connection.Open();
                string query = "Select shuttleBookingSeqNo, userId, (select codeName from tbCommonCode where shuttleType = codeNo) AS shuttleType" +
                    ", (select codeName from tbCommonCode where bookingStatus = codeNo) AS bookingStatus " +
                    ", pickupLocation, dropOffLocation, pickupTime from tbShuttleBooking where bookingStatus = 'G001_002'";

                SqlCommand command = new SqlCommand(query, connection);
                reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.ToString());
            }
            
            //connection.Close();
            return reader;
        }

        public SqlDataReader getShuttleDetail(int shuttleBookingSeqNo)
        {
            SqlDataReader reader = null;

            try
            {
                connection.Open();
                string query = "Select shuttleBookingSeqNo, A.userId, B.firstName, B.lastName, B.phoneNumber, passengerNumber"
                    + ", (select codeName from tbCommonCode where shuttleType = codeNo) AS shuttleType, shuttleType AS shuttleTypeCode"
                    + ", pickupLocation, dropOffLocation, convert(varchar, pickupTime, 8) AS pickupTime, convert(varchar, pickupTime, 23) AS pickupDate, A.createDate "
                    + ", (select codeName from tbCommonCode where bookingStatus = codeNo) AS bookingStatus, bookingStatus AS bookingStatusCode"
                    + " from tbShuttleBooking A, tbUser B"
                    + " where A.userId = B.userId"
                    + " and shuttleBookingSeqNo = " + shuttleBookingSeqNo;

                SqlCommand command = new SqlCommand(query, connection);
                reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.ToString());
            }
            
            //connection.Close();
            return reader;
        }
        public int updateShuttleBooking(int shuttleBookingSeqNo, string shuttleType, string pickupLocation, string dropOffLocation, string passengerNumber, string pickupTime)
        {
            int counter = 0;
            try
            {
                connection.Open();
                string query = "Update tbShuttleBooking set shuttleType='" + shuttleType + "',  pickupLocation='" + pickupLocation + "'" +
                    ",  dropOffLocation='" + dropOffLocation + "',  passengerNumber='" + passengerNumber + "'" +
                    ",  pickupTime='" + pickupTime + "' where shuttleBookingSeqNo=" + shuttleBookingSeqNo;
                SqlCommand command = new SqlCommand(query, connection);
                counter = command.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.ToString());
            }

            //connection.Close();
            return counter;
        }
        public int updateShuttleBookingStatus(int shuttleBookingSeqNo, string bookingStatus)
        {
            int counter = 0;
            try
            {
                connection.Open();
                string query = "Update tbShuttleBooking set bookingStatus='" + bookingStatus + "' where shuttleBookingSeqNo=" + shuttleBookingSeqNo;
                SqlCommand command = new SqlCommand(query, connection);
                counter = command.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.ToString());
            }
            
            //connection.Close();
            return counter;
        }
        public int deleteShuttleBooking(int shuttleBookingSeqNo)
        {
            int counter = 0;
            try
            {
                connection.Open();

                string query = "Delete tbShuttleBooking where shuttleBookingSeqNo=" + shuttleBookingSeqNo;
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
        public SqlDataReader getMyShuttleBooking(string userId)
        {
            SqlDataReader reader = null;

            try
            {
                connection.Open();

                string query = "Select shuttleBookingSeqNo, (select codeName from tbCommonCode where codeNo = bookingStatus) AS bookingStatus"
                + ", bookingStatus AS bookingStatusCode, shuttleType AS shuttleTypeCode"
                + ", (select codeName from tbCommonCode where codeNo = shuttleType) AS shuttleType"
                + ", pickupLocation, dropOffLocation, passengerNumber, pickupTime, createDate"
                + " from tbShuttleBooking"
                + " where userId = '" + userId + "'";

                SqlCommand command = new SqlCommand(query, connection);
                reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.ToString());
            }
            
            return reader;
        }
    }
}