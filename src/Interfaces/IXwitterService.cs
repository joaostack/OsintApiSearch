namespace OsintApiSearch
{
    public interface IXwitterService
    {
        Task<bool> MailExistsAsync(string email);
    }
}
