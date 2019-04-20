using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace SunnyTour
{
    public partial class WebForm22 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Request.QueryString["promotionSeqNo"] != null)
                {
                    setDetail();
                }
                else
                {
                    Response.Write("<script>alert('Wrong approach. Please, approach in the right way.');window.location='/staff/promotion_list.aspx'</script>");
                }
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
                DAL_Promotion dalPromotion = new DAL_Promotion();
                if (Request.QueryString["promotionSeqNo"] != null)
                {

                    int promotionSeqNo = int.Parse(Request.QueryString["promotionSeqNo"]);
                    SqlDataReader reader = dalPromotion.getPromotionDetail(promotionSeqNo);
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            labelPromotionSeqNo.Text = reader["promotionSeqNo"].ToString();
                            labelPromotionTitle.Text = reader["promotionTitle"].ToString();
                            labelContent.Text = reader["promotionContent"].ToString();
                            labelDiscountType.Text = reader["discountType"].ToString();
                            labelDiscountAmount.Text = reader["discountValue"].ToString();
                            labelStartDate.Text = reader["startDate"].ToString();
                            labelEndDate.Text = reader["endDate"].ToString();
                            labelLinkUrl.Text = reader["linkUrl"].ToString();
                            labelStatus.Text = reader["promotionStatus"].ToString();
                            labelProductId.Text = reader["productSeqId"].ToString();
                            labelProcuctTitle.Text = reader["promotionTitle"].ToString();
                            labelPromotionType.Text = reader["promotionType"].ToString();
                            labelCreateDate.Text = reader["createDate"].ToString();
                            imagePromotion.ImageUrl = reader["imageUrl"].ToString();
                        }


                        reader.Close();
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
            Response.Redirect("/staff/promotion_list.aspx");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DAL_Promotion dalPromotion = new DAL_Promotion();
                int result = dalPromotion.deletePromotion(int.Parse(labelPromotionSeqNo.Text));
                if (result > 0)
                {
                    Response.Write("<script>alert('Deleted successfully.');window.location = '/staff/promotion_list.aspx';</script>");
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

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("/staff/promotion_edit.aspx?promotionSeqNo="+labelPromotionSeqNo.Text);
        }
    }
}