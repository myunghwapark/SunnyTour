using System;
using System.Data.SqlClient;

namespace SunnyTour
{
    public partial class WebForm16 : System.Web.UI.Page
    {
        string promotionYn = "", orderBy = "", searchText = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["promotionYn"] != null)
            {
                promotionYn = Request.QueryString["promotionYn"];
            }
            if (Request.QueryString["orderBy"] != null)
            {
                orderBy = Request.QueryString["orderBy"];
            }
            if (Request.QueryString["searchText"] != null)
            {
                searchText = Request.QueryString["searchText"];
            }

            getTourList();
        }

        private void getTourList()
        {
            try
            {

                DAL_Tour dalTour = new DAL_Tour();
                SqlDataReader rd;

                if (promotionYn.Equals("Y"))
                {
                    rd = dalTour.getPromotionTourList(searchText, orderBy);
                }
                else
                {
                    rd = dalTour.getAllTourList(searchText, orderBy);
                }

                listView_Tour.DataSource = rd;
                listView_Tour.DataBind();

                rd.Close();
            }
            catch (System.Exception ex)
            {
                Response.Write("<script>alert('An error occurred during the process. Please try again later.');</script>");
                Console.WriteLine("Exception: {0}", ex.ToString());
            }
        }
        
    }


}