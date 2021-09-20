using TechnicalRadiation.Models.DTOs;
using System.Linq;
using System.Collections.Generic;
using TechnicalRadiation.Models.InputModels;


namespace TechnicalRadiation.Services.Interfaces
{
    public interface ICategoriesService  
    {
        public IEnumerable<CategoryDto> GetAllCategories();
        public CategoryDetailDto GetCategoryById(int id);
      

        int CreateCategory(CategoryInputModel category);

        void UpdateCategory(int id, CategoryInputModel category);

        void DeleteCategoryById(int id);


    }
}