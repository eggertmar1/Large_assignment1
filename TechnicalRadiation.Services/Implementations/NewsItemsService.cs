using TechnicalRadiation.Services.Interfaces;
using TechnicalRadiation.Repositories.Interfaces;
using TechnicalRadiation.Models.DTOs;
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

        public IEnumerable<NewsItemDto> GetAllNewsItems() 
        {
            return _newsRepository.GetAllNewsItems();
        }

    }  
}