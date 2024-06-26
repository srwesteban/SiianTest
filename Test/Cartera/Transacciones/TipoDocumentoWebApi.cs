﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using SiianTest.Model;
using SiianTest.Test.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SiianTest.Test.Cartera.Transacciones
{
    [TestClass]
    public class TipoDocumentoWebApi
    {


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
                    { "values", "{\"Codigo\":\"Post\",\"Nombre\":\"Post\",\"prefijo\":\"Post\",\"Numeroinicial\": 1,\"Numerofinal\": 999999999,\"Numeroactual\": 1,\"Numeroverificador\": 1,\"Idmodulo\": 1}"}
                };
                var content = new FormUrlEncodedContent(data);
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri(apiUrls.GetUrl("TipoDocumentoWebApi")),//aqui cambias la direccion
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
        public async Task Put()
        {
            Credenciales credenciales = new Credenciales();
            ApiUrls apiUrls = new ApiUrls();
            TestLogin t = new TestLogin();
            string token = await t.ObtenerData();

            using (HttpClient cliente = new HttpClient())
            {
                var data = new Dictionary<string, string>//aqui cambias valores
                {
                    { "key", "60" },
                    { "values", "{\"Codigo\":\"Put\",\"Nombre\":\"Put\",\"prefijo\":\"Put\",\"Numeroinicial\": 1,\"Numerofinal\": 999999999,\"Numeroactual\": 1,\"Numeroverificador\": 1,\"Idmodulo\": 1}"}

                };
                var content = new FormUrlEncodedContent(data);
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri(apiUrls.GetUrl("TipoDocumentoWebApi")),//aqui cambias la direccion
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
                    { "key", "61" }, // escoger un id para eliminar
                };
                var content = new FormUrlEncodedContent(data);
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri(apiUrls.GetUrl("TipoDocumentoWebApi")),//aqui cambias la direccion
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

        [TestMethod]
        public async Task GetCartera()
        {
            Credenciales credenciales = new Credenciales();
            ApiUrls apiUrls = new ApiUrls();
            TestLogin t = new TestLogin();
            string token = await t.ObtenerData();
            using (HttpClient cliente = new HttpClient())
            {
                using (HttpRequestMessage httpmensaje = new HttpRequestMessage())
                {
                    httpmensaje.RequestUri = new Uri(apiUrls.GetUrl("TipoDocumentoWebApi") + "/GetCartera/?");
                    Console.WriteLine(httpmensaje.RequestUri);
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


        [TestMethod]
        public async Task GetCarteraFiltro()
        {
            Credenciales credenciales = new Credenciales();
            ApiUrls apiUrls = new ApiUrls();
            TestLogin t = new TestLogin();
            string token = await t.ObtenerData();
            using (HttpClient cliente = new HttpClient())
            {
                using (HttpRequestMessage httpmensaje = new HttpRequestMessage())
                {
                    httpmensaje.RequestUri = new Uri("https://95bd-181-62-56-8.ngrok-free.app/NOM/api/TipoDocumentoWebApi/GetCartera/?filter=%5B%22Id%22%2C0%5D&_=1712248203502");
                    Console.WriteLine(httpmensaje.RequestUri);
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
    }
}
