using TechnicalRadiation.Services.Interfaces;
using TechnicalRadiation.Repositories.Interfaces;
using TechnicalRadiation.Models.DTOs;
using TechnicalRadiation.Models.InputModels;
using System.Collections.Generic;

namespace TechnicalRadiation.Services.Implementations
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoriesRepository _categoriesRepository;

        public CategoriesService(ICategoriesRepository categoriesRepository) 
        {
            _categoriesRepository = categoriesRepository;
        }

        public IEnumerable<CategoryDto> GetAllCategories() =>_categoriesRepository.AddLinksToDtoAllCategories(_categoriesRepository.GetAllCategories());
        public CategoryDetailDto GetCategoryById(int id) =>_categoriesRepository.AddLinksToDto(_categoriesRepository.GetCategoryById(id));


        public int CreateCategory(CategoryInputModel category)
        {
            return _categoriesRepository.CreateCategory(category);
        }

        public void UpdateCategory(int id, CategoryInputModel category)
        {
            _categoriesRepository.UpdateCategory(id, category);
        }

        public void DeleteCategoryById(int id)
        {
            _categoriesRepository.DeleteCategoryById(id);
        }

        public int LinkCategoryNews(int categoryid, int newsItemId)
        {
            return _categoriesRepository.LinkCategoryNews(categoryid, newsItemId);
        }

    }
}