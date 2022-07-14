using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestApplicationInforce.Data;
using TestApplicationInforce.Models;
using TestApplicationInforce.Services.Interfaces;

namespace TestApplicationInforce.Controllers
{
    public class HomeController : Controller
    {
        private readonly TestApplicationInforceContext _context;
        private readonly IUrlService _service;

        public HomeController(TestApplicationInforceContext context, IUrlService service)
        {
            _context = context;
            _service = service;
        }

        public IActionResult Index()
        {
            var allUrls = _service.AllShortUrls();
            return View(allUrls);
        }

        public IActionResult Privacy()
        {
            return View();
        }


    }
}