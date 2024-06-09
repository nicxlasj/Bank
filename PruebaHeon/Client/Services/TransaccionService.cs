using PruebaHeon.Shared;
using System.Text.Json;

namespace PruebaHeon.Client.Services
{
    public class TransaccionService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl = "api/transaccion";
        private readonly string _apiUrlFormaPago = "api/transaccion/formapago";
        private readonly string _apiUrlTipobancos= "api/transaccion/banco";
        private readonly JsonSerializerOptions _options = new JsonSerializerOptions();
        public TransaccionService(HttpClient httpClient) 
        { 
            _httpClient = httpClient;
        }
        public async Task<List<Transaccion>> GetTransacciones(int id)
        {
            var response = await _httpClient.GetAsync(_apiUrl + $"/{id}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            return JsonSerializer.Deserialize<List<Transaccion>>(content, _options)!;
        }
        public async Task<List<FormaPago>> GetFormasPago()
        {
            var response = await _httpClient.GetAsync(_apiUrlFormaPago);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            return JsonSerializer.Deserialize<List<FormaPago>>(content, _options)!;
        }

        public async Task<List<Banco>> GetBancos()
        {
            var response = await _httpClient.GetAsync(_apiUrlTipobancos);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            return JsonSerializer.Deserialize<List<Banco>>(content, _options)!;
        }

    }
}
