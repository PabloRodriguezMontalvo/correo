using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Correo.Controllers
{
    public class CorreosController : Controller
    {
        // GET: Correos
        public ActionResult Index()
        {
            return View(new Models.Correo());
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Index(Models.Correo correo)
        {
            var copia = ConfigurationManager.
                AppSettings["EnviarCopia"].ToString();
            var smtp = new SmtpClient();
            
            var msg = new MailMessage();
            msg.Subject = correo.Asunto;
            msg.To.Add(new MailAddress(correo.Destino));
            
            if(copia=="Si")
                msg.Bcc.Add(new MailAddress("ftajamar2@tajamar365.com"));
            
            msg.Body = correo.Mensaje;
            msg.IsBodyHtml = true;
            try
            {
                smtp.Send(msg);
            }
            catch (Exception ee)
            {
                var e = "";
            }
            return View();
        }
    }
}