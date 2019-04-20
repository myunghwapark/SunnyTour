using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using System.Configuration;

using SunnyTour.model;

namespace SunnyTour
{
    public class DAL_Promotion
    {
        string connectionString = ConfigurationManager.ConnectionStrings["dbSunnyTour"].ConnectionString;
        SqlConnection connection;
        
        public SqlDataReader getPromotionList(string keyword, string startDate, string endDate, string promotionType)
        {
            SqlDataReader reader = null;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                string query = "SELECT promotionTitle, promotionSeqNo, (select codeName from tbCommonCode where promotionType = codeNo) AS promotionType, promotionType AS promotionTypeCode, "
                            + "productSeqId, startDate, endDate, (select codeName from tbCommonCode where discountType = codeNo) AS discountType, discountType AS discouontTypeCode " +
                            "FROM tbPromotion where 1=1";


                if (keyword != null && !keyword.Equals(""))
                {
                    query += " and promotionTitle like '%" + keyword + "%'";
                }
                if(startDate != null && !startDate.Equals(""))
                {
                    query += " and startDate <= '"+startDate+"'";
                }
                if (endDate != null && !endDate.Equals(""))
                {
                    query += " and endDate >= '" + endDate+"'";
                }
                if (promotionType != null && !promotionType.Equals(""))
                {
                    if(promotionType.Equals("1"))
                    {
                        query += " and promotionType = 'G004_001'";
                    }
                    else if (promotionType.Equals("2"))
                    {
                        query += " and promotionType = 'G004_002'";
                    }

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
        public SqlDataReader getPromotionDetail(int promotionSeqNo)
        {
            SqlDataReader reader = null;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                string query = "SELECT promotionSeqNo, (select codeName from tbCommonCode where promotionType = codeNo) AS promotionType, promotionType AS promotionTypeCode, " +
                    "productSeqId, (select codeName from tbCommonCode where discountType = codeNo) AS discountType, discountType AS discouontTypeCode, discountValue" +
                    ", convert(varchar, startDate, 23)	AS startDate, convert(varchar, endDate, 23) AS endDate, B.imageUrl, thumbnailImageUrl, promotionTitle, promotionContent, linkUrl, " +
                    "(select codeName from tbCommonCode where promotionStatus = codeNo) AS promotionStatus, promotionStatus AS promotionStatusCode, A.createDate, B.promotionTitle  " +
                    "FROM tbTour AS A Left Outer join tbPromotion AS B ON A.tourSeqNo = B.productSeqId where promotionSeqNo=" + promotionSeqNo;
                SqlCommand command = new SqlCommand(query, connection);
                reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.ToString());
            }
            
            return reader;
        }

        public int insertPromotion(Promotion promotion)
        {
            int counter = 0;
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                string query = "INSERT INTO tbPromotion (promotionType, productSeqId, discountType, discountValue, startDate, endDate, imageUrl, thumbnailImageUrl" +
                    ",promotionTitle, promotionContent, linkUrl, promotionStatus, createDate) "
                    + " VALUES('"+ promotion.promotionType + "', "+ promotion.productSeqId +", '"+ promotion.discountType +"', "+ promotion.discountValue +", '"+ promotion.startDate +"', '"+ promotion.endDate +"', '"+ promotion.imageUrl +"'" +
                    ", '"+ promotion.thumbnailImageUrl +"', '"+ promotion.promotionTitle +"', '"+ promotion.promotionContent +"', '"+ promotion.linkUrl +"', '"+ promotion.promotionStatus +"', GETDATE());";
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

        public int deletePromotion(int promotionSeqNo)
        {
            int counter = 0;

            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                string query = "Delete tbPromotion where promotionSeqNo=" + promotionSeqNo;
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

        public int updatePromotion(Promotion promotion)
        {
            int counter = 0;
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

               // Promotion promotion = new Promotion();

                string query = "Update tbPromotion set productSeqId='" + promotion.productSeqId + "', discountType='" + promotion.discountType + "', discountValue='" + promotion.discountValue + "', startDate='" + promotion.startDate + "'" +
                    ", endDate='" + promotion.endDate + "', imageUrl='" + promotion.imageUrl + "', thumbnailImageUrl='" + promotion.thumbnailImageUrl + "', promotionTitle='" + promotion.promotionTitle + "', promotionContent='" + promotion.promotionContent + "'"+
                    ", linkUrl='" + promotion.linkUrl + "', promotionStatus='" + promotion.promotionStatus + "' " +
                    " where promotionSeqNo=" + promotion.promotionSeqNo;
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