using System.Collections.Generic;
using TechnicalRadiation.Models.DTOs;

namespace TechnicalRadiation.Repositories.Interfaces
{
    public interface IAuthorRepository
    {
        public IEnumerable<AuthorDto> GetAllAuthors();
        public AuthorDetailDto GetAuthorById(int id); 
    }

}