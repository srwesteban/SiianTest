using Microsoft.VisualStudio.TestTools.UnitTesting;
using SiianTest.Model;
using SiianTest.Test.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SiianTest.Test.Cartera.Consultas
{
    [TestClass]
    public class VistaDetallePrestamoWebApi
    {
        [TestMethod]
        public async Task Get()
        {
            Credenciales credenciales = new Credenciales();
            ApiUrls apiUrls = new ApiUrls();
            TestLogin t = new TestLogin();
            string token = await t.ObtenerData();
            using (HttpClient cliente = new HttpClient())
            {
                using (HttpRequestMessage httpmensaje = new HttpRequestMessage())
                {
                    httpmensaje.RequestUri = new Uri(apiUrls.GetUrl("VistaDetallePrestamoWebApi") + "/Get/");
                    httpmensaje.Method = HttpMethod.Get;
                    httpmensaje.Headers.Add("Accept", "application/json");
                    httpmensaje.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    Task<HttpResponseMessage> httpResponse = cliente.SendAsync(httpmensaje);
                    using (HttpResponseMessage mensaje = httpResponse.Result)
                    {
                        Console.WriteLine(mensaje.ToString());
                        HttpStatusCode statusCode = mensaje.StatusCode;
                        HttpContent respuestaContenido = mensaje.Content;
                        Task<string> respuestaData = respuestaContenido.ReadAsStringAsync();
                        string data = respuestaData.Result;
                        RestResponse restResponse = new RestResponse((int)statusCode, respuestaData.Result);
                        Console.WriteLine(restResponse);
                    }
                }
            }
        }
        //
    }
}
