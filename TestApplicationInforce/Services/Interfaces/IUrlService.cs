using TestApplicationInforce.Models;

namespace TestApplicationInforce.Services.Interfaces
{
    public interface IUrlService
    {
        List<UrlModel> AllShortUrls();
    }
}
