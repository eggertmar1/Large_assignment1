using System.Collections.Generic;
using TechnicalRadiation.Repositories.Interfaces;
using TechnicalRadiation.Repositories.Data;
using TechnicalRadiation.Models.DTOs;
using System.Linq;

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
    }
}
