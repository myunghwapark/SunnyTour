using System;
using System.Data.SqlClient;

namespace SunnyTour
{
    public partial class WebForm17 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                setUserList();
        }

        private void setUserList()
        {
            DAL_User dalUser = new DAL_User();
            SqlDataReader rd;

            string userType = "";
            if (Request.QueryString["userType"] != null)
            {
                userType = Request.QueryString["userType"];
                
            }
            if(Request.QueryString["searchType"] != null && Request.QueryString["searchType"].Equals("topPurchased"))
            {
                rd = dalUser.GetTop10PurchaseUsers(userType);
            }
            else if (Request.QueryString["searchType"] != null && Request.QueryString["searchType"].Equals("topBooked"))
            {
                rd = dalUser.GetTop10BookingUsers(userType);
            }
            else
            {
                rd = dalUser.GetUserList(userType);
            }
               

            GridView_Tour.DataSource = rd;
            GridView_Tour.DataBind();

            if(rd != null)
                rd.Close();
        }

        protected void btnRegisterUser_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("/staff/user_edit.aspx");
            }
            catch (System.Exception ex)
            {
                Response.Write("<script>alert('An error occurred during the process. Please try again later.');</script>");
                Console.WriteLine("Exception: {0}", ex.ToString());
            }
            
        }
    }
}