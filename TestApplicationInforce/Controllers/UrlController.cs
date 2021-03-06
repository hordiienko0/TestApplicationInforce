using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestApplicationInforce.Data;
using TestApplicationInforce.Helper;
using TestApplicationInforce.Models;
using TestApplicationInforce.Services.Interfaces;

namespace TestApplicationInforce.Controllers
{
    public class UrlController : Controller
    {
        private readonly TestApplicationInforceContext _context;
        private readonly IUrlService _service;

        public UrlController(TestApplicationInforceContext context, IUrlService service)
        {
            _context = context;
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var allUrls = await _service.AllShortUrls();

            return View(allUrls);
        }

        public IActionResult Privacy()
        {
            return View();
        }


        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.Urls == null)
        //    {
        //        return NotFound();
        //    }

        //    var urlModel = await _context.Urls.FindAsync(id);
        //    if (urlModel == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(urlModel);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Link,ShortedUrl,Token,Description,Created")] UrlModel urlModel)
        //{
        //    if (id != urlModel.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(urlModel);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!UrlModelExists(urlModel.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
            

        //        return Json(new { isValid = true, html = RenderRazorView.RenderRazorViewToString(this, "Url", _context.Urls.ToList()) });
        //    }
        //    return Json(new { isValid = false, html = RenderRazorView.RenderRazorViewToString(this, "Edit", urlModel) });
        //}

        private bool UrlModelExists(int id)
        {
            return _context.Urls.Any(e => e.Id == id);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var urlModel = await _context.Urls
                .FirstOrDefaultAsync(m => m.Id == id);
            if (urlModel == null)
            {
                return NotFound();
            }

            return View(urlModel);
        }

        // POST: Transaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var urlModel = await _context.Urls.FindAsync(id);
            _context.Urls.Remove(urlModel);
            await _context.SaveChangesAsync();
            return Json(new { html = RenderRazorView.RenderRazorViewToString(this, "Index", _context.Urls.ToList()) });
        }
    }
}
