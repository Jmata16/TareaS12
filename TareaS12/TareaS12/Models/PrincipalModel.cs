using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using TareaS12.Entidades;
using System.Net.Http.Json;

namespace TareaS12.Models
{
    public class PrincipalModel
    {
        public List<PrincipalEnt> ConsultarPrincipal()
        {
            using (var http = new HttpClient())
            {
                var url = "https://localhost:44362/api/ConsultarPrincipal";
                var resp = http.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                    return resp.Content.ReadFromJsonAsync<List<PrincipalEnt>>().Result;
                else
                    return new List<PrincipalEnt>();
            }
        }


    }
}