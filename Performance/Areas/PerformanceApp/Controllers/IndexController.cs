using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;

namespace Performance.Areas.PerformanceApp.Controllers
{
    public class IndexController : Controller
    {
        public ActionResult Index(string perfil, string idUsuario, string iv)
        {
            if (perfil != "" && idUsuario != "" && iv != null)
            {
                string perfilDesencriptado = Desencriptar(perfil, iv);
                string idUsuarioDesencriptado = Desencriptar(idUsuario, iv);

                System.Web.HttpContext.Current.Session["perfil"] = perfilDesencriptado;
                System.Web.HttpContext.Current.Session["idUsuario"] = idUsuarioDesencriptado;
            }
            if ((perfil != "" || idUsuario != "") && iv == null)
            {
                return RedirectToAction("Index", new { area = "Login" });
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

        public ActionResult Crud(string view, string idPerformance, string nombre, string iv)
        {
            var idPerformanceLong = idPerformance.LongCount();
            if (idPerformanceLong == 24 && iv != null)
            {
                string perfilDesencriptado = Desencriptar(idPerformance, iv);
                ViewBag.View = view;
                ViewBag.IdPerformance = Convert.ToInt32(perfilDesencriptado);
                ViewBag.nombre = nombre;
            }
            else
            {
                return RedirectToAction("Index", new { area = "Login" });
            }

            return View();
        }
    }
}
