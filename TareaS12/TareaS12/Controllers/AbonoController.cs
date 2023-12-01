using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using TareaS12.Entidades;
using TareaS12.Models;

namespace TareaS12.Controllers
{
    public class AbonoController : Controller
    {
        AbonoModel modelo = new AbonoModel();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ConsultarPrincipalENAbono()
        {
            var datos = modelo.ConsultarPrincipalENAbono();
            return View(datos);
        }

        [HttpGet]
        public ActionResult ObtenerSaldo(long idCompra)
        {
            var saldo = modelo.ObtenerSaldo(idCompra);
            return Json(saldo, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult RegistrarAbono(long idCompra, decimal monto)
        {
            try
            {
                decimal saldoActual = modelo.ObtenerSaldo(idCompra);

                if (monto <= saldoActual)
                {
                    modelo.RegistrarAbono(new AbonoEnt { Id_Compra = idCompra, Monto = monto });

                    decimal nuevoSaldo = saldoActual - monto;
                    modelo.ActualizarSaldo(idCompra, nuevoSaldo);

                    TempData["Mensaje"] = "Abono registrado correctamente";

                    return Json(new { success = true });
                }
                else
                {
                    TempData["Mensaje"] = "El monto ingresado es mayor que el saldo actual.";
                }
            }
            catch (Exception ex)
            {
                TempData["Mensaje"] = $"Error: {ex.Message}";
            }

            return Json(new { success = false, message = TempData["Mensaje"] });
        }




    }
}