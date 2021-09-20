using System.Collections.Generic;
using TechnicalRadiation.Models.DTOs;
using TechnicalRadiation.Models.InputModels;

namespace TechnicalRadiation.Repositories.Interfaces
{
    public interface ICategoriesRepository
    {
        public IEnumerable<CategoryDto> GetAllCategories();
        public CategoryDetailDto GetCategoryById(int id);

        public CategoryDetailDto AddLinksToDto(CategoryDetailDto dto); 
        public IEnumerable<CategoryDto> AddLinksToDtoAllCategories(IEnumerable<CategoryDto> dtos);

        int CreateCategory(CategoryInputModel category);

        void UpdateCategory(int id, CategoryInputModel category);

        void DeleteCategoryById(int id);
        int LinkCategoryNews(int categoryid, int newsItemId);
    }

}