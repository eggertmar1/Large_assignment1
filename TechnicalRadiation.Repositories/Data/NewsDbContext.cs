
using Microsoft.EntityFrameworkCore;

namespace TechnicalRadiation.Repositories.Data
{
    public class NewsDbContext : DbContext
    {
        public NewsDbContext(DbContextOptions<NewsDbContext> options) : base(options) {}
    }
}