using TechnicalRadiation.Models.DTOs;
using System.Linq;
using System.Collections.Generic;
using TechnicalRadiation.Models.InputModels;

namespace TechnicalRadiation.Services.Interfaces
{
    public interface IAuthorService  
    {
        public IEnumerable<AuthorDto> GetAllAuthors();
        public AuthorDetailDto GetAuthorById(int id);
        public List<NewsItemDto> GetNewsItemsByAuthorId(int authorId);


        int CreateAuthor(AuthorInputModel author);

        void UpdateAuthor(int id, AuthorInputModel author);

        void DeleteAuthorById(int id);

        int LinkAuthorNews(int authorid, int newsItemId);
    }
}