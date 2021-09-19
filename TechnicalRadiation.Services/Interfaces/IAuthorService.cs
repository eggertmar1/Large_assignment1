using TechnicalRadiation.Models.DTOs;
using System.Linq;
using System.Collections.Generic;

namespace TechnicalRadiation.Services.Interfaces
{
    public interface IAuthorService  
    {
        public IEnumerable<AuthorDto> GetAllAuthors();
        public AuthorDetailDto GetAuthorById(int id);
        public List<NewsItemDto> GetNewsItemsByAuthorId(int authorId);
    }
}