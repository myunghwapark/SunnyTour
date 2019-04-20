using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SunnyTour.common;

namespace SunnyTour
{
    public partial class WebForm24 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                DAL_User dalUser = new DAL_User();
                int result = dalUser.GetUserId(txtEmail.Text);
                if (result > 0)
                {
                    string newPassword = CommonMethod.RandomPassword();
                    int resultUpdate = dalUser.UpdateUserPassword(txtEmail.Text, newPassword);

                    if(resultUpdate > 0)
                    {
                        // Send email
                        string subject = "You have got new password for Sunny tour.";
                        string content = "Hello! This is Sunny tour.\n We are sending you new password below.\n New Password: " + newPassword;
                        bool resultEmail = CommonMethod.SendEmail(txtEmail.Text, subject, content);

                        if(resultEmail)
                        {
                            Response.Write("<script>alert('New password was sent to your email.');</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('Sending mail failed. Please try again later.');</script>");
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('An error occurred during the updating password.');</script>");
                    }
                }
                else
                {
                    Response.Write("<script>alert('There is no matching member information with the email address you entered.');</script>");
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