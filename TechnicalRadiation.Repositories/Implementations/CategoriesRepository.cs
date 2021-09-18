using TechnicalRadiation.Repositories.Interfaces;
using TechnicalRadiation.Repositories.Data;
using TechnicalRadiation.Models.DTOs;
using System.Linq;
using System.Collections.Generic;

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
    }
}