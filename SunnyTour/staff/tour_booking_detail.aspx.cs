using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Globalization;

namespace SunnyTour
{
    public partial class WebForm11 : System.Web.UI.Page
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
                if (Request.QueryString["tourBookingSeqNo"] != null)
                {
                    int tourBookingSeqNo = int.Parse(Request.QueryString["tourBookingSeqNo"]);


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

                            dropDownList_status.Items.Add(newItem);
                        }
                    }

                    readerCommonCode.Close();


                    SqlDataReader rd = dalTourBooking.getTourBookingDetail(tourBookingSeqNo);
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            labelTourBookingSeqNo.Text = rd["tourBookingSeqNo"].ToString();
                            labelUserId.Text = rd["userId"].ToString();
                            labelName.Text = rd["firstName"].ToString() + " " + rd["lastName"].ToString();
                            labelPhone.Text = rd["phoneNumber"].ToString();
                            labelRegisterDate.Text = rd["createDate"].ToString();
                            double price = Double.Parse(rd["price"].ToString());
                            int travelerNumber = int.Parse(rd["travelerNumber"].ToString());
                            price = price * travelerNumber;

                            labelPrice.Text = price + "";
                           
                            labelTravelDate.Text = rd["travelDate"].ToString();
                            labelTourRegion.Text = rd["tourRegion"].ToString();
                            labelTravelerNumber.Text = rd["travelerNumber"].ToString();

                            dropDownList_status.ClearSelection();
                            dropDownList_status.SelectedValue = rd["bookingStatusCode"].ToString();
                            
                        }


                        rd.Close();
                    }

                }
                else
                {
                    Response.Write("<script>alert('No reservation number. Please approach it in the right way.');window.location = '/staff/tour_booking.aspx';</script>");
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
                DAL_TourBooking dalTourBooking = new DAL_TourBooking();
                int result = dalTourBooking.updateTourBookingStatus(int.Parse(labelTourBookingSeqNo.Text), dropDownList_status.SelectedItem.Value);
                if (result > 0)
                {
                    Response.Write("<script>alert('Saved successfully.');window.location = '/staff/tour_booking.aspx';</script>");
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
                DAL_TourBooking dalTourBooking = new DAL_TourBooking();
                int result = dalTourBooking.deleteTourBooking(int.Parse(labelTourBookingSeqNo.Text));
                if (result > 0)
                {
                    Response.Write("<script>alert('Deleted successfully.');window.location = '/staff/tour_booking.aspx';</script>");
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
                Response.Redirect("/staff/tour_booking.aspx");
            }
            catch (System.Exception ex)
            {
                Response.Write("<script>alert('An error occurred during the process. Please try again later.');</script>");
                Console.WriteLine("Exception: {0}", ex.ToString());
            }
            
        }
    }
}