using TechnicalRadiation.Repositories.Interfaces;
using TechnicalRadiation.Repositories.Data;
using TechnicalRadiation.Models.DTOs;
using System.Linq;
using System.Collections.Generic;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Models.Entities;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using TechnicalRadiation.Models.Extensions;

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
                NumberOfNewsItems = _dbContext.CategoryNewsItem
                                    .Where(c => c.CategoriesId == id)
                                    .Select(cni => new NewsItems {
                                        Id = cni.NewsItems.Id,
                                        Title = cni.NewsItems.Title,
                                        ImgSource = cni.NewsItems.ImgSource,
                                        ShortDescription = cni.NewsItems.ShortDescription,
                                        LongDescription = cni.NewsItems.LongDescription,
                                        PublishDate = cni.NewsItems.PublishDate,
                                        ModifiedBy = cni.NewsItems.ModifiedBy,
                                        CreatedDate = cni.NewsItems.CreatedDate,
                                        ModifiedDate = cni.NewsItems.ModifiedDate
                                    }).ToList().Count             
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
        public CategoryDetailDto AddLinksToDto(CategoryDetailDto dto) 
        {
            dto.Links.AddReference("self", new {href = $"api/categories/{dto.Id}"});
            dto.Links.AddReference("edit", new {href = $"api/categories/{dto.Id}"});
            dto.Links.AddReference("delete", new {href = $"api/categories/{dto.Id}"});
            return dto;
        }
        public IEnumerable<CategoryDto> AddLinksToDtoAllCategories(IEnumerable<CategoryDto> dtos) 
        {
            foreach(CategoryDto dto in dtos)
            {
                dto.Links.AddReference("self", new {href = $"api/categories/{dto.Id}"});
                dto.Links.AddReference("edit", new {href = $"api/categories/{dto.Id}"});
                dto.Links.AddReference("delete", new {href = $"api/categories/{dto.Id}"});
            }
            return dtos;
        }

    }
}