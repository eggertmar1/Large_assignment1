using TechnicalRadiation.Repositories.Interfaces;
using TechnicalRadiation.Repositories.Data;
using TechnicalRadiation.Models.DTOs;
using System.Linq;
using System.Collections.Generic;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Models.Entities;
using System.Globalization;

namespace TechnicalRadiation.Repositories.Implementations 
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly NewsDbContext _dbContext;

        public CategoriesRepository(NewsDbContext dbContext) 
        {
            _dbContext = dbContext;
        } 

        public IEnumerable<CategoryDto> GetAllCategories() 
        {
            var categories = _dbContext.Categories.Select(c => new CategoryDto 
            {
                Id = c.Id,
                Name = c.Name,
                Slug = c.Slug
            }).ToList();
            return categories;
        }

        public CategoryDetailDto GetCategoryById(int id) 
        {
            var category = _dbContext.Categories.Where(c => c.Id == id).Select(c => new CategoryDetailDto
            {
                Id = c.Id,
                Name = c.Name,
                Slug = c.Slug,
                NumberOfNewsItems = 404//_dbContext.NewsItems.Join(n => n.Id == _dbContext.CategoryNewsItem.NewsItemsId)
            }).ToList()[0];
            return category;
        }

        public int CreateCategory(CategoryInputModel category)
        {
            string new_slug = category.Name;
            new_slug = CultureInfo.CurrentCulture.TextInfo.ToLower(new_slug);
            new_slug = new_slug.Replace(" ", "-");
            var entity = new Categories
            {
                Name = category.Name,
                Slug = new_slug
            };
            _dbContext.Categories.Add(entity);
            _dbContext.SaveChanges();
            return entity.Id;
        }

        public void UpdateCategory(int id, CategoryInputModel category)
        {
            var entity = _dbContext.Categories.FirstOrDefault(a => a.Id == id);
            if (entity == null) { return; }

            entity.Name = category.Name;

            string new_slug = category.Name;
            new_slug = CultureInfo.CurrentCulture.TextInfo.ToLower(new_slug);
            new_slug = new_slug.Replace(" ", "-");
            entity.Slug = new_slug;

            _dbContext.SaveChanges();
        }

        public void DeleteCategoryById(int id)
        {
            var entity = _dbContext.Categories.FirstOrDefault(r => r.Id == id);
            if (entity == null) { return; }

            // Delete the entity
            _dbContext.Categories.Remove(entity);
            _dbContext.SaveChanges();
        }
    }
}