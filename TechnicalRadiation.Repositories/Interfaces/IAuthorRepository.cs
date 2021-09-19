using System.Collections.Generic;
using TechnicalRadiation.Models.DTOs;
using TechnicalRadiation.Models.InputModels;

namespace TechnicalRadiation.Repositories.Interfaces
{
    public interface IAuthorRepository
    {
        public IEnumerable<AuthorDto> GetAllAuthors();
        public AuthorDetailDto GetAuthorById(int id); 
        public List<NewsItemDto> GetNewsItemsByAuthorId(int id);

        int CreateAuthor(AuthorInputModel author);

        void UpdateAuthor(int id, AuthorInputModel author);
        void DeleteAuthorById(int id);
    }
}
