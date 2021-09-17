using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Services.Implementations;
using TechnicalRadiation.Services.Interfaces;

namespace TechnicalRadiation.WebApi.Controllers 
{
    [Route("api/newsitems")]
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

    }
}