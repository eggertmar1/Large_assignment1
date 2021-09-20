using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Services.Implementations;
using TechnicalRadiation.Services.Interfaces;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Models.Attributes;
using System.Net;
using TechnicalRadiation.WebApi.Extensions;

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
        //[ProducesResponseType(StatusCodes.Status201Created)]
        [Authentication]
        public IActionResult CreateAuthor([FromBody] AuthorInputModel author)
        {
            if (!ModelState.IsValid)
            {
                throw new ModelFormatException(ModelState.RetrieveErrorString());
            }
            int newId = _authorsService.CreateAuthor(author);
            return Ok(_authorsService.GetAuthorById(newId));
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authentication]
        public IActionResult UpdateAuthor(int id, [FromBody] AuthorInputModel author)
        {
            if (!ModelState.IsValid)
            {
                throw new ModelFormatException(ModelState.RetrieveErrorString());
            }
            _authorsService.UpdateAuthor(id, author);
            return Ok(_authorsService.GetAuthorById(id));
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authentication]
        public IActionResult DeleteAuthorById(int id)
        {
            _authorsService.DeleteAuthorById(id);
            return Ok(_authorsService.GetAuthorById(id));
        }

        [HttpPost]
        [Route("{authorid:int}/newsItems/{newsItemId:int}")]
        [Authentication]
        public IActionResult LinkAuthorNews(int authorid, int newsItemId)
        {
            _authorsService.LinkAuthorNews(authorid, newsItemId);
            return Ok(_authorsService.GetAuthorById(authorid));
        }
    }
}