using Microsoft.VisualStudio.TestTools.UnitTesting;
using SiianTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SiianTest.Test
{
    [TestClass]
    public class TestCierreDia
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

                    httpmensaje.RequestUri = new Uri("https://95bd-181-62-56-8.ngrok-free.app/NOM/CierreDia"); // Aquí se establece la URL
                    httpmensaje.Method = HttpMethod.Get;
                    httpmensaje.Headers.Add("Accept", "application/json");
                    httpmensaje.Headers.Add("transport", "webSockets");
                    httpmensaje.Headers.Add("clientProtocol", "2.1");
                    httpmensaje.Headers.Add("connectionToken", "5Jb7XYFD1v9nmo3KAwPkdejIlWSs8iDIREEOQygMckioW6CmSQuEmJmOS1uE0ViFq38OfQzbtZJYbLn");
                    httpmensaje.Headers.Add("connectionData", "[{\"name\":\"counterhub\"}]");
                    httpmensaje.Headers.Add("tid", "1");

                    httpmensaje.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

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



        [TestMethod]
        public async Task GetAll()
        {
            Credenciales credenciales = new Credenciales();
            ApiUrls apiUrls = new ApiUrls();
            TestLogin t = new TestLogin();
            string token = await t.ObtenerData();

            using (HttpClient cliente = new HttpClient())
            {
                using (HttpRequestMessage httpmensaje = new HttpRequestMessage())
                {
                    httpmensaje.RequestUri = new Uri("https://95bd-181-62-56-8.ngrok-free.app/NOM/CierreDia/CierreDia");
                    httpmensaje.Method = HttpMethod.Get;
                    httpmensaje.Headers.Add("Accept", "application/json");

                    httpmensaje.Headers.Add("transport", "webSockets");
                    httpmensaje.Headers.Add("clientProtocol", "2.1");
                    httpmensaje.Headers.Add("connectionToken", "5Jb7XYFD1v9nmo3KAwPkdejIlWSs8iDIREEOQygMckioW6CmSQuEmJmOS1uE0ViFq38OfQzbtZJYbLn");
                    httpmensaje.Headers.Add("connectionData", "[{\"name\":\"counterhub\"}]");
                    httpmensaje.Headers.Add("tid", "1");

                    httpmensaje.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    HttpResponseMessage respuesta = await cliente.SendAsync(httpmensaje);

                    HttpStatusCode statusCode = respuesta.StatusCode;
                    string data = await respuesta.Content.ReadAsStringAsync();
                    Console.WriteLine($"StatusCode: {statusCode}, ResponseData: {data}");
                }
            }
        }

        [TestMethod]
        public async Task Post()
        {
            Credenciales credenciales = new Credenciales();
            ApiUrls apiUrls = new ApiUrls();
            TestLogin t = new TestLogin();
            string token = await t.ObtenerData();

            using (HttpClient cliente = new HttpClient())
            {
                var data = new Dictionary<string, string>
                {
                    { "FECHA", "2023-12-06" } 
                };
                var content = new FormUrlEncodedContent(data);
                var handler = new HttpClientHandler();
                handler.UseCookies = true;
                handler.CookieContainer = new CookieContainer();
                handler.CookieContainer.Add(new Uri("https://95bd-181-62-56-8.ngrok-free.app"), new Cookie("cookieName", "cookieValue"));

                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri("https://95bd-181-62-56-8.ngrok-free.app/NOM/CierreDia/CierreDiaPost"),
                    Method = HttpMethod.Post,
                    Content = content
                };
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                cliente.Timeout = TimeSpan.FromSeconds(10); // Establece el tiempo de espera
                cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                cliente.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
                cliente.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate"));
                cliente.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("br"));
                cliente.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("zstd"));
                cliente.DefaultRequestHeaders.Add("Connection", "keep-alive");

                HttpResponseMessage response = await cliente.SendAsync(request);

                using (HttpResponseMessage mensaje = response)
                {
                    Console.WriteLine(mensaje.ToString());

                    HttpStatusCode statusCode = mensaje.StatusCode;

                    HttpContent respuestaContenido = mensaje.Content;
                    Task<string> respuestaData = respuestaContenido.ReadAsStringAsync();
                    string responseData = respuestaData.Result;

                    RestResponse restResponse = new RestResponse((int)statusCode, responseData);
                    Console.WriteLine(restResponse);
                }
            }
        }

    }
}