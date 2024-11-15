namespace OsintApiSearch
{
    public interface IDuoService
    {
        Task<bool> MailExistsAsync(string email);
    }
}
