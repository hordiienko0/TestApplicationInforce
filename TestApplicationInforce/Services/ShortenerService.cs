using TestApplicationInforce.Data;
using TestApplicationInforce.Services.Interfaces;

namespace TestApplicationInforce.Services
{
    public class ShortenerService :DataService, IShortenerService
    {
        private string letters = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789";

        public ShortenerService(TestApplicationInforceContext context) : base(context)
        {
        }

        public bool Add(string link, string token)
        {
            throw new NotImplementedException();
        }

        public bool AlreadyExists(string link)
        {
            throw new NotImplementedException();
        }

        public string GenerateUniqueToken()
        {
            throw new NotImplementedException();
        }
    }
}
