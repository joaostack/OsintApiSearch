using System.Text.Json;

namespace OsintApiSearch
{
    public class PicsartService : IPicsartService
    {
        private readonly HttpClient _httpClient;

        public PicsartService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> MailExistsAsync(string email)
        {
            var url = $"users/email/existence?email_encoded=0&emails={email}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Picsart API Error: {response.StatusCode}");
            }

            var content = await response.Content.ReadAsStringAsync();
            var json = JsonSerializer.Deserialize<Picsart.Root>(content);

            if (json.response.Count == 0)
            {
                return false;
            }

            return true;
        }
    }
}
