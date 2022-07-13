namespace TestApplicationInforce.Services.Interfaces
{
    public interface IShortenerService
    {
        string GenerateUniqueToken();
        bool AlreadyExists(string link);
        bool Add(string link, string token);
    }
}
