namespace OsintApiSearch
{
    public interface IChessService
    {
        Task<bool> MailExistsAsync(string email);
    }
}
