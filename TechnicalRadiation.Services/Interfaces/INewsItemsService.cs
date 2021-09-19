using TechnicalRadiation.Models.DTOs;
using System.Linq;
using System.Collections.Generic;
using TechnicalRadiation.Models.InputModels;

namespace TechnicalRadiation.Services.Interfaces
{
    public interface INewsItemsService  
    {
        public IEnumerable<NewsItemDto> GetAllNewsItems();
        public NewsItemDetailDto GetNewsItemById(int id);
        int CreateNewsItem(NewsItemInputModel item);

        void UpdateNewsItem(int id, NewsItemInputModel item);

        void DeleteNewsItemById(int id);
    }
}