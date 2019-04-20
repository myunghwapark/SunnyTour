using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using System.Configuration;

namespace SunnyTour
{
    public class DAL_User
    {
        string connectionString = ConfigurationManager.ConnectionStrings["dbSunnyTour"].ConnectionString;
        SqlConnection connection;

        public SqlDataReader GetUserList(string userType)
        {
            SqlDataReader reader = null;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                string query = "select userSeqNo, userId, firstName, lastName, phoneNumber, "
                               +" (select codeName from tbCommonCode where codeNo = userType) AS userType,"
                               +" userType as userTypeCode, createDate from tbUser where 1=1";

                if(userType != null && !userType.Equals(""))
                {
                    query += " and userType = '" + userType + "'";
                }
                SqlCommand command = new SqlCommand(query, connection);
                reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.ToString());
            }

            return reader;

        }

        public SqlDataReader GetTop10PurchaseUsers(string userType)
        {
            SqlDataReader reader = null;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                string query = "select AA.userSeqNo, AA.userId, AA.firstName, AA.lastName, AA.phoneNumber, "
                              + "(select codeName from tbCommonCode where codeNo = AA.userType) AS userType, BB.payAmount, AA.createDate"
                              + " from tbUser AA,"
                              + " ("
                              + " SELECT TOP 10 A.userId, sum(A.payAmount) AS payAmount"
                              + " from tbCheckOut A"
                              + " group by A.userId order by payAmount"
                              + " ) BB"
                              + " where AA.userId = BB.userId";
                if (userType != null && !userType.Equals(""))
                {
                    query += " and AA.userType = '" + userType + "'";
                }

                query += " order by payAmount";

                SqlCommand command = new SqlCommand(query, connection);
                reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.ToString());
            }

            return reader;

        }


        public SqlDataReader GetTop10BookingUsers(string userType)
        {
            SqlDataReader reader = null;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                string query = "select AA.userSeqNo, AA.userId, AA.firstName, AA.lastName, AA.phoneNumber, "
                              + "(select codeName from tbCommonCode where codeNo = AA.userType) AS userType, BB.bookingCnt, AA.createDate"
                              + " from tbUser AA,"
                              + " ("
                              + " SELECT TOP 10 A.userId, count(A.userId) bookingCnt"
                              + " FROM tbTourBooking A"
                              + " group by A.userId order by bookingCnt"
                              + " ) BB"
                              + " where AA.userId = BB.userId";
                if (userType != null && !userType.Equals(""))
                {
                    query += " and AA.userType = '" + userType + "'";
                }

                query += " order by bookingCnt";

                SqlCommand command = new SqlCommand(query, connection);
                reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.ToString());
            }

            return reader;

        }

        public int login(string userId, string password)
        {
            int counter = 0;
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                string query = "Select count(userId) cnt from tbUser where userId='" + userId + "' and userPassword='" + password + "'";
                SqlCommand command = new SqlCommand(query, connection);
                counter = (int)command.ExecuteScalar();

                connection.Close();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.ToString());
            }
            
            return counter;
        }


        public int staffLogin(string userId, string password)
        {
            int counter = 0;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                string query = "Select count(userId) cnt from tbUser where userId='" + userId + "' and userPassword='" + password + "' and userType='G002_002'";
                SqlCommand command = new SqlCommand(query, connection);
                counter = (int)command.ExecuteScalar();

                connection.Close();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.ToString());
            }
            
            return counter;
        }


        public SqlDataReader GetUserInfo(string userId)
        {
            SqlDataReader reader = null;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                string query = "Select userSeqNo, userId, firstName, lastName, phoneNumber, userPassword,  "
                                 + "(select codeName from tbCommonCode where codeNo = userType) AS userType, "
                                 + " userType as userTypeCode, createDate from tbUser where userId='" + userId + "'";

                SqlCommand command = new SqlCommand(query, connection);
                reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.ToString());
            }

            return reader;

        }

        public int GetUserId(string userId)
        {
            int counter = 0;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                string query = "Select count(userId) cnt from tbUser where userId='" + userId + "'";
                SqlCommand command = new SqlCommand(query, connection);
                counter = (int)command.ExecuteScalar();

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.ToString());
            }
            
            return counter;

        }

        public int InsertUser(string userId, string firstName, string lastName, string phoneNumber, string userType, string password)
        {
            int result = 0;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                string encryptPassword = Security.GetHash256(password, userId);
                string query = "Insert into tbUser (userId, firstName, lastName, phoneNumber, userType, userPassword, createDate)" +
                    "values ('" + userId + "', '" + firstName + "', '" + lastName + "', '" + phoneNumber + "', '" + userType + "', '" + encryptPassword + "', GETDATE())";

                SqlCommand command = new SqlCommand(query, connection);
                result = command.ExecuteNonQuery();

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.ToString());
            }
            
            return result;

        }

        public int UpdateUser(string userId, string firstName, string lastName, string phoneNumber, string userType, string password)
        {
            int result = 0;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                string encryptPassword = Security.GetHash256(password, userId);
                string query = "Update tbUser set firstName = '" + firstName + "', lastName = '" + lastName + "'" +
                    ", phoneNumber = '" + phoneNumber + "', userType = '" + userType + "', userPassword = '" + encryptPassword + "', updateDate = GETDATE()" +
                    " where userId='" + userId + "'";

                SqlCommand command = new SqlCommand(query, connection);
                result = command.ExecuteNonQuery();

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.ToString());
            }
            
            return result;

        }

        public int DeleteUser(string userId)
        {
            int result = 0;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                string query = "Delete from tbUser where userId = '" + userId + "'";

                SqlCommand command = new SqlCommand(query, connection);
                result = command.ExecuteNonQuery();

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.ToString());
            }
            
            return result;

        }

        public int UpdateUserPassword(string userId, string password)
        {
            int result = 0;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();
                string encryptPassword = Security.GetHash256(password, userId);
                string query = "Update tbUser set userPassword = '" + encryptPassword + "', updateDate = GETDATE()" +
                    " where userId='" + userId + "'";

                SqlCommand command = new SqlCommand(query, connection);
                result = command.ExecuteNonQuery();

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.ToString());
            }

            return result;

        }
    }
}