using Microsoft.AspNetCore.Mvc;
using Avtobus1.Models;
using Avtobus1.Services.Interfaces;

namespace Avtobus1.Controllers
{
    public class UrlController : Controller
    {
        private readonly IUrlService _urlService;

        public UrlController(IUrlService urlService)
        {
            _urlService = urlService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _urlService.GetAllAsync();
            result.ForEach(x => x.ShortUrl = Request.Host + "/" + x.ShortUrl);

            return View(result);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Url url)
        {
            await _urlService.AddAsync(url);

            return RedirectToAction("Get");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _urlService.DeleteAsync(id);

            return RedirectToAction("Get");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var url = await _urlService.FindByIdAsync(id);

            return View(url);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Url url)
        {
            await _urlService.UpdateAsync(url);

            return RedirectToAction("Get");
        }
    }
}
