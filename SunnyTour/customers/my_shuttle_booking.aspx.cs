using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace SunnyTour
{
    public partial class WebForm30 : System.Web.UI.Page
    {
        int shuttleBookingSeqNo = 0;
        string bookingStatus = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.Cookies["UserInfo"] == null)
                {
                    Response.Write("<script>alert('Please, login.');window.location='/customers/login.aspx'</script>");
                }
                else if (Request.QueryString["shuttleBookingSeqNo"] == null)
                {
                    Response.Write("<script>alert('Wrong approach. Please, approach in the right way.');window.location='/customers/my_travel.aspx'</script>");
                }
                else
                {
                    shuttleBookingSeqNo = int.Parse(Request.QueryString["shuttleBookingSeqNo"]);

                    if (!IsPostBack)
                        setCommonCode();
                    
                }
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

                setDetail();
            }
            catch (System.Exception ex)
            {
                Response.Write("<script>alert('An error occurred during the process. Please try again later.');</script>");
                Console.WriteLine("Exception: {0}", ex.ToString());
            }

        }
        protected void setDetail()
        {
            try
            {
                DAL_Shuttle dalShuttle = new DAL_Shuttle();
                SqlDataReader reader = dalShuttle.getShuttleDetail(shuttleBookingSeqNo);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        
                        dropDownWhere.ClearSelection();
                        dropDownWhere.SelectedValue = reader["shuttleTypeCode"].ToString();
                        txtPickUpLocation.Text = reader["pickupLocation"].ToString();
                        txtDropOffLocation.Text = reader["dropOffLocation"].ToString();
                        txtShuttleDate.Text = reader["pickupDate"].ToString();
                        txtShuttleTime.Text = reader["pickupTime"].ToString();
                        txtNumberOfPassenger.Text = reader["passengerNumber"].ToString();
                        bookingStatus = reader["bookingStatus"].ToString();
                        labelStatus.Text = bookingStatus;

                        if (bookingStatus.Equals("G001_001"))
                        {
                            dropDownWhere.Enabled = false;
                            txtPickUpLocation.ReadOnly = true;
                            txtDropOffLocation.ReadOnly = true;
                            txtShuttleDate.ReadOnly = true;
                            txtShuttleTime.ReadOnly = true;
                            txtNumberOfPassenger.ReadOnly = true;
                        }
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


        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (bookingStatus.Equals("G001_001"))
                {
                    Response.Write("<script>alert('The status of this service can not be modified because the administrator changed the status. If you would like to change it, please contact the administrator.');</script>");
                }
                else
                {
                    DAL_Shuttle dalShuttle = new DAL_Shuttle();
                    int result = dalShuttle.updateShuttleBooking(shuttleBookingSeqNo, dropDownWhere.SelectedItem.Value, txtPickUpLocation.Text, txtDropOffLocation.Text, txtNumberOfPassenger.Text, txtShuttleDate.Text + " "+ txtShuttleTime.Text);
                    if(result > 0)
                    {
                        Response.Write("<script>alert('Saved successfully.');window.location = '/customers/my_travel.aspx';</script>");
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

        protected void btnList_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("/customers/my_travel.aspx");
            }
            catch (System.Exception ex)
            {
                Response.Write("<script>alert('An error occurred during the process. Please try again later.');</script>");
                Console.WriteLine("Exception: {0}", ex.ToString());
            }
        }


        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                DAL_Shuttle dalShuttle = new DAL_Shuttle();
                int result = dalShuttle.updateShuttleBookingStatus(shuttleBookingSeqNo, "G001_003");

                if (result > 0)
                {
                    Response.Write("<script>alert('Successfully canceled');window.location='/customers/my_travel.aspx';</script>");
                }
                else
                {
                    Response.Write("<script>alert(An error occured during the process. Please, try again later.');</script>");
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