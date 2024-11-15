using System.Text.Json;

namespace OsintApiSearch
{
    public class DuoService : IDuoService
    {
        private readonly HttpClient _httpClient;

        public DuoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> MailExistsAsync(string email)
        {
            var url = $"2017-06-30/users?email={email}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Duolingo API Error: {response.StatusCode}");
            }

            var content = await response.Content.ReadAsStringAsync();
            var json = JsonSerializer.Deserialize<Duolingo.Root>(content);

            if (json.users == null)
            {
                return false;
            }

            return true;
        }
    }
}
