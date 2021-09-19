using System.Collections.Generic;
using TechnicalRadiation.Models.DTOs;
using TechnicalRadiation.Repositories.Implementations;

namespace TechnicalRadiation.Repositories.Interfaces
{
    public interface IAuthorRepository
    {
        public IEnumerable<AuthorDto> GetAllAuthors();
        public AuthorDetailDto GetAuthorById(int id); 
        public List<NewsItemDto> GetNewsItemsByAuthorId(int id);
        public AuthorDetailDto AddLinksToDto(AuthorDetailDto dto); 
        public IEnumerable<AuthorDto> AddLinksToDtoAllAuthors(IEnumerable<AuthorDto> dtos);
    }
}