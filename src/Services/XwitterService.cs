using System.Text.Json;

namespace OsintApiSearch
{
    public class XwitterService : IXwitterService
    {
        private readonly HttpClient _httpClient;

        public XwitterService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> MailExistsAsync(string email)
        {
            var url = $"i/users/email_available.json?email={email}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Xwitter API Error: {response.StatusCode}");
            }

            var content = await response.Content.ReadAsStringAsync();
            var json = JsonSerializer.Deserialize<Xwitter.Root>(content);

            if (json.taken == false)
            {
                return false;
            }

            return true;
        }
    }
}
