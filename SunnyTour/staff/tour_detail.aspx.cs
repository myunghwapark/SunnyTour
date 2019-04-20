using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;
using SunnyTour.common;

namespace SunnyTour
{
    public partial class WebForm12 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                    setDetail();
            }
            catch (System.Exception ex)
            {
                Response.Write("<script>alert('An error occurred during the process. Please try again later.');</script>");
                Console.WriteLine("Exception: {0}", ex.ToString());
            }
            
        }

        private void setDetail()
        {
            try
            {
                DAL_TourBooking dalTourBooking = new DAL_TourBooking();
                if (Request.QueryString["tourSeqNo"] != null)
                {
                    int tourSeqNo = int.Parse(Request.QueryString["tourSeqNo"]);


                    //Set Status dropdown
                    DAL_Tour dalTour = new DAL_Tour();
                    SqlDataReader readerCommonCode = dalTour.getCommonCode("G001");

                    if (readerCommonCode.HasRows)
                    {
                        while (readerCommonCode.Read())
                        {
                            ListItem newItem = new ListItem();
                            newItem.Text = readerCommonCode["codeName"].ToString();
                            newItem.Value = readerCommonCode["codeNo"].ToString();

                            dropDownList_tourStatus.Items.Add(newItem);
                        }
                    }

                    readerCommonCode.Close();


                    SqlDataReader reader = dalTour.getTourDetail(tourSeqNo);
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            labelTourSeqNo.Text = reader["tourSeqNo"].ToString();
                            txtTourTitle.Text = reader["tourTitle"].ToString();
                            txtPrice.Text = reader["price"].ToString();
                            txtTourRegion.Text = reader["tourRegion"].ToString();
                            txtImageUrl.Text = reader["imageUrl"].ToString();
                            txtDescription.Text = reader["description"].ToString();

                            dropDownList_tourStatus.SelectedValue = reader["tourStatus"].ToString();
                        }


                        reader.Close();
                    }

                }
                else
                {
                    Response.Write("<script>alert('The wrong approach. Please approach it in the right way.');window.location = '/staff/tour_management.aspx';</script>");
                }
            }
            catch (System.Exception ex)
            {
                Response.Write("<script>alert('An error occurred during the process. Please try again later.');</script>");
                Console.WriteLine("Exception: {0}", ex.ToString());
            }
            

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DAL_Tour dalTour = new DAL_Tour();

                string[] imagePath = new string [2];
                if ((null != fileUpload_image.PostedFile) && (0 < fileUpload_image.PostedFile.ContentLength))
                {

                    imagePath = CommonMethod.saveImage("/images/site/", fileUpload_image, true);
                }
                
                int result = dalTour.updateTour(int.Parse(labelTourSeqNo.Text), txtTourTitle.Text, txtPrice.Text, txtTourRegion.Text, imagePath[0], dropDownList_tourStatus.SelectedItem.Value);
                if (result > 0)
                {
                    Response.Write("<script>alert('Saved successfully.');window.location = '/staff/tour_management.aspx';</script>");
                }
                else
                {
                    Response.Write("<script>alert('An error occurred during the process. Please try again later.');</script>");
                }
            }
            catch (System.Exception ex)
            {
                Response.Write("<script>alert('An error occurred during the process. Please try again later.');</script>");
                Console.WriteLine("Exception: {0}", ex.ToString());
            }
            

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DAL_Tour dalTour = new DAL_Tour();
                int result = dalTour.deleteTour(int.Parse(labelTourSeqNo.Text));
                if (result > 0)
                {
                    Response.Write("<script>alert('Deleted successfully.');window.location = '/staff/tour_management.aspx';</script>");
                }
                else
                {
                    Response.Write("<script>alert('An error occurred during the process. Please try again later.');</script>");
                }
            }
            catch (System.Exception ex)
            {
                Response.Write("<script>alert('An error occurred during the process. Please try again later.');</script>");
                Console.WriteLine("Exception: {0}", ex.ToString());
            }
            
        }

        protected void btnList_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("/staff/tour_management.aspx");
            }
            catch (System.Exception ex)
            {
                Response.Write("<script>alert('An error occurred during the process. Please try again later.');</script>");
                Console.WriteLine("Exception: {0}", ex.ToString());
            }
            
        }
    }
}