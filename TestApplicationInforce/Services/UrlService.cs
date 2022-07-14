using Microsoft.EntityFrameworkCore;
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

        public async Task<List<UrlModel>>  AllShortUrls()
        {
            var urlList = await _context.Urls.ToListAsync();

            return urlList;
        }
    }
}
