using System.Collections.Generic;

public class ApiUrls
{
    private string baseUrl = "https://95bd-181-62-56-8.ngrok-free.app/NOM/api/";

    private Dictionary<string, string> endpoints = new Dictionary<string, string>();

    public ApiUrls()
    {
        endpoints.Add("Parametros", baseUrl + "ParametrosWebApi/get");

        endpoints.Add("Login", baseUrl + "LoginWebApi");

        endpoints.Add("Estrato", baseUrl + "EstratoWebApi");

        endpoints.Add("NivelEducacion", baseUrl + "NivelEducacionWebApi");

        endpoints.Add("TipoVivienda", baseUrl + "TipoViviendaWebApi");

        endpoints.Add("EstadoCivil", baseUrl + "EstadoCivilWebApi");

        endpoints.Add("Genero", baseUrl + "GeneroWebApi");

        endpoints.Add("Cierre", baseUrl + "CierreWebApi");

        endpoints.Add("VistaGestionEstadoWebApi", baseUrl + "VistaGestionEstadoWebApi");

        endpoints.Add("PendientesGestorWebApi", baseUrl + "PendientesGestorWebApi");

        endpoints.Add("InformeCarteraWebApi", baseUrl + "InformeCarteraWebApi");

        endpoints.Add("MonedaWebApi", baseUrl + "MonedaWebApi");

        endpoints.Add("ModuloWebApi", baseUrl + "ModuloWebApi");

        endpoints.Add("RegionWebApi", baseUrl + "RegionWebApi");

        endpoints.Add("SucursalWebApi", baseUrl + "SucursalWebApi");

        endpoints.Add("CompaniasWebApi", baseUrl + "CompaniasWebApi");


    }

    public string GetUrl(string endpointName)
    {
        if (endpoints.ContainsKey(endpointName))
        {
            return endpoints[endpointName];
        }
        else
        {
            throw new KeyNotFoundException($"El endpoint '{endpointName}' no fue encontrado.");
        }
    }
}
