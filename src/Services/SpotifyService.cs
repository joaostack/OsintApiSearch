using System.Text.Json;

namespace OsintApiSearch
{
    public class SpotifyService : ISpotifyService
    {
        private readonly HttpClient _httpClient;

        public SpotifyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> MailExistsAsync(string email)
        {
            var url = $"signup/public/v1/account?validate=1&email={email}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Spotify API Error: {response.StatusCode}");
            }

            var content = await response.Content.ReadAsStringAsync();
            var json = JsonSerializer.Deserialize<Spotify.Root>(content);

            if (json.errors == null)
            {
                return false;
            }

            return true;
        }
    }
}
