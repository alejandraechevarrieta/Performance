using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Performance.Areas.PerformanceApp.Controllers
{
    public class IndexController : Controller
    {
        private static readonly byte[] Key = Encoding.UTF8.GetBytes("1234567890123456"); 

        public ActionResult Index(string perfil, string idUsuario, string iv)
        {
            if(perfil != "0" && idUsuario != "0")
            {
                string perfilDesencriptado = Desencriptar(perfil, iv);
                string idUsuarioDesencriptado = Desencriptar(idUsuario, iv);

                System.Web.HttpContext.Current.Session["perfil"] = perfilDesencriptado;
                System.Web.HttpContext.Current.Session["idUsuario"] = idUsuarioDesencriptado;
            }           

            return View();
        }

        private string Desencriptar(string cipherText, string ivBase64)
        {
            byte[] buffer = Convert.FromBase64String(cipherText);
            byte[] iv = Convert.FromBase64String(ivBase64);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Key;
                aes.IV = iv;
                aes.Padding = PaddingMode.PKCS7;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream ms = new MemoryStream(buffer))
                {
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader reader = new StreamReader(cs))
                        {
                            return reader.ReadToEnd();
                        }
                    }
                }
            }
        }

    public ActionResult Crud(string view, int idPerformance, string nombre)
        {
            ViewBag.View = view;
            ViewBag.IdPerformance = idPerformance;
            ViewBag.nombre = nombre;

            return View();
        }
    }
}
