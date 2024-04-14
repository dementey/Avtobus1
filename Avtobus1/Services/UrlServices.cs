using Avtobus1.Data;
using Avtobus1.Models;
using Avtobus1.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Avtobus1.Services
{
    public class UrlServices : IUrlService
    {
        private readonly ApplicationContext _dbContext;

        public UrlServices(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Url> AddAsync(Url url)
        {
            url.ShortUrl = ShortUrl.ShortenUrl(url.LongUrl);
            await _dbContext.AddAsync(url);
            await _dbContext.SaveChangesAsync();

            return url;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var url = await _dbContext.Urls.FirstOrDefaultAsync(x => x.Id == id);
            _dbContext.Urls.Remove(url);

            return await _dbContext.SaveChangesAsync();
        }

        public async Task<Url> FindByIdAsync(int id)
        {
            return await _dbContext.Urls.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Url>> GetAllAsync()
        {
            return await _dbContext.Urls.ToListAsync();
        }

        public async Task<int> UpdateAsync(Url url)
        {
            url.ShortUrl = ShortUrl.ShortenUrl(url.LongUrl);
            _dbContext.Entry(url).State = EntityState.Modified;

            return await _dbContext.SaveChangesAsync();
        }

        public async Task<Url> RedirectAsync(string shortUrl)
        {
            shortUrl = shortUrl.Substring(shortUrl.Length - 8);
            var url = await _dbContext.Urls.FirstOrDefaultAsync(x => x.ShortUrl == shortUrl);
            url.ClickCount++;
            await _dbContext.SaveChangesAsync();

            return url;
        }

    }
}
