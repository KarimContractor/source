using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace EncriptionDecription.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public string Encript(string value, string key)
        {
            byte[] inputarray = UTF32Encoding.UTF32.GetBytes(value);
            TripleDESCryptoServiceProvider t = new TripleDESCryptoServiceProvider();
            t.Key = UTF32Encoding.UTF32.GetBytes(key);
            t.Mode = CipherMode.ECB;
            t.Padding = PaddingMode.PKCS7;
            ICryptoTransform ict = t.CreateEncryptor();
            byte[] result = ict.TransformFinalBlock(inputarray, 0, inputarray.Length);
            t.Clear();
            return Convert.ToBase64String(result,0,result.Length);
        }
        public string Decript(string value, string key)
        {
            byte[] inputarray = Convert.FromBase64String(value);
            TripleDESCryptoServiceProvider t = new TripleDESCryptoServiceProvider();
            t.Key = UTF32Encoding.UTF32.GetBytes(key);
            t.Mode = CipherMode.ECB;
            t.Padding = PaddingMode.PKCS7;
            ICryptoTransform ict = t.CreateDecryptor();
            byte[] result = ict.TransformFinalBlock(inputarray, 0, inputarray.Length);
            t.Clear();
            return UTF32Encoding.UTF32.GetString(result); 
        }

    }
}