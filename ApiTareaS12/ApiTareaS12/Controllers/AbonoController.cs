using System;
using System.Linq;
using System.Web.Http;
using ApiTareaS12.Entidades;
using ApiTareaS12.Models;

namespace ApiTareaS12.Controllers
{
    public class AbonoController : ApiController
    {
        [HttpPost]
        [Route("api/RegistrarAbono")]
        public long RegistrarAbono(AbonoEnt entidad)
        {
            try
            {
                using (var bd = new PracticaS12Entities())
                {
                    Abono registro = new Abono();
                    registro.Id_Compra = entidad.Id_Compra;
                    registro.Monto = entidad.Monto;
                    registro.Fecha = DateTime.Now;

                    bd.Abonos.Add(registro);
                    bd.SaveChanges();

                    return registro.Id_Abono;
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción según tus necesidades
                throw new Exception($"Error al registrar el abono: {ex.Message}", ex);
            }
        }

        [HttpGet]
        [Route("api/ConsultarPrincipalENAbono")]
        public IHttpActionResult ConsultarPrincipalENAbono()
        {
            try
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

                    return Ok(data);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("api/ObtenerSaldo/{idCompra}")]
        public IHttpActionResult ObtenerSaldo(long idCompra)
        {
            try
            {
                using (var bdset = new PracticaS12Entities())
                {
                    var producto = bdset.Principals.FirstOrDefault(p => p.Id_Compra == idCompra);

                    if (producto != null)
                    {
                        decimal saldo = producto.Saldo;
                        return Ok(saldo);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route("api/ActualizarSaldo/{idCompra}/{nuevoSaldo}")]
        public IHttpActionResult ActualizarSaldo(long idCompra, decimal nuevoSaldo)
        {
            try
            {
                using (var bd = new PracticaS12Entities())
                {
                    var compra = bd.Principals.FirstOrDefault(p => p.Id_Compra == idCompra);

                    if (compra != null)
                    {
                        compra.Saldo = nuevoSaldo;
                        bd.SaveChanges();

                        return Ok();
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

    }
}
