using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using TareaS12.Entidades;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using static System.Net.WebRequestMethods;

namespace TareaS12.Models
{
    public class AbonoModel
    {
        public List<PrincipalEnt> ConsultarPrincipalENAbono()
        {
            using (var http = new HttpClient())
            {
                var url = "https://localhost:44362/api/ConsultarPrincipalENAbono";
                var resp = http.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                    return resp.Content.ReadFromJsonAsync<List<PrincipalEnt>>().Result;
                else
                    return new List<PrincipalEnt>();
            }
        }

        public decimal ObtenerSaldo(long idCompra)
        {
            using (var http = new HttpClient())
            {
                var url = $"https://localhost:44362/api/ObtenerSaldo/{idCompra}";
                var resp = http.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                    return resp.Content.ReadAsAsync<decimal>().Result;
                else
                    return -1; 
            }
        }

        public long RegistrarAbono(AbonoEnt entidad)
        {
            using (var http = new HttpClient())
            {
                var url = "https://localhost:44362/api/RegistrarAbono";
                var resp = http.PostAsJsonAsync(url, entidad).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadAsAsync<long>().Result;
                }

                return 0;
            }
        }


        public void ActualizarSaldo(long idCompra, decimal nuevoSaldo)
        {
            using (var http = new HttpClient())
            {
                var url = $"https://localhost:44362/api/ActualizarSaldo/{idCompra}/{nuevoSaldo}";
                var resp = http.PostAsync(url, null).Result;

                if (!resp.IsSuccessStatusCode)
                {
                    // Manejar el error si la actualización del saldo falla
                    throw new Exception("Error al actualizar el saldo.");
                }
            }
        }


    }
}
