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
    public partial class WebForm19 : System.Web.UI.Page
    {
        string userId = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                
                if (Request.QueryString["userId"] != null)
                {
                    userId = Request.QueryString["userId"];
                    txtUserId.Enabled = false;
                    btnIdCheck.Visible = false;
                    LabelTitle.Text = "Edit";
                    if (!Page.IsPostBack)
                    {
                        getUserInfo();
                    }
                            
                }
                else
                {
                    LabelTitle.Text = "Create";
                    txtUserId.Enabled = true;
                    btnIdCheck.Visible = true;
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
                        txtUserId.Text = reader["userId"].ToString();
                        txtPassword.Text = reader["userPassword"].ToString();
                        txtConfirmPassword.Text = reader["userPassword"].ToString();
                        txtFirstName.Text = reader["firstName"].ToString();
                        txtLastName.Text = reader["lastName"].ToString();
                        txtPhoneNumber.Text = reader["phoneNumber"].ToString();

                        dropDownListUser.ClearSelection();
                        dropDownListUser.SelectedValue = reader["userTypeCode"].ToString();
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
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DAL_User dalUser = new DAL_User();

                // insert
                if (userId == "" && idChecked.Value == "Y")
                {
                    int result = dalUser.InsertUser(txtUserId.Text, txtFirstName.Text, txtLastName.Text, txtPhoneNumber.Text, dropDownListUser.SelectedItem.Value, txtPassword.Text);
                    if (result > 0)
                    {
                        Response.Write("<script>alert('Saved successfully.');window.location = '/staff/user_detail.aspx?userId=" + txtUserId.Text + "';</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('An error occurred during the process. Please try again later.');</script>");
                    }
                }
                else if(userId == "" && idChecked.Value == "N")
                {
                    Response.Write("<script>alert('Please, check your ID.');</script>");
                }
                // update
                else if(userId != "")
                {
                    int result = dalUser.UpdateUser(txtUserId.Text, txtFirstName.Text, txtLastName.Text, txtPhoneNumber.Text, dropDownListUser.SelectedItem.Value, txtPassword.Text);
                    if (result > 0)
                    {
                        Response.Write("<script>alert('Saved successfully.');window.location = '/staff/user_detail.aspx?userId=" + userId + "';</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('An error occurred during the process. Please try again later.');</script>");
                    }
                }
                
            }
            catch (System.Exception ex)
            {
                Response.Write("<script>alert('An error occurred during the process. Please try again later.');</script>");
                Console.WriteLine("Exception: {0}", ex.ToString());
            }
        }

        protected void btnIdCheck_Click(object sender, EventArgs e)
        {
            try
            {
                DAL_User dalUer = new DAL_User();
                int counter = dalUer.GetUserId(txtUserId.Text);
                if(counter > 0)
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