using System.Collections.Generic;
using TechnicalRadiation.Models.DTOs;

namespace TechnicalRadiation.Repositories.Interfaces
{
    public interface ICategoriesRepository
    {
        public IEnumerable<CategoryDto> GetAllCategories();
        public CategoryDetailDto GetCategoryById(int id); 
    }

}