using TechnicalRadiation.Services.Interfaces;
using TechnicalRadiation.Repositories.Interfaces;
using TechnicalRadiation.Models.DTOs;
using TechnicalRadiation.Models.InputModels;
using System.Collections.Generic;

namespace TechnicalRadiation.Services.Implementations
{
    public class NewsItemsService : INewsItemsService 
    {
        private readonly INewsRepository _newsRepository;

        public NewsItemsService(INewsRepository newsRepository) 
        {
            _newsRepository = newsRepository;
        }

        public IEnumerable<NewsItemDto> GetAllNewsItems() =>_newsRepository.AddLinksToDtoAllNews(_newsRepository.GetAllNewsItems());
    
        public NewsItemDetailDto GetNewsItemById(int id) =>_newsRepository.AddLinksToDto(_newsRepository.GetNewsItemById(id));

        public int CreateNewsItem(NewsItemInputModel item)
        {
            return _newsRepository.CreateNewsItem(item);
        }

        public void UpdateNewsItem(int id, NewsItemInputModel item)
        {
            _newsRepository.UpdateNewsItem(id, item);
        }

        public void DeleteNewsItemById(int id)
        {
            _newsRepository.DeleteNewsItemById(id);
        }

    }  
}