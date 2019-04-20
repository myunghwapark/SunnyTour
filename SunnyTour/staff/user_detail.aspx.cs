using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;

namespace SunnyTour
{
    public partial class WebForm18 : System.Web.UI.Page
    {
        string userId = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["userId"] != null)
                {
                    userId = Request.QueryString["userId"];
                    getUserInfo();
                }
                else
                {
                    Response.Write("<script>alert('Wrong approach. Please, approach in the right way.');window.location='/staff/user_management.aspx'</script>");
                }
            }
            catch (System.Exception ex)
            {
                Response.Write("<script>alert('An error occurred during the process. Please try again later.');</script>");
                Console.WriteLine("Exception: {0}", ex.ToString());
            }
        }

        protected void getUserInfo()
        {
            try
            {
                DAL_User dalUser = new DAL_User();
                SqlDataReader reader = dalUser.GetUserInfo(userId);
                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        labelUserId.Text = reader["userId"].ToString();
                        labelFirstName.Text = reader["firstName"].ToString();
                        labelLastName.Text = reader["lastName"].ToString();
                        labelPhoneNumber.Text = reader["phoneNumber"].ToString();
                        labelUserType.Text = reader["userType"].ToString();
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
                Response.Redirect("/staff/user_management.aspx");
            }
            catch (System.Exception ex)
            {
                Response.Write("<script>alert('An error occurred during the process. Please try again later.');</script>");
                Console.WriteLine("Exception: {0}", ex.ToString());
            }
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("/staff/user_edit.aspx?userId="+userId);
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
                DAL_User dalUser = new DAL_User();
                int result = dalUser.DeleteUser(userId);

                if (result > 0)
                {
                    Response.Write("<script>alert('Deleted successfully.');window.location = '/staff/user_management.aspx';</script>");
                }
                else
                {
                    Response.Write("<script>alert('An error occurred during the process. Please try again later.');</script>");
                }
            }
            catch(System.Exception ex)
            {
                Response.Write("<script>alert('An error occurred during the process. Please try again later.');</script>");
                Console.WriteLine("Exception: {0}", ex.ToString());
            }
            

        }
    }
}