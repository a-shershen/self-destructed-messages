using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BLL.ExtFunc
{
    //HASH Class
    public static class Hash
    {
        //Returns hashed link
        public static String GetLinkHash(string link)
        
        {
            //Byte array represent original link
            byte[] arr = Encoding.Unicode.GetBytes(link);

            //MD5 Hash
            MD5 md5 = new MD5CryptoServiceProvider();

            byte[] hash = md5.ComputeHash(arr);

            StringBuilder sBuilder = new StringBuilder();

            foreach (byte b in hash)
            {
                sBuilder.Append(b.ToString("x2"));
            }

            return sBuilder.ToString();                
        }        
    }
}
