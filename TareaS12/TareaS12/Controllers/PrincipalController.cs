using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TareaS12.Models;

namespace TareaS12.Controllers
{
    public class PrincipalController : Controller
    {
        PrincipalModel modelo = new PrincipalModel();
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult ConsultarPrincipal()
        {
            var datos = modelo.ConsultarPrincipal();
            return View(datos);
        }


    }
}