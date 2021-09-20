using TechnicalRadiation.Models.DTOs;
using System.Linq;
using System.Collections.Generic;
using TechnicalRadiation.Models.InputModels;
<<<<<<< HEAD
=======

>>>>>>> d765918bf5a8c74fc2c597485707b27d4c38b514

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