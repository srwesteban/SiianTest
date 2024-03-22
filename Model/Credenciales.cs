using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiianTest.Model
{
    public class Credenciales
    {
        public string UserName { get; } = "ADMINISTRADOR";
        public string Password { get; } = "Sii@n123*";

        public string Token { get; } = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkFETUlOSVNUUkFET1IiLCJuYW1laWQiOiI4MzdmNDk4NS01NmM0LTQ5OWItYWE2Ni05MmVjZTQ0NzQzOTMiLCJuYmYiOjE3MTExMjE1MTYsImV4cCI6MTcxMTEyMzMxNiwiaWF0IjoxNzExMTIxNTE2LCJpc3MiOiJodHRwOi8vbG9jYWxob3N0IiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdCJ9.i6g-wJo8m_mW8b5LZOGETJLhgxhled7E7re0Zh3vGgY";

        public string LoginCredentials
        {
            get
            {
                return $"{{\"UserName\":\"{UserName}\",\"PassWord\":\"{Password}\"}}";
            }
        }
    }
}
