using System.Text.Json;

namespace PokemonApp.Infra
{
    internal class ApiClient
    {
        private readonly HttpClient m_HttpClient;
        private readonly JsonSerializerOptions m_JsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        public ApiClient() {
            
            m_HttpClient = new HttpClient();
        }
        public async Task<T> GetAsync<T>(string url)
        {
            var response = await m_HttpClient.GetAsync(url);

            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<T>(json, m_JsonOptions);
            if (result is null)
            {
                throw new InvalidOperationException("Deserialization returned null.");
            }
            return result;
        }
    }
}
