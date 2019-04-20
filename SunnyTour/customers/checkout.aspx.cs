using System;
using SunnyTour.common;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using SunnyTour.model;

namespace SunnyTour
{
    public partial class WebForm31 : System.Web.UI.Page
    {
        string userId = "";
        string tourBookingSeqNos = "";
        string convertTourBookingSeq = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["UserInfo"] == null)
            {
                Response.Write("<script>alert('Please use the service after login.');window.location='/customers/login.aspx';</script>");
            }
            else if (Request.QueryString["tourBookingSeqNo"] != null)
            {
                HttpCookie aCookie = Request.Cookies["UserInfo"];
                userId = aCookie.Values["UserId"];
                
                tourBookingSeqNos = Request.QueryString["tourBookingSeqNo"];
                if (!Page.IsPostBack)
                    setData();
            }
            else
            {
                Response.Write("<script>alert('Wrong approach. Please, approach in the right way.');window.location='/customers/my_travel.aspx';</script>");
            }
                
        }

        protected void btnCheckOut_Click(object sender, EventArgs e)
        {
            DAL_Checkout dalCheckout = new DAL_Checkout();

            Checkout checkout = new Checkout();
            checkout.firstName = txtFirstName.Text;
            checkout.lastName = txtLastName.Text;
            checkout.phoneNumber = txtPhone.Text;
            checkout.serviceType = "G004_001";
            checkout.serviceSeqId = tourBookingSeqNos;
            checkout.userId = userId;
            string payType = "";
            if(payTypeBanking.Checked)
            {
                payType = "G008_001";
            }
            else
            {
                payType = "G008_002";
            }
            checkout.paymentType = payType;
            checkout.nameOnCard = txtNameOnCard.Text;
            checkout.creditCardType = dropDownCardType.SelectedItem.Value;
            checkout.creditCardNumber = txtCardNumber.Text;
            checkout.expirationMonth = dropDownMonth.SelectedItem.Value;
            checkout.expirationYear = dropDownYear.SelectedItem.Value;
            checkout.cardVerificationNumber = txtCardVerificationNumber.Text;
            checkout.payAmount = hiddenTotalPrice.Value;
            checkout.paidStatus = "G006_001";       // check out

            int result = dalCheckout.insertCheckout(checkout);
            if(result > 0)
            {
                Response.Write("<script>alert('Successfully checked out.');window.location='/customers/my_travel.aspx'</script>");
            }
            else
            {
                Response.Write("<script>alert('An error occurred during the process. Please try again later.');</script>");
            }
        }

        public void payTypeCheckedChanged(object sender, EventArgs e)
        {
            if(payTypeBanking.Checked)
            {
                internetBanking.Visible = true;
                creditCard.Visible = false;
            }
            else
            {
                internetBanking.Visible = false;
                creditCard.Visible = true;
            }
        }

        public void setData()
        {

            try
            {
                // card type
                dropDownCardType.Items.Clear();
                ListItem cardTypeItem = new ListItem();
                cardTypeItem.Text = "Please select";
                cardTypeItem.Value = "";
                dropDownCardType.Items.Add(cardTypeItem);

                dropDownCardType = CommonMethod.setCommonCode("G007", dropDownCardType);

                // card expiration month
                dropDownMonth.Items.Clear();
                ListItem newMonth = new ListItem();
                newMonth.Text = "Month";
                newMonth.Value = "";
                dropDownMonth.Items.Add(newMonth);

                for (int num = 1; num <= 12; num++)
                {
                    ListItem month = new ListItem();
                    month.Text = num + "";
                    month.Value = num + "";
                    dropDownMonth.Items.Add(month);
                }

                // card expiration year
                dropDownYear.Items.Clear();
                ListItem newYear = new ListItem();
                newYear.Text = "Year";
                newYear.Value = "";
                dropDownYear.Items.Add(newYear);

                for (int num = 2019; num <= 2025; num++)
                {
                    ListItem year = new ListItem();
                    year.Text = num + "";
                    year.Value = num + "";
                    dropDownYear.Items.Add(year);
                }

                if (Request.Cookies["UserInfo"] != null)
                {
                    HttpCookie aCookie = Request.Cookies["UserInfo"];

                    DAL_User dalUser = new DAL_User();
                    SqlDataReader reader = dalUser.GetUserInfo(aCookie.Values["UserId"]);
                    userId = aCookie.Values["UserId"];

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            txtFirstName.Text = reader["firstName"].ToString();
                            txtLastName.Text = reader["lastName"].ToString();
                            txtPhone.Text = reader["phoneNumber"].ToString();
                        }
                    }

                    reader.Close();
                }

                setReview();

            }
            catch (System.Exception ex)
            {
                Response.Write("<script>alert('An error occurred during the process. Please try again later.');</script>");
                Console.WriteLine("Exception: {0}", ex.ToString());
            }
        }

        protected void setReview()
        {
            string[] tourBookingSeqList = tourBookingSeqNos.Split('_');
            for(int num=0; num< tourBookingSeqList.Length; num++)
            {
                if (!convertTourBookingSeq.Equals(""))
                {
                    convertTourBookingSeq += ", ";
                }
                convertTourBookingSeq += tourBookingSeqList[num];
            }

            DAL_TourBooking dalTourBooking = new DAL_TourBooking();
            SqlDataReader reader = dalTourBooking.getTourBookingList(convertTourBookingSeq);

            reviewGrid.DataSource = reader;
            reviewGrid.DataBind();

            reader.Close();

            SqlDataReader priceReader = dalTourBooking.getTotalPrice(convertTourBookingSeq);
            if (priceReader.HasRows)
            {
                while (priceReader.Read())
                {
                    double totalPrice = Double.Parse(priceReader["totalPrice"].ToString());
                    labelTotalPrice.Text = String.Format("{0:c2}", totalPrice);
                    hiddenTotalPrice.Value = totalPrice+"";
                }
            }

            reader.Close();
        }
    }
}