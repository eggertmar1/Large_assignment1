using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Services.Implementations;
using TechnicalRadiation.Services.Interfaces;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Models.Attributes;
using TechnicalRadiation.WebApi.Extensions;

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
        public IActionResult GetCategoryById(int id) 
        {
            return Ok(_categoriesService.GetCategoryById(id));
        }

        [HttpPost]
        [Route("")]
        [Authentication]
        public IActionResult CreateCategory([FromBody] CategoryInputModel category)
        {
            if (!ModelState.IsValid)
            {
                throw new ModelFormatException(ModelState.RetrieveErrorString());
            }
            int newId = _categoriesService.CreateCategory(category);
            return Ok(_categoriesService.GetCategoryById(newId));
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authentication]
        public IActionResult UpdateCategory(int id, [FromBody] CategoryInputModel category)
        {
            if (!ModelState.IsValid)
            {
                throw new ModelFormatException(ModelState.RetrieveErrorString());
            }
            _categoriesService.UpdateCategory(id, category);
            return Ok(_categoriesService.GetCategoryById(id));
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authentication]
        public IActionResult DeleteCategoryById(int id)
        {
            _categoriesService.DeleteCategoryById(id);
            return Ok(_categoriesService.GetCategoryById(id));
        }


        [HttpPost]
        [Route("{categoryid:int}/newsItems/{newsItemId:int}")]
        [Authentication]
        public IActionResult LinkCategoryNews(int categoryid, int newsItemId)
        {
            _categoriesService.LinkCategoryNews(categoryid, newsItemId);
            return Ok(_categoriesService.GetCategoryById(categoryid));
        }

    }
}