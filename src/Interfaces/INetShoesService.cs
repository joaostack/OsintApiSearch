namespace OsintApiSearch
{
    public interface INetShoesService
    {
        Task<bool> MailExistsAsync(string email);
    }
}
