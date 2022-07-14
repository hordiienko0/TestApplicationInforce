using TestApplicationInforce.Models;

namespace TestApplicationInforce.Services.Interfaces
{
    public interface IUrlService
    {
       Task<List<UrlModel>> AllShortUrls();

    }
}
