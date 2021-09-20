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
using TechnicalRadiation.WebApi.Extensions;

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
            if (!ModelState.IsValid)
            {
                throw new ModelFormatException(ModelState.RetrieveErrorString());
            }
            int newId = _newsItemService.CreateNewsItem(item);
            return CreatedAtAction("GetNewsItemById", new {id = newId}, _newsItemService.GetNewsItemById(newId));
        }

        [HttpPut]
        [Route("{id:int}")]
        [Authentication]
        public IActionResult UpdateNewsItem(int id, [FromBody] NewsItemInputModel item)
        {
            if (!ModelState.IsValid)
            {
                throw new ModelFormatException(ModelState.RetrieveErrorString());
            }
            _newsItemService.UpdateNewsItem(id, item);
            return Ok(_newsItemService.GetNewsItemById(id));
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authentication]
        public IActionResult DeleteNewsItemById(int id)
        {
            _newsItemService.DeleteNewsItemById(id);
            return Ok(_newsItemService.GetNewsItemById(id));
        }
        
    }
}