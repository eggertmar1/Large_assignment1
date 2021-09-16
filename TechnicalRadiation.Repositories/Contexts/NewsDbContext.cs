
using Microsoft.EntityFrameworkCore;

namespace TechnicalRadiation.Repository.Contexts
{
    public class NewsDbContext : DbContext
    {
        public NewsDbContext(DbContextOptions<NewsDbContext> options) : base(options) {}
    }
}