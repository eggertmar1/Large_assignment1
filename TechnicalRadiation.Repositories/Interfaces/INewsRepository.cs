using System.Collections.Generic;
using TechnicalRadiation.Models.DTOs;
using TechnicalRadiation.Models.InputModels;

namespace TechnicalRadiation.Repositories.Interfaces
{
    public interface INewsRepository
    {
        public IEnumerable<NewsItemDto> GetAllNewsItems();
        public NewsItemDetailDto GetNewsItemById(int id);
        int CreateNewsItem(NewsItemInputModel item);
    }
}