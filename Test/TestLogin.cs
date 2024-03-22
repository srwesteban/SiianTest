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
        public void testPost()
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
                        RestResponse restResponse = new RestResponse((int)statusCode, respuestaData.Result);
                        Console.WriteLine(restResponse);
                    }
                }
            }
        }


        [TestMethod]
        public void testGet()
        {
            using (HttpClient cliente = new HttpClient())
            {
                using (HttpRequestMessage httpmensaje = new HttpRequestMessage())
                {
                    httpmensaje.RequestUri = new Uri(apiUrls.GetUrl("Login"));
                    httpmensaje.Method = HttpMethod.Get;
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
                        RestResponse restResponse = new RestResponse((int)statusCode, respuestaData.Result);
                        Console.WriteLine(restResponse);
                    }
                }
            }
        }

        [TestMethod]
        public void testPut()
        {
            using (HttpClient cliente = new HttpClient())
            {
                using (HttpRequestMessage httpmensaje = new HttpRequestMessage())
                {
                    httpmensaje.RequestUri = new Uri(apiUrls.GetUrl("Login"));
                    httpmensaje.Method = HttpMethod.Put;
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
                        RestResponse restResponse = new RestResponse((int)statusCode, respuestaData.Result);
                        Console.WriteLine(restResponse);
                    }
                }
            }
        }

        [TestMethod]
        public void testDelete()
        {
            using (HttpClient cliente = new HttpClient())
            {
                using (HttpRequestMessage httpmensaje = new HttpRequestMessage())
                {
                    httpmensaje.RequestUri = new Uri(apiUrls.GetUrl("Login"));
                    httpmensaje.Method = HttpMethod.Delete;
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
                        RestResponse restResponse = new RestResponse((int)statusCode, respuestaData.Result);
                        Console.WriteLine(restResponse);
                    }
                }
            }
        }
    }
}
