using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing;
using System.Net.Mail;
using System.Data.SqlClient;

namespace SunnyTour.common
{
    public class CommonMethod
    {
        public static bool IsValidPassword(string input)
        {
            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMinimum8Chars = new Regex(@".{8,}");

            var isValidated = hasNumber.IsMatch(input) && hasUpperChar.IsMatch(input) && hasMinimum8Chars.IsMatch(input);
            return isValidated;
        }

        public static string[] saveImage(string url, FileUpload uploadFile, bool thumbnail)
        {
            string[] imageFile = new string[2];
            try
            {
                string sFileName = "";
                string saveFileName = "";
                string thubnailName = "";
                string saveThubnailName = "";

                if ((null != uploadFile.PostedFile) && (0 < uploadFile.PostedFile.ContentLength))
                {
                    //1.Upload a file to server

                    //1-2.Upload
                    //Make a directory to upload file
                    string sFileDir = HttpContext.Current.Server.MapPath(url);
                    DateTime localDate = DateTime.Now;
                    string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + "_" + uploadFile.PostedFile.FileName;
                    sFileName = sFileDir + string.Format(@"\{0}", fileName);
                    saveFileName = url + fileName;

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


                    //Upload a file
                    uploadFile.PostedFile.SaveAs(sFileName);


                    if (thumbnail)
                    {
                        // Load image.
                        System.Drawing.Image image = System.Drawing.Image.FromFile(sFileName);

                        // Compute thumbnail size.
                        Size thumbnailSize = GetThumbnailSize(image);

                        // Get thumbnail.
                        System.Drawing.Image thumbnailImage = image.GetThumbnailImage(thumbnailSize.Width,
                            thumbnailSize.Height, null, IntPtr.Zero);

                        // Save thumbnail.
                        thubnailName = sFileDir +"tooltips/"+ string.Format(@"\{0}", fileName);
                        saveThubnailName = url + "tooltips/" + fileName;
                        thumbnailImage.Save(thubnailName);
                    }
                
                }

                if (sFileName != "")
                {
                    imageFile[0] = saveFileName;
                    imageFile[1] = saveThubnailName;
                }
            }
            catch (Exception ex)
            {
                
                return imageFile;
            }

            return imageFile;
        }


        static Size GetThumbnailSize(System.Drawing.Image original)
        {
            // Maximum size of any dimension.
            const int maxWidthPixels = 85;
            const int maxHeightPixels = 48;

            // Width and height.
            int originalWidth = original.Width;
            int originalHeight = original.Height;

            // Compute best factor to scale entire image based on larger dimension.
            double factor;
            if (originalWidth > originalHeight)
            {
                factor = (double)maxWidthPixels / originalWidth;
            }
            else
            {
                factor = (double)maxHeightPixels / originalHeight;
            }

            // Return thumbnail size.
            return new Size((int)(originalWidth * factor), (int)(originalHeight * factor));
        }

        static public bool SendEmail(string email, string subject, string content)
        {
            MailMessage message = new System.Net.Mail.MailMessage();

            message.From = new MailAddress("mocaming@gmail.com");
            message.To.Add(new MailAddress(email));
            message.Subject = subject;
            message.Body = content;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new System.Net.NetworkCredential("mocaming@gmail.com", "aldtkfkd83");

            try
            {
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        static public string RandomPassword()
        {
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            char[] charArray = chars.ToCharArray();

            int numPasswd = 10;

            string newPasswd = string.Empty;

            int seed = Environment.TickCount;

            Random rd = new Random(seed);
            int tempNum = 0;



            for (int j = 0; j < numPasswd; j++)
            {
                tempNum = rd.Next(0, charArray.Length - 1);
                newPasswd += charArray[tempNum];
            }

            return newPasswd;

        }


        static public DropDownList setCommonCode(string code, DropDownList list)
        {
            try
            {
                //Set Status dropdown
                DAL_Tour dalTour = new DAL_Tour();
                SqlDataReader readerCommonCode = dalTour.getCommonCode(code);

                if (readerCommonCode.HasRows)
                {
                    while (readerCommonCode.Read())
                    {
                        ListItem newItem = new ListItem();
                        newItem.Text = readerCommonCode["codeName"].ToString();
                        newItem.Value = readerCommonCode["codeNo"].ToString();

                        list.Items.Add(newItem);
                    }
                }
                readerCommonCode.Close();

            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.ToString());
                return null;
            }
            return list;



        }

    }
}