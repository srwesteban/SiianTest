using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SiianTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;


namespace SiianTest.Test
{
    [TestClass]
    public class TestEstratos
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

                    httpmensaje.RequestUri = new Uri(apiUrls.GetUrl("Estrato"));
                    httpmensaje.Method = HttpMethod.Get;
                    httpmensaje.Headers.Add("Accept", "application/json");

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
        public async Task Put()
        {
            Credenciales credenciales = new Credenciales();
            ApiUrls apiUrls = new ApiUrls();
            TestLogin t = new TestLogin();
            string token = await t.ObtenerData();

            using (HttpClient cliente = new HttpClient())
            {
                var data = new Dictionary<string, string>
                {
                    { "key", "11" },
                    { "values", "{\"Id\":11,\"Nombre\":\"test12\",\"Estaactivo\":null,\"Codigo\":\"test12\"}" }
                };
                var content = new FormUrlEncodedContent(data);
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri(apiUrls.GetUrl("Estrato")),
                    Method = HttpMethod.Put,
                    Content = content
                };
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage response = await cliente.SendAsync(request);

                using (HttpResponseMessage mensaje = response)
                {
                    Console.WriteLine(mensaje.ToString());
                    HttpStatusCode statusCode = mensaje.StatusCode;
                    HttpContent respuestaContenido = mensaje.Content;
                    Task<string> respuestaData = respuestaContenido.ReadAsStringAsync();
                    RestResponse restResponse = new RestResponse((int)statusCode, respuestaData.Result);
                    Console.WriteLine(restResponse);
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
                var data = new Dictionary<string, string>//aqui cambias valores
                {
                    { "key", "0" },
                    { "values", "{\"Nombre\":\"post\",\"Estaactivo\":null,\"Codigo\":\"post\"}" }
                };
                var content = new FormUrlEncodedContent(data);
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri(apiUrls.GetUrl("Estrato")),//aqui cambias la direccion
                    Method = HttpMethod.Post, //cambias el metodo
                    Content = content
                };
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
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

        [TestMethod]
        public async Task Delete()
        {
            Credenciales credenciales = new Credenciales();
            ApiUrls apiUrls = new ApiUrls();
            TestLogin t = new TestLogin();
            string token = await t.ObtenerData();

            using (HttpClient cliente = new HttpClient())
            {
                var data = new Dictionary<string, string>
                {
                    { "key", "12" } // escoger un id para eliminar
                };
                var content = new FormUrlEncodedContent(data);
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri(apiUrls.GetUrl("Estrato")),//aqui cambias la direccion
                    Method = HttpMethod.Delete, //cambias el metodo
                    Content = content
                };
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
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
