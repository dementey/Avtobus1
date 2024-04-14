using Microsoft.EntityFrameworkCore;
using Avtobus1.Models;

namespace Avtobus1.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Url> Urls { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
           : base(options)
        { }
    }
}
