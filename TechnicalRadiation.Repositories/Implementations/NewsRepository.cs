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
            //using var db = new NewsDbContext();
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
            return 1;

            /*var items = _dbContext.GetAllNewsItems();
            var newsItems = _newsRepository.GetAllNewsItems();
            var entity = Mapper.Map<NewsItems>(item);
            newsItems.Add(entity);
            return 1;
            /*
            entity.Id = 2;
            entity.Title = item.title;
            entity.ImgSource = item.imgSource;
            entity.ShortDescription = item.shortDescription;
            entity.LongDescription = item.longDescription;
            entity.PublishDate = DateTime.Now;
            

            _dbContext.NewsItems.Add(entity);
            //_dbContext.NewsItems.Add(entity);
            //items.SaveChanges();
            return 1;
            */
        }

    }
}
