using PruebaHeon.Shared;
using System.Text.Json;

namespace PruebaHeon.Client.Services
{
    public class ClientesService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl = "api/clientes";
        private readonly JsonSerializerOptions _options = new JsonSerializerOptions();

        public ClientesService(HttpClient httpClient) 
        { 
            _httpClient = httpClient;
            
        }
        public async Task<List<Cliente>> GetClientes(string token) 
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await _httpClient.GetAsync(_apiUrl);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content);
            }
            return JsonSerializer.Deserialize<List<Cliente>>(content, _options)!;
        }


    }
}
