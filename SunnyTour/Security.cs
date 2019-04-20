using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;

namespace SunnyTour
{
    public class Security
    {
        public static string GetHash256(string password, string salt)
        {
            byte[] passwordByte = ASCIIEncoding.ASCII.GetBytes(password + salt + "MP");
            
            HashAlgorithm algorithm = SHA256.Create();
            byte[] hashpassword = algorithm.ComputeHash(passwordByte);
            return Convert.ToBase64String(hashpassword);
        }
    }
}