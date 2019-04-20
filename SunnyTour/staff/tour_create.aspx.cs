using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;
using SunnyTour.common;

namespace SunnyTour
{
    public partial class WebForm13 : System.Web.UI.Page
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
                SqlDataReader readerCommonCode = dalTour.getCommonCode("G001");

                if (readerCommonCode.HasRows)
                {
                    while (readerCommonCode.Read())
                    {
                        ListItem newItem = new ListItem();
                        newItem.Text = readerCommonCode["codeName"].ToString();
                        newItem.Value = readerCommonCode["codeNo"].ToString();

                        dropDownList_tourStatus.Items.Add(newItem);
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DAL_Tour dalTour = new DAL_Tour();
                string[] imageFile = CommonMethod.saveImage("/images/site/", fileUpload_image, false);
                /*
                string saveFileName = "";
                if ((null != fileUpload_image.PostedFile) && (0 < fileUpload_image.PostedFile.ContentLength))
                {
                    //1.Upload a file to server

                    //1-2.Upload
                    //Make a directory to upload file
                    string sFileDir = HttpContext.Current.Server.MapPath("/images/site/");
                    DateTime localDate = DateTime.Now;
                    sFileName = sFileDir + string.Format(@"\{0}", DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + fileUpload_image.PostedFile.FileName);
                    saveFileName = "/images/site/" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + fileUpload_image.PostedFile.FileName;

                    //Check a directory is created
                    if (true == Directory.Exists(sFileDir))
                    {//Directory is created
                        if (true == File.Exists(sFileName))
                        {//There is a file which is the same name
                            File.Delete(sFileName);
                        }
                    }
                    else
                    {//There is no directory
                     //Create a directory
                        Directory.CreateDirectory(sFileDir);
                    }

                    try
                    {
                        //Upload a file
                        fileUpload_image.PostedFile.SaveAs(sFileName);
                    }
                    catch (Exception ex)
                    {
                        Response.Write("I received the following error while uploading the file\nError contents : "
                                        + ex.ToString());
                        return;
                    }
                    string imageFile = "";
                    if (sFileName != "")
                    {
                        imageFile = saveFileName;
                    }
                }*/



                int result = dalTour.insertTour(txtTourTitle.Text, txtTourRegion.Text, txtPrice.Text, imageFile[0], dropDownList_tourStatus.SelectedItem.Value, txtDescription.Text);
                if (result > 0)
                {
                    Response.Write("<script>alert('Saved successfully.');window.location = '/staff/tour_management.aspx';</script>");
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

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("/staff/tour_management.aspx");
            }
            catch (System.Exception ex)
            {
                Response.Write("<script>alert('An error occurred during the process. Please try again later.');</script>");
                Console.WriteLine("Exception: {0}", ex.ToString());
            }
            
        }

    }
}