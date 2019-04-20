using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using System.Configuration;

namespace SunnyTour
{
    public class DAL_Tour
    {
        string connectionString = ConfigurationManager.ConnectionStrings["dbSunnyTour"].ConnectionString;
        SqlConnection connection;

        public SqlDataReader getCommonCode(string codeGroup)
        {
            SqlDataReader reader = null;
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                string query = "SELECT codeGroup, codeNo, codeName from tbCommonCode where codeGroup = '" + codeGroup + "'";
                SqlCommand command = new SqlCommand(query, connection);
                reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.ToString());
            }
            
            return reader;
        }

        public SqlDataReader getTourList()
        {
            SqlDataReader reader = null;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                string query = "Select tourSeqNo, price, tourTitle, tourRegion, tourStatus, imageUrl, description, createDate from tbTour where tourStatus = 'G001_002' ";
                SqlCommand command = new SqlCommand(query, connection);
                reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                //connection.Close();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.ToString());
            }
            
            return reader;
        }
        public SqlDataReader getTourDropdownList()
        {
            SqlDataReader reader = null;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                string query = "Select tourSeqNo, tourTitle from tbTour where tourStatus = 'G001_002' ";
                SqlCommand command = new SqlCommand(query, connection);
                reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                //connection.Close();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.ToString());
            }

            return reader;
        }
        public SqlDataReader getAllTourList(string keyword, string orderNumber)
        {
            SqlDataReader reader = null;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                string query = "Select tourSeqNo, price, tourTitle, tourRegion, tourStatus, imageUrl, description from tbTour where 1=1";
                if(keyword != null && !keyword.Equals(""))
                {
                    query += " and tourTitle like '%"+keyword+"%'";
                }

                if (orderNumber.Equals("1"))
                {
                    query += " order by createDate desc";
                }
                else if (orderNumber.Equals("2"))
                {
                    query += " order by price desc";
                }
                else if (orderNumber.Equals("3"))
                {
                    query += " order by price asc";
                }


                SqlCommand command = new SqlCommand(query, connection);
                reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                //connection.Close();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.ToString());
            }
            
            return reader;
        }


        public SqlDataReader getPromotionTourList(string keyword, string orderNumber)
        {
            SqlDataReader reader = null;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                string query = "SELECT  tourSeqNo, Case when discountType = 'G005_001' then (A.price - IsNull(discountValue,0)) else (A.price - (A.price * IsNull(discountValue,0) / 100)) End AS price , "
                            + " tourTitle, tourRegion, tourStatus, A.imageUrl, description,"
                            + " promotionSeqNo, (select codeName from tbCommonCode where promotionType = codeNo) AS promotionType, promotionType AS promotionTypeCode,"
                            + " startDate, endDate, (select codeName from tbCommonCode where discountType = codeNo) AS discountType, discountType AS discouontTypeCode"
                            + " FROM tbTour A, tbPromotion B"
                            + " where 1 = 1"
                            + " and A.tourSeqNo = B.productSeqId"
                            + " and B.startDate <= GETDATE() and B.endDate >= GETDATE() and B.promotionStatus = 'G001_002'"
                            + " and B.promotionType = 'G004_001'";
                

                if (keyword != null)
                {
                    query += " and tourTitle like '%" + keyword + "%'";
                }

                if (orderNumber.Equals("1"))
                {
                    query += " order by A.createDate desc";
                }
                else if (orderNumber.Equals("2"))
                {
                    query += " order by price desc";
                }
                else if (orderNumber.Equals("3"))
                {
                    query += " order by price asc";
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

        public SqlDataReader getTourDetail(int tourSeqNo)
        {
            SqlDataReader reader = null;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                string query = "SELECT tourSeqNo, price, tourTitle, tourRegion, tourStatus, A.imageUrl, description, A.createDate, B.discountType, B.discountValue,  "
                    + "convert(varchar, B.startDate, 103) AS promotionStartDate, convert(varchar, B.endDate, 103) AS promotionEndDate "
                    + " FROM tbTour AS A Left Outer join tbPromotion AS B ON A.tourSeqNo = B.productSeqId "
                    + " and convert(varchar, startDate, 23) <= convert(varchar, GETDATE(), 23) and convert(varchar, endDate, 23) >= convert(varchar, GETDATE(), 23)"
                    + " where tourSeqNo = " + tourSeqNo;
                SqlCommand command = new SqlCommand(query, connection);
                reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                //connection.Close();
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.ToString());
            }
            
            return reader;
        }

        public int insertTour(string tourTitle, string tourRegion, string price, string imageUrl, string tourStatus, string description)
        {
            int counter = 0;
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                string query = "Insert into tbTour (tourTitle, tourRegion, price, imageUrl, tourStatus, description, createDate)"
                    + " values('" + tourTitle + "', '" + tourRegion + "', '" + price + "','" + imageUrl + "', 'G001_002','" + description + "', GETDATE())";
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

        public int deleteTour(int tourSeqNo)
        {
            int counter = 0;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                string query = "Delete tbTour where tourSeqNo=" + tourSeqNo;
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

        public int updateTour(int tourSeqNo, string tourTitle, string price, string tourRegion, string imageUrl, string tourStatus)
        {
            int counter = 0;
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                string query = "Update tbTour set tourTitle='" + tourTitle + "', price='" + price + "', tourRegion='" + tourRegion + "', imageUrl='" + imageUrl + "', tourStatus='" + tourStatus +
                    "' where tourSeqNo=" + tourSeqNo;
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