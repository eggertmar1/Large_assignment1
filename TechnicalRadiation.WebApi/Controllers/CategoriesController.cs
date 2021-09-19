using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Services.Implementations;
using TechnicalRadiation.Services.Interfaces;
using TechnicalRadiation.Models.InputModels;

namespace TechnicalRadiation.WebApi.Controllers 
{
    [Route("api/categories")]
    public class CategoriesController : Controller
    {
        private readonly ICategoriesService _categoriesService;

        public CategoriesController(ICategoriesService categoriesService) 
        {
            _categoriesService = categoriesService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAllCategories() => Ok(_categoriesService.GetAllCategories());

        [HttpGet]
        [Route("{id:int}", Name = "GetCategoryById")]
        public IActionResult GetCategoryById(int id) => Ok(_categoriesService.GetCategoryById(id));

        [HttpPost]
        [Route("")]
        public IActionResult CreateCategory([FromBody] CategoryInputModel category)
        {
            int newId = _categoriesService.CreateCategory(category);
            return Ok(newId);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult UpdateCategory(int id, [FromBody] CategoryInputModel category)
        {
            _categoriesService.UpdateCategory(id, category);
            return NoContent();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteCategoryById(int id)
        {
            _categoriesService.DeleteCategoryById(id);
            return NoContent();
        }

    }
}