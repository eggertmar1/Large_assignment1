using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Services.Implementations;
using TechnicalRadiation.Services.Interfaces;

namespace TechnicalRadiation.WebApi.Controllers 
{
    [Route("api")]
    public class NewsItemsController : Controller
    {
        private readonly INewsItemsService _newsItemService;

        public NewsItemsController(INewsItemsService newsItemService) 
        {
            _newsItemService = newsItemService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAllNewsItems() => Ok(_newsItemService.GetAllNewsItems());

        [HttpGet]
        [Route("{id:int}", Name = "GetNewsItemById")]
        public IActionResult GetNewsItemById(int id) => Ok(_newsItemService.GetNewsItemById(id));
        
    }
}