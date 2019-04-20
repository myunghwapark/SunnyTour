using System;
using System.Web;
using System.Data.SqlClient;

namespace SunnyTour
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                DAL_User dbUser = new DAL_User();
                string encryptPassword = Security.GetHash256(txtPassword.Text, txtUserId.Text);
                int result = dbUser.login(txtUserId.Text, encryptPassword);
                if (result > 0)
                {
                    SqlDataReader reader = dbUser.GetUserInfo(txtUserId.Text);
                    string userName = "";
                    string userType = "";
                    while (reader.Read())
                    {
                        userName = reader["lastName"].ToString();
                        userType = reader["userTypeCode"].ToString();
                    }
                    HttpCookie aCookie = new HttpCookie("UserInfo");
                    aCookie.Values["UserName"] = userName;
                    aCookie.Values["UserId"] = txtUserId.Text;
                    aCookie.Values["UserType"] = userType;

                    aCookie.Expires.AddDays(1);
                    Response.Cookies.Add(aCookie);

                    reader.Close();
                    Response.Redirect("/customers/home.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Invalid ID or password. Please, enter correct ID or password.');</script>");
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