using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SiianTest.Model
{
    public class Credenciales
    {
        public string Token { get; } = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkFETUlOSVNUUkFET1IiLCJuYW1laWQiOiI4MzdmNDk4NS01NmM0LTQ5OWItYWE2Ni05MmVjZTQ0NzQzOTMiLCJuYmYiOjE3MTExMzI4NzEsImV4cCI6MTcxMTEzNDY3MSwiaWF0IjoxNzExMTMyODcxLCJpc3MiOiJodHRwOi8vbG9jYWxob3N0IiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdCJ9.NdMpu0zQVQuysyZbNkXNIJPOh9G4LxAKlsVmPHsYqCI";

        public string UserName { get; } = "ADMINISTRADOR";
        public string Password { get; } = "Sii@n123*";

        public string LoginCredentials
        {
            get
            {
                return $"{{\"UserName\":\"{UserName}\",\"PassWord\":\"{Password}\"}}";
            }
        }



        public string ObtenerAutenficacion()
        {
            ApiUrls api = new ApiUrls();
            string responseData = string.Empty;
            using (HttpClient cliente = new HttpClient())
            {
                using (HttpRequestMessage httpmensaje = new HttpRequestMessage())
                {
                    httpmensaje.RequestUri = new Uri(api.GetUrl("Login"));
                    httpmensaje.Method = HttpMethod.Post;
                    httpmensaje.Headers.Add("Accept", "application/json");
                    string json = LoginCredentials;
                    httpmensaje.Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage mensaje = cliente.SendAsync(httpmensaje).Result;

                    HttpStatusCode statusCode = mensaje.StatusCode;
                    HttpContent respuestaContenido = mensaje.Content;
                    responseData = respuestaContenido.ReadAsStringAsync().Result;
                }
            }
            return responseData;
        }
    }
}
