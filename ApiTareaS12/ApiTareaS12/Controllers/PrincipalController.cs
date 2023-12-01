using ApiTareaS12.Entidades;
using ApiTareaS12.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiTareaS12.Controllers
{
    public class PrincipalController : ApiController
    {
        [HttpGet]
        [Route("api/ConsultarPrincipal")]
        public List<PrincipalEnt> ConsultarPrincipal()
        {
            using (var bdset = new PracticaS12Entities())
            {
                var data = (from p in bdset.Principals
                            select new PrincipalEnt
                            {
                                Id_Compra = p.Id_Compra,
                                Precio = p.Precio,
                                Saldo = p.Saldo,
                                Descripcion = p.Descripcion,
                                Estado = p.Estado
                            }).ToList();

                return data;
            }
        }
    }
}
