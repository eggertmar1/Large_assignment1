using System.Collections.Generic;
using TechnicalRadiation.Models.DTOs;

namespace TechnicalRadiation.Repositories.Interfaces
{
    public interface INewsRepository
    {
        public IEnumerable<NewsItemDto> GetAllNewsItems();
        public NewsItemDetailDto GetNewsItemById(int id);
    }
}