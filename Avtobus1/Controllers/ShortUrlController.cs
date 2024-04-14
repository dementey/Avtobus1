using Microsoft.AspNetCore.Mvc;
using Avtobus1.Services.Interfaces;

namespace Avtobus1.Controllers
{
    public class ShortUrlController : Controller 
    {
        private readonly IUrlService _urlService;

        public ShortUrlController(IUrlService urlService)
        {
            _urlService = urlService;
        }

        [HttpGet("/{shortUrl}")]
        public async Task Get(string shortUrl)
        {
            var url = await _urlService.RedirectAsync(shortUrl);

            Response.Redirect($"{url.LongUrl}");
        }
    }
}
