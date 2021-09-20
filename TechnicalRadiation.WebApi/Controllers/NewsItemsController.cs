using Microsoft.AspNetCore.Mvc;
using TechnicalRadiation.Services.Implementations;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Services.Interfaces;
using TechnicalRadiation.Models;
using TechnicalRadiation.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using TechnicalRadiation.Models.Attributes;

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
        public IActionResult GetAllNewsItems([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 25)
        {
            var envelope = new Envelope<NewsItemDto>(pageNumber,pageSize, _newsItemService.GetAllNewsItems());
            return Ok(envelope.Items);
        } 

        [HttpGet]
        [Route("{id:int}", Name = "GetNewsItemById")]
        public IActionResult GetNewsItemById(int id) => Ok(_newsItemService.GetNewsItemById(id));


        [HttpPost]
        [Route("")]
        [Authentication]
        public IActionResult CreateNewsItem([FromBody] NewsItemInputModel item)
        {
            Console.WriteLine(Request.Headers["Authorization"]);
            int newId = _newsItemService.CreateNewsItem(item);
            return Ok(newId);
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authentication]
        public IActionResult UpdateNewsItem(int id, [FromBody] NewsItemInputModel item)
        {
            _newsItemService.UpdateNewsItem(id, item);
            return NoContent();
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authentication]
        public IActionResult DeleteNewsItemById(int id)
        {
            _newsItemService.DeleteNewsItemById(id);
            return NoContent();
        }
        
    }
}