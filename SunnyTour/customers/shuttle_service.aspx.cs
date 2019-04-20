using System;
using System.Web;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace SunnyTour
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                    setCommonCode();
            }
            catch (System.Exception ex)
            {
                Response.Write("<script>alert('An error occurred during the process. Please try again later.');</script>");
                Console.WriteLine("Exception: {0}", ex.ToString());
            }
            
        }
        private void setCommonCode()
        {
            try
            {
                //Set Status dropdown
                DAL_Tour dalTour = new DAL_Tour();
                SqlDataReader readerCommonCode = dalTour.getCommonCode("G003");

                if (readerCommonCode.HasRows)
                {
                    while (readerCommonCode.Read())
                    {
                        ListItem newItem = new ListItem();
                        newItem.Text = readerCommonCode["codeName"].ToString();
                        newItem.Value = readerCommonCode["codeNo"].ToString();

                        dropDownWhere.Items.Add(newItem);
                    }
                }

                readerCommonCode.Close();
            }
            catch (System.Exception ex)
            {
                Response.Write("<script>alert('An error occurred during the process. Please try again later.');</script>");
                Console.WriteLine("Exception: {0}", ex.ToString());
            }

        }

        protected void dropdownChaged(object sender, EventArgs e)
        {
            try
            {
                string AucklandDomesticAirport = "Auckland Domestic Airport";
                string AucklandInternationalAirport = "Auckland International Airport";

                if (dropDownWhere.SelectedItem.Value == "G003_001")
                {
                    txtPickUpLocation.Text = "";
                    txtDropOffLocation.Text = "";
                    txtPickUpLocation.ReadOnly = false;
                    txtDropOffLocation.ReadOnly = false;
                }
                else if (dropDownWhere.SelectedItem.Value == "G003_002")
                {
                    txtPickUpLocation.Text = "";
                    txtDropOffLocation.Text = AucklandDomesticAirport;
                    txtPickUpLocation.ReadOnly = false;
                    txtDropOffLocation.ReadOnly = true;
                }
                else if (dropDownWhere.SelectedItem.Value == "G003_003")
                {
                    txtPickUpLocation.Text = AucklandDomesticAirport;
                    txtDropOffLocation.Text = "";
                    txtPickUpLocation.ReadOnly = true;
                    txtDropOffLocation.ReadOnly = false;
                }
                else if (dropDownWhere.SelectedItem.Value == "G003_004")
                {
                    txtPickUpLocation.Text = "";
                    txtDropOffLocation.Text = AucklandInternationalAirport;
                    txtPickUpLocation.ReadOnly = false;
                    txtDropOffLocation.ReadOnly = true;
                }
                else if (dropDownWhere.SelectedItem.Value == "G003_005")
                {
                    txtPickUpLocation.Text = AucklandInternationalAirport;
                    txtDropOffLocation.Text = "";
                    txtPickUpLocation.ReadOnly = true;
                    txtDropOffLocation.ReadOnly = false;
                }
            }
            catch (System.Exception ex)
            {
                Response.Write("<script>alert('An error occurred during the process. Please try again later.');</script>");
                Console.WriteLine("Exception: {0}", ex.ToString());
            }
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.Cookies["UserInfo"] == null)
                {
                    Response.Write("<script>alert('Please login.');window.location = '/customers/login.aspx';</script>");
                }
                else
                {
                    int people = int.Parse(txtNumberOfPassenger.Text);
                    if(people < 1)
                    {
                        labelNotice.Text = "Minimum number of traveler is 1.";
                        labelNotice.Visible = true;
                    }
                    else if (people > 4)
                    {
                        labelNotice.Text = "Maximum number of traveler is 4.";
                        labelNotice.Visible = true;
                    }
                    else
                    {
                        HttpCookie aCookie = Request.Cookies["UserInfo"];
                        string userId = aCookie.Values["UserId"];
                        DAL_Shuttle dbShuttle = new DAL_Shuttle();
                        string datetime = txtShuttleDateTime.Text.Replace("T", " ");
                        int result = dbShuttle.addShuttleBooking(userId, dropDownWhere.SelectedItem.Value, txtPickUpLocation.Text, txtDropOffLocation.Text, people, datetime);
                        if (result > 0)
                        {
                            Response.Write("<script>alert('Successfully booked.');window.location = '/customers/my_travel.aspx';</script>");
                        }
                        else
                        {
                            labelNotice.Text = "An error occured during the process. Please, try again later.";
                            labelNotice.Visible = true;
                        }
                    }
                    
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