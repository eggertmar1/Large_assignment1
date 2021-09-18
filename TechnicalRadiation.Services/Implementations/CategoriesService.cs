using TechnicalRadiation.Services.Interfaces;
using TechnicalRadiation.Repositories.Interfaces;
using TechnicalRadiation.Models.DTOs;
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

        public IEnumerable<CategoryDto> GetAllCategories() => _categoriesRepository.GetAllCategories();
        public CategoryDetailDto GetCategoryById(int id) => _categoriesRepository.GetCategoryById(id);

    }
}