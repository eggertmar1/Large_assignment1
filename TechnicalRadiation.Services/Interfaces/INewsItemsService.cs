using TechnicalRadiation.Models.DTOs;
using System.Linq;
using System.Collections.Generic;

namespace TechnicalRadiation.Services.Interfaces
{
    public interface INewsItemsService  
    {
        public IEnumerable<NewsItemDto> GetAllNewsItems();
    }
}