using TestApplicationInforce.Data;
using TestApplicationInforce.Models;
using TestApplicationInforce.Services.Interfaces;

namespace TestApplicationInforce.Services
{
    public class ShortenerService : DataService, IShortenerService
    {
        private string letters = "AaBbCcDdEeFfGgHhIiJjKkLlMmNnOoPpQqRrSsTtUuVvWwXxYyZz0123456789";

        public ShortenerService(TestApplicationInforceContext context) : base(context)
        {
        }

        public bool Add(string link, string token)
        {
            var shortedUrl = ($"https://localhost:5000/{token}");
            var url = new UrlModel { Created = DateTime.Now, ShortedUrl = shortedUrl, Link = link, Token = token };
            _context.Urls.Add(url);
            return _context.SaveChanges() == 1;
        }

        public bool AlreadyExists(string link)
        {
            return _context.Urls.ToList().Exists(x => x.Link == link);
        }

        private string GenerateToken()
        {
            var token = string.Empty;
            var rand = new Random();
            for (var i = 0; i < 5; i++)
            {
                var rndInt = rand.Next(0, letters.Length);
                token += letters[rndInt];
            }

            return token;
        }

        private bool TokenExists(string token)
        {
            return _context.Urls.ToList().Exists(x => x.Token == token);
        }
        public string GenerateUniqueToken()
        {
            var token = GenerateToken();
            while (TokenExists(token))
            {
                token = GenerateToken();
            }

            return token;
        }
    }
}
