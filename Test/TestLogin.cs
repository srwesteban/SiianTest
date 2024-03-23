using Microsoft.VisualStudio.TestTools.UnitTesting;
using SiianTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SiianTest.Test
{
    [TestClass]
    public class TestLogin
    {
        ApiUrls apiUrls = new ApiUrls();
        Credenciales credenciales = new Credenciales();

        [TestMethod]
        public async Task ObtenerToken()
        {
            using (HttpClient cliente = new HttpClient())
            {
                HttpResponseMessage mensaje = await cliente.PostAsync(apiUrls.GetUrl("Login"), new StringContent(credenciales.LoginCredentials, System.Text.Encoding.UTF8, "application/json"));
                string data = await mensaje.Content.ReadAsStringAsync();
                Console.WriteLine(data);

            }
        }

        public async Task<string> ObtenerData()
        {
            using (HttpClient cliente = new HttpClient())
            {
                HttpResponseMessage mensaje = await cliente.PostAsync(apiUrls.GetUrl("Login"), new StringContent(credenciales.LoginCredentials, System.Text.Encoding.UTF8, "application/json"));
                string data = await mensaje.Content.ReadAsStringAsync();
                data = data.Substring(1, data.Length - 2);
                return data;
            }
        }

        [TestMethod]
        public void Post()
        {
            using (HttpClient cliente = new HttpClient())
            {
                using (HttpRequestMessage httpmensaje = new HttpRequestMessage())
                {
                    httpmensaje.RequestUri = new Uri(apiUrls.GetUrl("Login"));
                    httpmensaje.Method = HttpMethod.Post;
                    httpmensaje.Headers.Add("Accept", "application/json");
                    string json = credenciales.LoginCredentials;
                    httpmensaje.Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
                    Task<HttpResponseMessage> httpResponse = cliente.SendAsync(httpmensaje);
                    using (HttpResponseMessage mensaje = httpResponse.Result)
                    {
                        Console.WriteLine(mensaje.ToString());
                        HttpStatusCode statusCode = mensaje.StatusCode;
                        HttpContent respuestaContenido = mensaje.Content;
                        Task<string> respuestaData = respuestaContenido.ReadAsStringAsync();
                        string data = respuestaData.Result;
                        Console.WriteLine(data);
                        RestResponse restResponse = new RestResponse((int)statusCode, respuestaData.Result);
                        Console.WriteLine(restResponse);
                    }
                }
            }
        }
    }
}
