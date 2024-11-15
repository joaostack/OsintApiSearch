using System.Text.Json;

namespace OsintApiSearch
{
    public class ChessService : IChessService
    {
        private readonly HttpClient _httpClient;

        public ChessService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> MailExistsAsync(string email)
        {
            var url = $"callback/email/available?email={email}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Chess API Error: {response.StatusCode}");
            }

            var content = await response.Content.ReadAsByteArrayAsync();
            var json = JsonSerializer.Deserialize<Chess.Root>(content);

            if (json.isEmailAvailable == false)
            {
                return false;
            }

            return true;
        }
    }
}
