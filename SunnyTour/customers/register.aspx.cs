using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SunnyTour.common;

namespace SunnyTour
{
    public partial class WebForm20 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                DAL_User dalUser = new DAL_User();

                // Check if checked ID
                if (idChecked.Value == "Y")
                {
                    if(!CommonMethod.IsValidPassword(txtPassword.Text))
                    {
                        Response.Write("<script>alert('Your password must be at least 8 characters long, contain at least one number and have a mixture of uppercase and lowercase letters.');</script>");
                        return;
                    }
                    int result = dalUser.InsertUser(txtUserId.Text, txtFirstName.Text, txtLastName.Text, txtPhoneNumber.Text, "G002_001", txtPassword.Text);
                    if (result > 0)
                    {
                        Response.Write("<script>alert('Registerd successfully.');window.location = '/customers/login.aspx';</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('An error occurred during the process. Please try again later.');</script>");
                    }
                }
                else if (idChecked.Value == "N")
                {
                    Response.Write("<script>alert('Please, check your ID.');</script>");
                }

            }
            catch (System.Exception ex)
            {
                Response.Write("<script>alert('An error occurred during the process. Please try again later.');</script>");
                Console.WriteLine("Exception: {0}", ex.ToString());
            }
        }

        protected void btnCheckId_Click(object sender, EventArgs e)
        {
            try
            {
                DAL_User dalUer = new DAL_User();
                if(String.IsNullOrEmpty(txtUserId.Text))
                {
                    Response.Write("<script>alert('Please, enter user ID.');</script>");
                    return;
                }

                int counter = dalUer.GetUserId(txtUserId.Text);
                if (counter > 0)
                {
                    Response.Write("<script>alert('Please, use different ID.');</script>");
                    txtUserId.Text = "";
                    idChecked.Value = "N";
                }
                else
                {
                    Response.Write("<script>alert('You can use the ID.');</script>");
                    idChecked.Value = "Y";
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