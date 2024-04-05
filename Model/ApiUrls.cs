using System.Collections.Generic;

public class ApiUrls
{
    private string baseUrl = "https://95bd-181-62-56-8.ngrok-free.app/NOM/api/";

    private Dictionary<string, string> endpoints = new Dictionary<string, string>();

    public ApiUrls()
    {

        //tablero de control
        endpoints.Add("InformeCarteraWebApi", baseUrl + "InformeCarteraWebApi");
        endpoints.Add("PendientesGestorWebApi", baseUrl + "PendientesGestorWebApi");
        endpoints.Add("VistaGestionEstadoWebApi", baseUrl + "VistaGestionEstadoWebApi");
        ////////

        //terceros
        endpoints.Add("EstratoWebApi", baseUrl + "EstratoWebApi");
        endpoints.Add("NivelEducacionWebApi", baseUrl + "NivelEducacionWebApi");
        endpoints.Add("TipoViviendaWebApi", baseUrl + "TipoViviendaWebApi");
        endpoints.Add("EstadoCivilWebApi", baseUrl + "EstadoCivilWebApi");
        endpoints.Add("GeneroWebApi", baseUrl + "GeneroWebApi");
        //////

        //generales

        //moneda
        endpoints.Add("MonedaWebApi", baseUrl + "MonedaWebApi");
        //sucursales
        endpoints.Add("SucursalWebApi", baseUrl + "SucursalWebApi");
        endpoints.Add("CompaniasWebApi", baseUrl + "CompaniasWebApi");
        endpoints.Add("RegionWebApi", baseUrl + "RegionWebApi");
         

        //cartera

        //Clasificaion
        endpoints.Add("CalificacionWebApi", baseUrl + "CalificacionWebApi");
        endpoints.Add("CalificacionInternaWebApi", baseUrl + "CalificacionInternaWebApi");

        //parametros centrles de riesgo
        endpoints.Add("CentralRiesgoProveedorWebApi", baseUrl + "CentralRiesgoProveedorWebApi");
        endpoints.Add("TipoIdentificacionWebApi", baseUrl + "TipoIdentificacionWebApi");
        endpoints.Add("ClasificacionPrestamoWebApi", baseUrl + "ClasificacionPrestamoWebApi");
        endpoints.Add("FrecuenciasPagoWebApi", baseUrl + "FrecuenciasPagoWebApi");
        endpoints.Add("EstadoPrestamoWebApi", baseUrl + "EstadoPrestamoWebApi");
        // faltan

        //transacciones
        endpoints.Add("TipoDocumentoWebApi", baseUrl + "TipoDocumentoWebApi");
        endpoints.Add("PrestamoMaestroWebApi", baseUrl + "PrestamoMaestroWebApi");
        endpoints.Add("TipoSolicitudWebApi", baseUrl + "TipoSolicitudWebApi");

        //modificaciones
        endpoints.Add("VistaPrestamoConceptoCreditoWebApi", baseUrl + "VistaPrestamoConceptoCreditoWebApi");





        //otros
        endpoints.Add("Parametros", baseUrl + "ParametrosWebApi/get");
        endpoints.Add("Login", baseUrl + "LoginWebApi");
        endpoints.Add("Cierre", baseUrl + "CierreWebApi");


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
