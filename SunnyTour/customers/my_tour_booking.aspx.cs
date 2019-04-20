using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SunnyTour
{
    public partial class WebForm15 : System.Web.UI.Page
    {
        int tourBookingSeqNo = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.Cookies["UserInfo"] == null)
                {
                    Response.Write("<script>alert('Please, login.');window.location='/customers/login.aspx'</script>");
                }
                else if (Request.QueryString["tourBookingSeqNo"] == null)
                {
                    Response.Write("<script>alert('Wrong approach. Please, approach in the right way.');window.location='/customers/my_travel.aspx'</script>");
                }
                else
                {
                    tourBookingSeqNo = int.Parse(Request.QueryString["tourBookingSeqNo"]);
                    if (!IsPostBack)
                        setDetail();
                }
            }
            catch (System.Exception ex)
            {
                Response.Write("<script>alert('An error occurred during the process. Please try again later.');</script>");
                Console.WriteLine("Exception: {0}", ex.ToString());
            }
            
        }

        protected void setDetail()
        {
            try
            {
                DAL_TourBooking dalTourBooking = new DAL_TourBooking();
                SqlDataReader reader = dalTourBooking.getTourBookingDetail(tourBookingSeqNo);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        labelTitle.Text = reader["tourTitle"].ToString();
                        txtTravelDate.Text = reader["travelDate"].ToString();
                        txtTravelerNumber.Text = reader["travelerNumber"].ToString();
                        labelLocation.Text = reader["tourRegion"].ToString();
                        labelStatus.Text = reader["bookingStatus"].ToString();
                        labelRegisterDate.Text = reader["createDate"].ToString();
                        imageTour.ImageUrl = reader["imageUrl"].ToString();
                    }
                }

                reader.Close();
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
                Response.Redirect("/customers/my_travel.aspx");
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
                if(!labelStatus.Text.Equals("G001_001"))
                {
                    Response.Write("<script>alert('This is a travel state that can not be changed. Please contact the administrator.');</script>");
                    return;
                }
                DAL_TourBooking dalTourBooking = new DAL_TourBooking();
                int result = dalTourBooking.updateTourBooking(tourBookingSeqNo, txtTravelDate.Text, txtTravelerNumber.Text);

                if (result > 0)
                {
                    Response.Write("<script>alert('Successfully saved');window.location='/customers/my_travel.aspx';</script>");
                }
                else
                {
                    Response.Write("<script>alert('An error occured during the process. Please, try again later.');</script>");
                }
            }
            catch (System.Exception ex)
            {
                Response.Write("<script>alert('An error occurred during the process. Please try again later.');</script>");
                Console.WriteLine("Exception: {0}", ex.ToString());
            }

        }


        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                DAL_TourBooking dalTourBooking = new DAL_TourBooking();
                int result = dalTourBooking.updateTourBookingStatus(tourBookingSeqNo, "G001_003");

                if (result > 0)
                {
                    Response.Write("<script>alert('Successfully canceled');window.location='/customers/my_travel.aspx';</script>");
                }
                else
                {
                    Response.Write("<script>alert('An error occured during the process. Please, try again later.');</script>");
                }
            }
            catch (System.Exception ex)
            {
                Response.Write("<script>alert('An error occurred during the process. Please try again later.');</script>");
                Console.WriteLine("Exception: {0}", ex.ToString());
            }
            
        }
    }
}