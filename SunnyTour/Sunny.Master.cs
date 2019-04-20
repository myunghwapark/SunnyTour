using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SunnyTour
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.Cookies["UserInfo"] == null)
                {
                    btnLogin.Visible = true;
                    labelName.Visible = false;
                    btnLogout.Visible = false;
                }
                else
                {
                    HttpCookie aCookie = Request.Cookies["UserInfo"];
                    labelName.Text = "Welcome " + aCookie.Values["UserName"];

                    btnLogin.Visible = false;
                    labelName.Visible = true;
                    btnLogout.Visible = true;

                    if (aCookie.Values["UserType"] == "G002_002")
                    {
                        btnAdmin.Visible = true;
                    }
                    else
                    {
                        btnAdmin.Visible = false;
                    }
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
                Response.Redirect("/customers/login.aspx");
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

                labelName.Visible = false;
                btnLogout.Visible = false;
                btnLogin.Visible = true;
                Response.Redirect("/customers/home.aspx");
            }
            catch (System.Exception ex)
            {
                Response.Write("<script>alert('An error occurred during the process. Please try again later.');</script>");
                Console.WriteLine("Exception: {0}", ex.ToString());
            }
            
        }


        protected void btnAdmin_Click(object sender, EventArgs e)
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