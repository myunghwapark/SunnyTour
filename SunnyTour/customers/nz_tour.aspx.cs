using System;
using System.Data.SqlClient;
using System.Web;

namespace SunnyTour
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        int tourSeqNo = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["tourSeqNo"] != null)
                    setDetail();
                else
                    Response.Write("<script>alert('Wrong approach. Please, approach in the right way.');window.location='/customers/nz_tour_list.aspx';</script>");
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
                DAL_Tour dalTour = new DAL_Tour();
                if (Request.QueryString["tourSeqNo"] != null)
                {
                    tourSeqNo = int.Parse(Request.QueryString["tourSeqNo"]);
                }
                SqlDataReader rd = dalTour.getTourDetail(tourSeqNo);


                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        labelTitle.Text = rd["tourTitle"].ToString();
                        labelTourRegion.Text = rd["tourRegion"].ToString();
                        imgTour.ImageUrl = rd["imageUrl"].ToString();
                        double price = Double.Parse(rd["price"].ToString());

                        // has promotion
                        if (! DBNull.Value.Equals(rd["discountType"]))
                        {
                            double discountValue = Double.Parse(rd["discountValue"].ToString());
                            panelPromotion.Visible = true;
                            panelOriginalPrice.Visible = true;
                            labelPromotionPeriod.Text = rd["promotionStartDate"].ToString() + " - " + rd["promotionEndDate"].ToString();
                            labelOriginalPrice.Text = "Original Price: $" + price;

                            // Amount
                            if (rd["discountType"].ToString() == "G005_001")
                            {
                                price -= discountValue;
                            }
                            // Percentage
                            else if(rd["discountType"].ToString() == "G005_002")
                            {
                                price = price - (price * discountValue / 100);
                            }
                        }
                        else
                        {
                            panelPromotion.Visible = false;
                            panelOriginalPrice.Visible = false;
                        }
                        labelPrice.Text = price+"";
                        labelDescription.Text = rd["description"].ToString();
                    }
                }
                else
                {
                    Response.Write("<script>alert('Wrong approach. Please, approach in the right way.');window.location='/customers/nz_tour_list.aspx';</script>");
                }

                rd.Close();
            }
            catch (System.Exception ex)
            {
                Response.Write("<script>alert('An error occurred during the process. Please try again later.');</script>");
                Console.WriteLine("Exception: {0}", ex.ToString());
            }
            

        }

        protected void FormViewTour_ItemCommand(object sender, EventArgs e)
        {
            try
            {
                if (Request.Cookies["UserInfo"] == null)
                {
                    Response.Write("<script>alert('Please, login');window.location = 'Login.aspx';</script>");
                }
                else if (int.Parse(txtTravelerNumber.Text) < 1)
                {
                    labelNotice.Text = "Minimum number of traveler is 1.";
                    labelNotice.Visible = true;
                }
                else if (int.Parse(txtTravelerNumber.Text) > 4)
                {
                    labelNotice.Text = "Maximum number of traveler is 4.";
                    labelNotice.Visible = true;
                }
                else
                {
                    string UserId = "";
                    if (Request.Cookies["UserInfo"] != null)
                    {
                        HttpCookie aCookie = Request.Cookies["UserInfo"];
                        UserId = aCookie.Values["UserId"];

                        DAL_TourBooking dbTourBooking = new DAL_TourBooking();
                        int counter = dbTourBooking.insertTourBooking(tourSeqNo, UserId, txtTravelerNumber.Text, txtTravelDate.Text);

                        if (counter > 0)
                        {
                            Response.Write("<script>alert('Successfully booked.');window.location = 'my_travel.aspx';</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('An error occurred during the process. Please try again later.');</script>");
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