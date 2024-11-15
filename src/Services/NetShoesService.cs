using System.Text.Json;

namespace OsintApiSearch
{
    public class NetShoesService : INetShoesService
    {
        private readonly HttpClient _httpClient;

        public NetShoesService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> MailExistsAsync(string email)
        {
            var url = $"auth/account/exists/{email}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"NetShoes API Error: {response.StatusCode}");
            }

            var content = await response.Content.ReadAsStringAsync();
            var json = JsonSerializer.Deserialize<NetShoes.Root>(content);

            if (json.exists == false)
            {
                return false;
            }

            return true;
        }
    }
}
