﻿using System.Collections.Generic;

public class ApiUrls
{
    private string baseUrl = "https://76ad-181-62-56-8.ngrok-free.app/MC/api/";

    private Dictionary<string, string> endpoints = new Dictionary<string, string>();

    public ApiUrls()
    {
        endpoints.Add("Parametros", baseUrl + "ParametrosWebApi/get");

        endpoints.Add("Login", baseUrl + "LoginWebApi");
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