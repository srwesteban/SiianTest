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
