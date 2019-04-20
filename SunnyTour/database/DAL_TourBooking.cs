using System.Data.SqlClient;
using System.Configuration;
using System;

namespace SunnyTour
{
    public class DAL_TourBooking
    {

        string connectionString = ConfigurationManager.ConnectionStrings["dbSunnyTour"].ConnectionString;
        SqlConnection connection;


        public int insertTourBooking(int tourSeqNo, string userId, string travelerNumber, string travelDate)
        {
            int counter = 0;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                string query = "Insert into tbTourBooking (tourSeqNo, userId, bookingStatus, travelerNumber, travelDate, createDate)"
                    + " values(" + tourSeqNo + ", '" + userId + "', 'G001_001', '" + travelerNumber + "', '" + travelDate + "', GETDATE())";
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
        public int updateTourBookingStatus(int tourBookingSeqNo, string bookingStatus)
        {
            int counter = 0;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                string query = "Update tbTourBooking set bookingStatus = '" + bookingStatus
                    + "', updateDate =  GETDATE() where tourBookingSeqNo=" + tourBookingSeqNo;
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


        public int updateTourBooking(int tourBookingSeqNo, string travelDate, string travelerNumber)
        {
            int counter = 0;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                string query = "Update tbTourBooking set travelDate = '"+ travelDate+"', travelerNumber = '" + travelerNumber
                    + "', updateDate =  GETDATE() where tourBookingSeqNo=" + tourBookingSeqNo;
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
        public int deleteTourBooking(int tourBookingSeqNo)
        {
            int counter = 0;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                string query = "Delete from tbTourBooking where tourBookingSeqNo=" + tourBookingSeqNo;
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
        public SqlDataReader getTourBookingDetail(int tourBookingSeqNo)
        {
            SqlDataReader reader = null;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                string query = "SELECT A.userId, B.firstName, B.lastName, C.tourRegion, C.tourTitle, C.imageUrl, C.price, A.travelerNumber, A.bookingStatus AS bookingStatusCode"
                    + ", (select codeName from tbCommonCode where bookingStatus = codeNo) AS bookingStatus"
                    + ", travelerNumber, A.createDate, tourBookingSeqNo, B.phoneNumber, convert(varchar, travelDate, 23) AS travelDate"
                    + " FROM tbTourBooking A, tbUser B, tbTour C"
                    + " where A.userId = B.userId"
                    + " and A.tourSeqNo = C.tourSeqNo"
                    + " and A.tourBookingSeqNo =" + tourBookingSeqNo;
                SqlCommand command = new SqlCommand(query, connection);
                reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.ToString());
            }
            
            return reader;
        }


        public SqlDataReader getTourBookingList(string tourBookingSeqNo)
        {
            SqlDataReader reader = null;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                string query = "SELECT  C.tourRegion, C.tourTitle, A.travelerNumber, A.bookingStatus AS bookingStatusCode"
                    +", (select codeName from tbCommonCode where bookingStatus = codeNo) AS bookingStatus"
                    + ", convert(varchar, travelDate, 103) AS travelDate, tourBookingSeqNo"
                    + ", Case when discountType = 'G005_001' then ((C.price - IsNull(discountValue,0)) * travelerNumber) else ((C.price - (C.price * IsNull(discountValue,0) / 100)) * travelerNumber) End AS price "
                    + " FROM tbTour C, tbTourBooking AS A Left Outer join tbPromotion AS B"
                    + " ON A.tourSeqNo = B.productSeqId "
                    + " where A.tourSeqNo = C.tourSeqNo"
                    +" and A.tourBookingSeqNo in (" + tourBookingSeqNo+")";
                SqlCommand command = new SqlCommand(query, connection);
                reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.ToString());
            }

            return reader;
        }


        public SqlDataReader getTotalPrice(string tourBookingSeqNo)
        {
            SqlDataReader reader = null;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                string query = "select sum(Case when B.discountType = 'G005_001' then ((C.price - IsNull(discountValue,0)) * A.travelerNumber) else ((C.price - (C.price * IsNull(discountValue,0) / 100)) * travelerNumber) End) AS totalPrice"
                        +" FROM tbTour C, tbTourBooking AS A Left Outer join tbPromotion AS B"
                        +" ON A.tourSeqNo = B.productSeqId"
                        +" where A.tourSeqNo = C.tourSeqNo"
                        +" and A.tourBookingSeqNo in (" + tourBookingSeqNo + ")";
                SqlCommand command = new SqlCommand(query, connection);
                reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.ToString());
            }

            return reader;
        }

        public SqlDataReader getMyTourBooking(string userId)
        {
            SqlDataReader reader = null;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                string query = "Select A.tourBookingSeqNo, (select codeName from tbCommonCode where codeNo = A.bookingStatus) AS bookingStatus"
                    + ", A.bookingStatus AS bookingStatusCode"
                    + ", A.travelerNumber, travelDate, A.createDate, B.tourTitle, B.price, B.tourRegion, B.imageUrl"
                    + " from tbTourBooking A, tbTour B"
                    + " where A.tourSeqNo = B.tourSeqNo"
                    + " and A.userId = '" + userId + "'";

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