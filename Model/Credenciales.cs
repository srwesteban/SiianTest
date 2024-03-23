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
        public string Token { get; }

    = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkFETUlOSVNUUkFET1IiLCJuYW1laWQiOiI4MzdmNDk4NS01NmM0LTQ5OWItYWE2Ni05MmVjZTQ0NzQzOTMiLCJuYmYiOjE3MTEyMDY0ODMsImV4cCI6MTcxMTIwODI4MywiaWF0IjoxNzExMjA2NDgzLCJpc3MiOiJodHRwOi8vbG9jYWxob3N0IiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdCJ9.w7DqtsjK7zdewyTJm4ZOLFbZTwqee5kstn4q8WvNH7I";
        public string UserName { get; } = "ADMINISTRADOR";
        public string Password { get; } = "Sii@n123*";

        public string LoginCredentials
        {
            get
            {
                return $"{{\"UserName\":\"{UserName}\",\"PassWord\":\"{Password}\"}}";
            }
        }

        public async Task<string> ObtenerToken()
        {
            ApiUrls apiUrls = new ApiUrls();
            using (HttpClient cliente = new HttpClient())
            {
                HttpResponseMessage mensaje = await cliente.PostAsync(apiUrls.GetUrl("Login"), new StringContent(LoginCredentials, System.Text.Encoding.UTF8, "application/json"));
                string token = await mensaje.Content.ReadAsStringAsync();
                return token;
            }
        }


    }
}
