using TechnicalRadiation.Models.DTOs;
using System.Linq;
using System.Collections.Generic;

namespace TechnicalRadiation.Services.Interfaces
{
    public interface ICategoriesService  
    {
        public IEnumerable<CategoryDto> GetAllCategories();
        public CategoryDetailDto GetCategoryById(int id);
    }
}