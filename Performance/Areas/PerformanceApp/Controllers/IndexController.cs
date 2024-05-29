using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;

namespace Performance.Areas.PerformanceApp.Controllers
{
    public class IndexController : Controller
    {
        public ActionResult Index(string perfil, string idUsuario, string iv)
        {
            if (perfil != "0" && idUsuario != "0")
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

            // Generar la clave combinando la fecha actual con los dígitos restantes "12345678"
            string currentDate = DateTime.Now.ToString("yyyyMMdd");
            string keyString = currentDate + "12345678";
            byte[] key = Encoding.UTF8.GetBytes(keyString);

            using (Aes aes = Aes.Create())
            {
                aes.Key = key;
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
