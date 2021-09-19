using System.Collections.Generic;
using TechnicalRadiation.Repositories.Interfaces;
using TechnicalRadiation.Repositories.Data;
using TechnicalRadiation.Models.DTOs;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Models.Entities;
using System.Linq;
using System;
//using AutoMapper;

namespace TechnicalRadiation.Repositories.Implementations
{
    public class NewsRepository : INewsRepository
    {
        private readonly NewsDbContext _dbContext;


        public NewsRepository(NewsDbContext dbContext) 
        {
            _dbContext = dbContext;
        } 

        public IEnumerable<NewsItemDto> GetAllNewsItems() 
        {
            var newsItems = _dbContext.NewsItems.Select(n => new NewsItemDto 
            {
                Id = n.Id,
                Title = n.Title,
                ImgSource = n.ImgSource,
                ShortDescription = n.ShortDescription
            }).ToList();
            return newsItems;
        }

        public NewsItemDetailDto GetNewsItemById(int id) 
        {
            var newsItem = _dbContext.NewsItems.Where(n => n.Id == id).Select(n => new NewsItemDetailDto 
            {
                Id = n.Id,
                Title = n.Title,
                ImgSource = n.ImgSource,
                ShortDescription = n.ShortDescription,
                LongDescription = n.LongDescription,
                PublishDate = n.PublishDate
            }).ToList()[0];
            return newsItem;
        }

        public int CreateNewsItem(NewsItemInputModel item)
        {
            var entity = new NewsItems
            {
                Title = item.Title,
                ImgSource = item.ImgSource,
                ShortDescription = item.ShortDescription,
                LongDescription = item.LongDescription,
                PublishDate = DateTime.Now
            };
            _dbContext.NewsItems.Add(entity);
            _dbContext.SaveChanges();
            return entity.Id;
        }

        public void UpdateNewsItem(int id, NewsItemInputModel item)
        {
            var entity = _dbContext.NewsItems.FirstOrDefault(a => a.Id == id);
            if (entity == null) { return; }

            entity.Title = item.Title;
            entity.ImgSource = item.ImgSource;
            entity.ShortDescription = item.ShortDescription;
            entity.LongDescription = item.LongDescription;

            _dbContext.SaveChanges();
        }

        public void DeleteNewsItemById(int id)
        {
            var entity = _dbContext.NewsItems.FirstOrDefault(r => r.Id == id);
            if (entity == null) { return; }

            // Delete the entity
            _dbContext.NewsItems.Remove(entity);
            _dbContext.SaveChanges();
        }
        private AuthorDetailDto AddLinksToDto(AuthorDetailDto dto) 
        {
            dto.Links.AddReference("self", new {href = $"api/authors/{dto.Id}"});
            dto.Links.AddReference("edit", new {href = $"api/authors/{dto.Id}"});
            dto.Links.AddReference("delete", new {href = $"api/authors/{dto.Id}"});
            dto.Links.AddReference("newsItems", new {href = $"api/authors/{dto.Id}/newsItems"});
            dto.Links.AddListReference(
                "newsItemsDetailed",
                _dbContext.AuthorNewsItem  
                    .where(i => i.AuthorId == dto.Id)
                    .Select(i => $"api/{i.NewsItemId}")
            );
            return dto;

        }
    }
}
