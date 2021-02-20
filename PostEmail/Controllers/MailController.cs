using Microsoft.AspNetCore.Mvc;
using PostEmail.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostEmail.Controllers
{
    public class MailController : Controller
    {
        MailService MailService;
        public MailController(MailService MailService)
        {
            this.MailService = MailService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(String proveedorEmail, String direccionEnvio, String asunto, String mensaje) 
        {
            if (proveedorEmail.ToLower() == "gmail")
            {
                this.MailService.SendEmailGmail(direccionEnvio, asunto, mensaje);
            } else
            {
                this.MailService.SendEmailOutlook(direccionEnvio, asunto, mensaje);
            }
            ViewData["MENSAJE"] = "email enviado a " + direccionEnvio;
            return View();
        }
    }
}
