using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Services.Implementations;
using TechnicalRadiation.Services.Interfaces;

namespace TechnicalRadiation.WebApi.Controllers 
{
    [Route("api/authors")]
    public class AuthorController : Controller
    {
        private readonly IAuthorService _authorsService;

        public AuthorController(IAuthorService authorsService) 
        {
            _authorsService = authorsService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetAllAuthors() => Ok(_authorsService.GetAllAuthors());

        [HttpGet]
        [Route("{id:int}", Name = "GetAuthorById")]
        public IActionResult GetAuthorById(int id) => Ok(_authorsService.GetAuthorById(id));
    }
}