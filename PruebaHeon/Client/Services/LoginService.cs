using PruebaHeon.Client.Pages;
using PruebaHeon.Shared;
using System.Net.Http.Json;
using System.Text.Json;

namespace PruebaHeon.Client.Services
{
	public class LoginService
	{
		private readonly HttpClient _httpClient;
		private readonly string _apiUrl = "api/login";
		private readonly JsonSerializerOptions _options = new JsonSerializerOptions();
		public LoginService(HttpClient httpClient) 
		{ 
			_httpClient = httpClient;
		}

		public async Task<string> Login(Usuario usuario) 
		{
			var response = await _httpClient.PostAsync(_apiUrl, JsonContent.Create(usuario));
			var content = await response.Content.ReadAsStringAsync();
			if (!response.IsSuccessStatusCode)
			{
				throw new ApplicationException(content);
			}
			return content;
		}
	}
}
