using System;
using System.Data.SqlClient;

namespace SunnyTour
{
    public partial class WebForm21 : System.Web.UI.Page
    {
   
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                setList();
        }

        private void setList()
        {
            string startDate = "", endDate = "", promotionType = "", txtSearch = "";
            if (Request.QueryString["startDate"] != null && !Request.QueryString["startDate"].Equals(""))
            {
                startDate = Request.QueryString["startDate"];
            }
            if (Request.QueryString["endDate"] != null && !Request.QueryString["endDate"].Equals(""))
            {
                endDate = Request.QueryString["endDate"];
            }
            if (Request.QueryString["promotionType"] != null && !Request.QueryString["promotionType"].Equals(""))
            {
                promotionType = Request.QueryString["promotionType"];
            }
            if (Request.QueryString["txtSearch"] != null && !Request.QueryString["txtSearch"].Equals(""))
            {
                txtSearch = Request.QueryString["txtSearch"];
            }


            DAL_Promotion dalPromotion = new DAL_Promotion();
            SqlDataReader rd = dalPromotion.getPromotionList(txtSearch, startDate, endDate, promotionType);

            GridView_PromotionList.DataSource = rd;
            GridView_PromotionList.DataBind();

            if(rd != null)
                rd.Close();
        }

        protected void btnCreatePromotion_Click(object sender, EventArgs e)
        {
            Response.Redirect("/staff/promotion_edit.aspx");
        }
    }
}