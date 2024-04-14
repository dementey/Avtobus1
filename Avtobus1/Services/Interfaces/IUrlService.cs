using Avtobus1.Models;

namespace Avtobus1.Services.Interfaces
{
    public interface IUrlService
    {
        Task<List<Url>> GetAllAsync();
        Task<int> DeleteAsync(int id);
        Task<Url> AddAsync(Url url);
        Task<int> UpdateAsync(Url url);
        Task<Url> FindByIdAsync(int id);
        Task<Url> RedirectAsync(string shortUrl);
    }
}
