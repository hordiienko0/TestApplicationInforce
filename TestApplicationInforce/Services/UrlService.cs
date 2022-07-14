using TestApplicationInforce.Data;
using TestApplicationInforce.Models;
using TestApplicationInforce.Services.Interfaces;

namespace TestApplicationInforce.Services
{
    public class UrlService : DataService, IUrlService
    {
        public UrlService(TestApplicationInforceContext context) : base(context)
        {
        }

        public List<UrlModel> AllShortUrls()
        {
            return _context.Urls.ToList();
        }
    }
}
