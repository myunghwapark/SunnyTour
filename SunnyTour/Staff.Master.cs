using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SunnyTour
{
    public partial class Staff : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string pathInfo = Request.Url.LocalPath;
                HttpCookie aCookie = Request.Cookies["UserInfo"];

                if (!pathInfo.Contains("login") && Request.Cookies["UserInfo"] == null)
                {
                    Response.Redirect("/staff/staff_login.aspx");
                }
                else if (Request.Cookies["UserInfo"] != null && aCookie.Values["UserType"] != "G002_002")
                {
                    Response.Redirect("/customers/home.aspx");
                }

                if (Request.Cookies["UserInfo"] == null)
                {
                    btnLogin.Visible = true;
                    labelName.Visible = false;
                    btnLogout.Visible = false;
                }
                else
                {
                    labelName.Text = "Welcome " + aCookie.Values["UserName"];

                    btnLogin.Visible = false;
                    labelName.Visible = true;
                    btnLogout.Visible = true;
                }
            }
            catch (System.Exception ex)
            {
                Response.Write("<script>alert('An error occurred during the process. Please try again later.');</script>");
                Console.WriteLine("Exception: {0}", ex.ToString());
            }
            
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("/staff/staff_login.aspx");
            }
            catch (System.Exception ex)
            {
                Response.Write("<script>alert('An error occurred during the process. Please try again later.');</script>");
                Console.WriteLine("Exception: {0}", ex.ToString());
            }
            
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            try
            {
                HttpCookie aCookie = new HttpCookie("UserInfo");
                aCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(aCookie);

                Response.Redirect("/staff/staff_login.aspx");
            }
            catch (System.Exception ex)
            {
                Response.Write("<script>alert('An error occurred during the process. Please try again later.');</script>");
                Console.WriteLine("Exception: {0}", ex.ToString());
            }
            
        }
    }
}