
using Microsoft.EntityFrameworkCore;
using TechnicalRadiation.Models.Entities;
namespace TechnicalRadiation.Repositories.Data
{
    public class NewsDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // manual config of relations -> many to many
            modelBuilder.Entity<CategoryNewsItem>()
                .HasKey(x => new { x.CategoriesId, x.NewsItemsId });
            modelBuilder.Entity<AuthorNewsItem>()
                .HasKey(x => new { x.AuthorsId, x.NewsItemsId });
        }
        public NewsDbContext(DbContextOptions<NewsDbContext> options) : base(options) {}
        public DbSet<Authors> Authors { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<NewsItems> NewsItems { get; set; }
        public DbSet<AuthorNewsItem> AuthorNewsItem { get; set; }
        public DbSet<CategoryNewsItem> CategoryNewsItem { get; set; }

    }
}