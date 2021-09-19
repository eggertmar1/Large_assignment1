using System.Collections.Generic;
using TechnicalRadiation.Models.DTOs;
using TechnicalRadiation.Models.InputModels;

namespace TechnicalRadiation.Repositories.Interfaces
{
    public interface ICategoriesRepository
    {
        public IEnumerable<CategoryDto> GetAllCategories();
        public CategoryDetailDto GetCategoryById(int id);

        int CreateCategory(CategoryInputModel category);

        void UpdateCategory(int id, CategoryInputModel category);
        void DeleteCategoryById(int id);
    }

}