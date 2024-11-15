namespace OsintApiSearch
{
    public interface IPicsartService
    {
        Task<bool> MailExistsAsync(string email);
    }
}
