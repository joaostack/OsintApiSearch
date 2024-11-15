namespace OsintApiSearch
{
    public interface ISpotifyService
    {
        Task<bool> MailExistsAsync(string email);
    }
}
