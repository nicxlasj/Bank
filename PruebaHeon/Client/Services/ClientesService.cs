using PruebaHeon.Shared;
using System.Text.Json;

namespace PruebaHeon.Client.Services
{
    public class ClientesService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl = "api/clientes";
        private readonly JsonSerializerOptions? _options;

        public ClientesService(HttpClient httpClient) 
        { 
            _httpClient = httpClient;
            
        }
        public async Task<List<Cliente>> GetClientes() 
        {
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
