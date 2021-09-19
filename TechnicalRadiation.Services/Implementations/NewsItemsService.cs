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

        public IEnumerable<NewsItemDto> GetAllNewsItems() => _newsRepository.GetAllNewsItems();
    
        public NewsItemDetailDto GetNewsItemById(int id) => _newsRepository.GetNewsItemById(id);

        public int CreateNewsItem(NewsItemInputModel item)
        {
            return _newsRepository.CreateNewsItem(item);
        }

    }  
}