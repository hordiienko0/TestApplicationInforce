using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestApplicationInforce.Data;
using TestApplicationInforce.Services.Interfaces;

namespace TestApplicationInforce.Controllers
{
    [Authorize]
    public class UrlShorterController : Controller
    {
        private readonly TestApplicationInforceContext _context;
        private readonly IShortenerService _shortener;

        public UrlShorterController(TestApplicationInforceContext context, IShortenerService shortener)
        {
            _context = context;
            _shortener = shortener;
        }

        [HttpGet]
        [Route("/{token}")]
        public IActionResult Index([FromRoute] string token)
        {
            if (string.IsNullOrEmpty(token)) return View();

            var url = _context.Urls.ToList().FirstOrDefault(x => x.Token == token);
            if (url == null) return View();

            _context.SaveChanges();
            return Redirect(url.Link);
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(string link)
        {
            if (_shortener.AlreadyExists(link))
                return View("Index", _context.Urls.ToList().First(x => x.Link == link).Token);

            var token = _shortener.GenerateUniqueToken();
            var result = _shortener.Add(link, token);
            return result ? View("Index", token) : View("Index");
        }
    }
}
