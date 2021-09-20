using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Services.Implementations;
using TechnicalRadiation.Services.Interfaces;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Models.Attributes;

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

        [HttpGet]
        [Route("{authorId:int}/newsItems", Name = "GetNewsItemsByAuthorId")]
        public IActionResult GetNewsItemsByAuthorId(int authorId) => Ok(_authorsService.GetNewsItemsByAuthorId(authorId));

        [HttpPost]
        [Route("")]
        [Authentication]
        public IActionResult CreateAuthor([FromBody] AuthorInputModel author)
        {
            int newId = _authorsService.CreateAuthor(author);
            return Ok(newId);
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authentication]
        public IActionResult UpdateAuthor(int id, [FromBody] AuthorInputModel author)
        {
            _authorsService.UpdateAuthor(id, author);
            return NoContent();
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authentication]
        public IActionResult DeleteAuthorById(int id)
        {
            _authorsService.DeleteAuthorById(id);
            return NoContent();
        }
    }
}