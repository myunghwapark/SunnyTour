using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Globalization;

namespace SunnyTour
{
    public partial class WebForm14 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                    setDetail();
            }
            catch (System.Exception ex)
            {
                Response.Write("<script>alert('An error occurred during the process. Please try again later.');</script>");
                Console.WriteLine("Exception: {0}", ex.ToString());
            }
            
        }

        private void setDetail()
        {
            try
            {
                DAL_Shuttle dalShuttle = new DAL_Shuttle();
                if (Request.QueryString["shuttleBookingSeqNo"] != null)
                {
                    int shuttleBookingSeqNo = int.Parse(Request.QueryString["shuttleBookingSeqNo"]);


                    //Set Status dropdown
                    DAL_Tour dalTour = new DAL_Tour();
                    SqlDataReader readerCommonCode = dalTour.getCommonCode("G001");

                    if (readerCommonCode.HasRows)
                    {
                        while (readerCommonCode.Read())
                        {
                            ListItem newItem = new ListItem();
                            newItem.Text = readerCommonCode["codeName"].ToString();
                            newItem.Value = readerCommonCode["codeNo"].ToString();

                            dropDownList_status.Items.Add(newItem);
                        }
                    }

                    readerCommonCode.Close();


                    SqlDataReader rd = dalShuttle.getShuttleDetail(shuttleBookingSeqNo);
                    if (rd.HasRows)
                    {
                        while (rd.Read())
                        {
                            labelShuttleBookingSeqNo.Text = rd["shuttleBookingSeqNo"].ToString();
                            labelUserId.Text = rd["userId"].ToString();
                            labelName.Text = rd["firstName"].ToString() + " " + rd["lastName"].ToString();
                            labelRegisterDate.Text = rd["createDate"].ToString();
                            labelPhone.Text = rd["phoneNumber"].ToString();

                            labelShuttleType.Text = rd["shuttleType"].ToString();
                            labelPickupLocation.Text = rd["pickupLocation"].ToString();
                            labelDropOffLocation.Text = rd["dropOffLocation"].ToString();
                            labelPickupTime.Text = rd["pickupTime"].ToString();
                            labelPassengerNumber.Text = rd["passengerNumber"].ToString();

                            dropDownList_status.ClearSelection();
                            dropDownList_status.SelectedValue = rd["bookingStatusCode"].ToString();

                        }


                        rd.Close();
                    }

                }
                else
                {
                    Response.Write("<script>alert('No reservation number. Please approach it in the right way.');window.location = '/staff/shuttle_booking.aspx';</script>");
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
                DAL_Shuttle dalShuttle = new DAL_Shuttle();
                int result = dalShuttle.updateShuttleBookingStatus(int.Parse(labelShuttleBookingSeqNo.Text), dropDownList_status.SelectedItem.Value);
                if (result > 0)
                {
                    Response.Write("<script>alert('Saved successfully.');window.location = '/staff/shuttle_booking.aspx';</script>");
                }
                else
                {
                    Response.Write("<script>alert('An error occurred during the process. Please try again later.');</script>");
                }
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
                DAL_Shuttle dalShuttle = new DAL_Shuttle();
                int result = dalShuttle.deleteShuttleBooking(int.Parse(labelShuttleBookingSeqNo.Text));
                if (result > 0)
                {
                    Response.Write("<script>alert('Deleted successfully.');window.location = '/staff/shuttle_booking.aspx';</script>");
                }
                else
                {
                    Response.Write("<script>alert('An error occurred during the process. Please try again later.');</script>");
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
                Response.Redirect("/staff/shuttle_booking.aspx");
            }
            catch (System.Exception ex)
            {
                Response.Write("<script>alert('An error occurred during the process. Please try again later.');</script>");
                Console.WriteLine("Exception: {0}", ex.ToString());
            }
            
        }
    }
}