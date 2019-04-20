using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SunnyTour
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.Cookies["UserInfo"] == null)
                {
                    Response.Write("<script>alert('Please, login.');window.location='/customers/login.aspx'</script>");
                }
                else
                {
                    setList();
                }
            }
            catch (System.Exception ex)
            {
                Response.Write("<script>alert('An error occurred during the process. Please try again later.');</script>");
                Console.WriteLine("Exception: {0}", ex.ToString());
            }
            
        }


        private void setList()
        {
            try
            {
                DAL_TourBooking dalTourBooking = new DAL_TourBooking();

                HttpCookie aCookie = Request.Cookies["UserInfo"];
                string userId = aCookie.Values["UserId"];
                SqlDataReader readerTour = dalTourBooking.getMyTourBooking(userId);

                ListView_MyTravel.DataSource = readerTour;
                ListView_MyTravel.DataBind();

                readerTour.Close();


                DAL_Shuttle dalShuttle = new DAL_Shuttle();

                SqlDataReader readerShuttle = dalShuttle.getMyShuttleBooking(userId);

                ListView_MyShuttle.DataSource = readerShuttle;
                ListView_MyShuttle.DataBind();

                readerShuttle.Close();
            }
            catch (System.Exception ex)
            {
                Response.Write("<script>alert('An error occurred during the process. Please try again later.');</script>");
                Console.WriteLine("Exception: {0}", ex.ToString());
            }
            
        }
        
    }
}