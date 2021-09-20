using System.Collections.Generic;
using TechnicalRadiation.Models.DTOs;
using TechnicalRadiation.Models.InputModels;
using TechnicalRadiation.Repositories.Implementations;

namespace TechnicalRadiation.Repositories.Interfaces
{
    public interface INewsRepository
    {
        public IEnumerable<NewsItemDto> GetAllNewsItems();
        public NewsItemDetailDto GetNewsItemById(int id);
        public NewsItemDetailDto AddLinksToDto(NewsItemDetailDto dto); 
        public IEnumerable<NewsItemDto> AddLinksToDtoAllNews(IEnumerable<NewsItemDto> dtos);
        int CreateNewsItem(NewsItemInputModel item);

        void UpdateNewsItem(int id, NewsItemInputModel item);
        void DeleteNewsItemById(int id);
    }
}