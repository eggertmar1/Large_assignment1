using System.Collections.Generic;
using TechnicalRadiation.Models.DTOs;
<<<<<<< HEAD
using TechnicalRadiation.Models.InputModels;
=======
using TechnicalRadiation.Repositories.Implementations;
>>>>>>> d765918bf5a8c74fc2c597485707b27d4c38b514

namespace TechnicalRadiation.Repositories.Interfaces
{
    public interface IAuthorRepository
    {
        public IEnumerable<AuthorDto> GetAllAuthors();
        public AuthorDetailDto GetAuthorById(int id); 
        public List<NewsItemDto> GetNewsItemsByAuthorId(int id);
<<<<<<< HEAD

        int CreateAuthor(AuthorInputModel author);

        void UpdateAuthor(int id, AuthorInputModel author);
        void DeleteAuthorById(int id);
    }
}
=======
        public AuthorDetailDto AddLinksToDto(AuthorDetailDto dto); 
        public IEnumerable<AuthorDto> AddLinksToDtoAllAuthors(IEnumerable<AuthorDto> dtos);
    }
}
>>>>>>> d765918bf5a8c74fc2c597485707b27d4c38b514
