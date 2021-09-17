
using Microsoft.EntityFrameworkCore;
using TechnicalRadiation.Models.Entities;
namespace TechnicalRadiation.Repositories.Data
{
    public class NewsDbContext : DbContext
    {
        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     // manual config of relations -> many to many
        // }
        public NewsDbContext(DbContextOptions<NewsDbContext> options) : base(options) {}
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set;}
        public DbSet<NewsItem> NewsItems { get; set;}
        public DbSet<NewsItemAuthors> AuthorNewsItem { get; set; }
        public DbSet<NewsItemCategories> CategoryNewsItem { get; set; }

    }
}