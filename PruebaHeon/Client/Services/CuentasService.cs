﻿using PruebaHeon.Shared;
using System.Net.Http.Json;
using System.Text.Json;

namespace PruebaHeon.Client.Services
{
    public class CuentasService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl = "api/cuentas";
        private readonly string _apiUrlTipoCuenta = "api/tipocuenta";
        private readonly JsonSerializerOptions _options = new JsonSerializerOptions();
        public CuentasService(HttpClient httpClient) 
        { 
            _httpClient = httpClient;
        }

        public async Task<List<Cuenta>> GetCuentas(int id) 
        {
            var response = await _httpClient.GetAsync(_apiUrl + $"/{id}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            return JsonSerializer.Deserialize<List<Cuenta>>(content, _options)!;
        }
        public async Task<List<TipoCuenta>> GetTipoCuentas() 
        {
            var response = await _httpClient.GetAsync(_apiUrlTipoCuenta);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            return JsonSerializer.Deserialize<List<TipoCuenta>>(content, _options)!;

        
        }
        public async Task SaveCuenta(Cuenta cuenta) 
        {
            var response = await _httpClient.PostAsync(_apiUrl, JsonContent.Create(cuenta));
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }

        }
    }
}
