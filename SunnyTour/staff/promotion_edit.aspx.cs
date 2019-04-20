using System;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Web.UI.WebControls;
using SunnyTour.model;
using SunnyTour.common;

namespace SunnyTour
{
    public partial class WebForm23 : System.Web.UI.Page
    {
        string promotionSeqNo = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // edit
                if (Request.QueryString["promotionSeqNo"] != null)
                {
                    promotionSeqNo = Request.QueryString["promotionSeqNo"];

                    txtImageUrl.Visible = true;

                    labelTitle.Text = "Edit";
                    if (!IsPostBack)
                        setData();
                }
                // create
                else
                {
                    txtImageUrl.Visible = false;

                    labelTitle.Text = "Create";

                    setProducts();

                    DropDownListDiscountType = CommonMethod.setCommonCode("G005", DropDownListDiscountType);
                    DropDownListStatus = CommonMethod.setCommonCode("G001", DropDownListStatus);
                    DropDownListPromotionType = CommonMethod.setCommonCode("G004", DropDownListPromotionType);
                }
            }
            catch (System.Exception ex)
            {
                Response.Write("<script>alert('An error occurred during the process. Please try again later.');</script>");
                Console.WriteLine("Exception: {0}", ex.ToString());
            }
        }
        

        private void setProducts()
        {
            try
            {
                DAL_Tour dalTour = new DAL_Tour();
                SqlDataReader readerCommonCode = dalTour.getTourDropdownList();

                if (readerCommonCode.HasRows)
                {
                    while (readerCommonCode.Read())
                    {
                        ListItem newItem = new ListItem();
                        newItem.Text = "["+ readerCommonCode["tourSeqNo"].ToString()+"] "+readerCommonCode["tourTitle"].ToString();
                        newItem.Value = readerCommonCode["tourSeqNo"].ToString();

                        DropDownListProduct.Items.Add(newItem);
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


        protected void setData()
        {
            try
            {
                setProducts();

                DropDownListDiscountType = CommonMethod.setCommonCode("G005", DropDownListDiscountType);
                DropDownListStatus = CommonMethod.setCommonCode("G001", DropDownListStatus);
                DropDownListPromotionType = CommonMethod.setCommonCode("G004", DropDownListPromotionType);
                

                DAL_Promotion dalPromotion = new DAL_Promotion();
                if (Request.QueryString["promotionSeqNo"] != null)
                {

                    int promotionNo = int.Parse(promotionSeqNo);
                    SqlDataReader reader = dalPromotion.getPromotionDetail(promotionNo);
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            txtPromotionTitle.Text = reader["promotionTitle"].ToString();
                            txtImageUrl.Text = reader["imageUrl"].ToString();
                            hiddenThumbnailImage.Value = reader["thumbnailImageUrl"].ToString();
                            txtContent.Text = reader["promotionContent"].ToString();
                            txtDiscountValue.Text = reader["discountValue"].ToString();
                            txtStartDate.Text = reader["startDate"].ToString();
                            txtEndDate.Text = reader["endDate"].ToString();
                            txtLinkUrl.Text = reader["linkUrl"].ToString();

                            DropDownListDiscountType.ClearSelection();
                            DropDownListDiscountType.SelectedValue = reader["discouontTypeCode"].ToString();

                            DropDownListStatus.ClearSelection();
                            DropDownListStatus.SelectedValue = reader["promotionStatusCode"].ToString();

                            DropDownListPromotionType.ClearSelection();
                            DropDownListPromotionType.SelectedValue = reader["promotionTypeCode"].ToString();

                            DropDownListProduct.ClearSelection();
                            DropDownListProduct.SelectedValue = reader["productSeqId"].ToString();
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (promotionSeqNo == null && (null == fileUpload_image.PostedFile || 0 == fileUpload_image.PostedFile.ContentLength))
                {
                    Response.Write("<script>alert('Please, select promotion image.');</script>");
                    return;
                }
                DAL_Promotion dalPromotion = new DAL_Promotion();
                Promotion promotion = new Promotion();

                if (Request.QueryString["promotionSeqNo"] != null)
                {
                    promotion.promotionSeqNo = int.Parse(promotionSeqNo);
                }
                promotion.promotionType = DropDownListPromotionType.SelectedItem.Value;
                promotion.productSeqId = DropDownListProduct.SelectedItem.Value;
                promotion.discountType = DropDownListDiscountType.SelectedItem.Value;
                promotion.discountValue = txtDiscountValue.Text;
                promotion.startDate = txtStartDate.Text;
                promotion.endDate = txtEndDate.Text;

                if ((null != fileUpload_image.PostedFile) && (0 < fileUpload_image.PostedFile.ContentLength))
                {
                    string[] imagePath = CommonMethod.saveImage("/images/promotion/", fileUpload_image, true);
                    promotion.imageUrl = imagePath[0];
                    promotion.thumbnailImageUrl = imagePath[1];
                }
                else
                {
                    promotion.imageUrl = txtImageUrl.Text;
                    promotion.thumbnailImageUrl = hiddenThumbnailImage.Value;
                }
                promotion.promotionTitle = txtPromotionTitle.Text;
                promotion.promotionContent = txtContent.Text;
                promotion.linkUrl = txtLinkUrl.Text;
                promotion.promotionStatus = DropDownListStatus.SelectedItem.Value;

                int result;
                if (Request.QueryString["promotionSeqNo"] != null)
                {
                    result = dalPromotion.updatePromotion(promotion);
                }
                else
                {
                    result = dalPromotion.insertPromotion(promotion);
                }

                if(result > 0)
                {
                    Response.Write("<script>alert('Saved successfully.');window.location = '/staff/promotion_list.aspx';</script>");
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
                Response.Redirect("/staff/promotion_list.aspx");
            }
            catch (System.Exception ex)
            {
                Response.Write("<script>alert('An error occurred during the process. Please try again later.');</script>");
                Console.WriteLine("Exception: {0}", ex.ToString());
            }
            
        }
    }
}