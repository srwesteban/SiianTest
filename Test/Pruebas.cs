using Microsoft.VisualStudio.TestTools.UnitTesting;
using SiianTest.Model;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using WebServiceAutomation.Helper.Request;
using WebServiceAutomation.Helper.Response;
using WebServiceAutomation.Model.JsonModel;


namespace SiianTest.Test
{
    [TestClass]
    public  class Pruebas
    {
        private string getUrl = "https://76ad-181-62-56-8.ngrok-free.app/MC/api/ParametrosWebApi/get";
        private string secureGetUrl = "https://76ad-181-62-56-8.ngrok-free.app/MC/api/LoginWebApi";
        

        [TestMethod]
        public void pruebaUno()
        {
            //paso 1 crear el objecto cliente
            HttpClient client = new HttpClient();

            //paso 2 crear la peticion
            Uri uri = new Uri(getUrl);

            Task<HttpResponseMessage> httpResponse = client.GetAsync(uri);

            HttpResponseMessage  httpResponseMessage = httpResponse.Result;
            Console.WriteLine(httpResponseMessage.ToString());

            HttpStatusCode statusCode = httpResponseMessage.StatusCode;
            Console.WriteLine("Status Code: " + statusCode);
            Console.WriteLine("Status Code: " + (int)statusCode);

            // respuesta con datos

            HttpContent respuestaContenido = httpResponseMessage.Content;
            Task<string> respuestaData = respuestaContenido.ReadAsStringAsync();
            string data = respuestaData.Result;
            Console.WriteLine(data);


            client.Dispose();


        }

        [TestMethod]
        public void PruebaDos()
        {
            MediaTypeWithQualityHeaderValue jsonHeader = new MediaTypeWithQualityHeaderValue("application/json");
            HttpClient cliente = new HttpClient();

            HttpRequestHeaders headers = cliente.DefaultRequestHeaders;
            headers.Accept.Add(jsonHeader);
            //headers.Add("Accept", "application/json");

            Task<HttpResponseMessage> httpResponse = cliente.GetAsync(getUrl);

            HttpResponseMessage httpResponseMessage = httpResponse.Result;
            Console.WriteLine(httpResponseMessage.ToString());

            HttpStatusCode statusCode = httpResponseMessage.StatusCode;
            Console.WriteLine("Status Code: " + statusCode);
            Console.WriteLine("Status Code: " + (int)statusCode);

            // respuesta con datos

            HttpContent respuestaContenido = httpResponseMessage.Content;
            Task<string> respuestaData = respuestaContenido.ReadAsStringAsync();
            string data = respuestaData.Result;
            Console.WriteLine(data);


            cliente.Dispose();

        }

        [TestMethod]
        public void PruebaTres()
        {
            HttpRequestMessage httpmensaje = new HttpRequestMessage();
            httpmensaje.RequestUri = new Uri(getUrl);
            httpmensaje.Method = HttpMethod.Get;
            httpmensaje.Headers.Add("Accept", "application/json");


            HttpClient cliente = new HttpClient();

            Task<HttpResponseMessage> httpResponse = cliente.SendAsync(httpmensaje);


            HttpResponseMessage httpResponseMessage = httpResponse.Result;
            Console.WriteLine(httpResponseMessage.ToString());

            HttpStatusCode statusCode = httpResponseMessage.StatusCode;
            Console.WriteLine("Status Code: " + statusCode);
            Console.WriteLine("Status Code: " + (int)statusCode);

            // respuesta con datos

            HttpContent respuestaContenido = httpResponseMessage.Content;
            Task<string> respuestaData = respuestaContenido.ReadAsStringAsync();
            string data = respuestaData.Result;
            Console.WriteLine(data);


            cliente.Dispose();

        }

        [TestMethod]
        public void PruebaCuatro()
        {
            using (HttpClient cliente = new HttpClient())
            {
                using(HttpRequestMessage httpmensaje = new HttpRequestMessage())
                {
                    httpmensaje.RequestUri = new Uri(getUrl);
                    httpmensaje.Method= HttpMethod.Get;
                    httpmensaje.Headers.Add("Accept", "application/json");

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
        public void loginAuth()
        {
            Dictionary<string ,string> httpHeader = new Dictionary<string ,string>();
            httpHeader.Add("Accept", "application/json");
            httpHeader.Add("Authorization", "Basic eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkFETUlOSVNUUkFET1IiLCJuYW1laWQiOiI4MzdmNDk4NS01NmM0LTQ5OWItYWE2Ni05MmVjZTQ0NzQzOTMiLCJuYmYiOjE3MTEwODk3MzUsImV4cCI6MTcxMTA5MTUzNSwiaWF0IjoxNzExMDg5NzM1LCJpc3MiOiJodHRwOi8vbG9jYWxob3N0IiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdCJ9.ZPxbNorkvuymVXhXeHqcDgpKIACHnmBD49aFYqGcUcA ");

            RestResponse restResponse = HttpClientHelper.PerformGetRequest(secureGetUrl, httpHeader);

            Assert.AreEqual(200, restResponse.StatusCode);

            List<JsonRootObject> jsonData = ResponseDataHelper.DeserializeJsonResponse<List<JsonRootObject>>
                (restResponse.ResponseData);

            Console.WriteLine(jsonData.ToString());
        }


        [TestMethod]
        public void testLogin()
        {
            using (HttpClient cliente = new HttpClient())
            {
                using (HttpRequestMessage httpmensaje = new HttpRequestMessage())
                {
                    httpmensaje.RequestUri = new Uri(secureGetUrl);
                    httpmensaje.Method = HttpMethod.Post;
                    httpmensaje.Headers.Add("Accept", "application/json");

                    // JSON que quieres enviar en el cuerpo de la solicitud
                    string json = "{\"UserName\":\"ADMINISTRADOR\",\"PassWord\":\"Sii@n123*\"}";
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
        public void testLoginError()
        {
            using (HttpClient cliente = new HttpClient())
            {
                using (HttpRequestMessage httpmensaje = new HttpRequestMessage())
                {
                    httpmensaje.RequestUri = new Uri(secureGetUrl);
                    httpmensaje.Method = HttpMethod.Post;
                    httpmensaje.Headers.Add("Accept", "application/json");

                    // JSON que quieres enviar en el cuerpo de la solicitud
                    string json = "{\"UserName\":\"UsuarioError\",\"PassWord\":\"ClaveError\"}";
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
        public void GetDatosApi()
        {
            string token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkFETUlOSVNUUkFET1IiLCJuYW1laWQiOiI4MzdmNDk4NS01NmM0LTQ5OWItYWE2Ni05MmVjZTQ0NzQzOTMiLCJuYmYiOjE3MTExMjE1MTYsImV4cCI6MTcxMTEyMzMxNiwiaWF0IjoxNzExMTIxNTE2LCJpc3MiOiJodHRwOi8vbG9jYWxob3N0IiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdCJ9.i6g-wJo8m_mW8b5LZOGETJLhgxhled7E7re0Zh3vGgY";
            using (HttpClient cliente = new HttpClient())
            {
                using (HttpRequestMessage httpmensaje = new HttpRequestMessage())
                {
                    httpmensaje.RequestUri = new Uri(getUrl);
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


    }
}
