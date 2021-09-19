using TechnicalRadiation.Services.Interfaces;
using TechnicalRadiation.Repositories.Interfaces;
using TechnicalRadiation.Models.DTOs;
using System.Collections.Generic;

namespace TechnicalRadiation.Services.Implementations
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository) 
        {
            _authorRepository = authorRepository;
        }

        public IEnumerable<AuthorDto> GetAllAuthors() => _authorRepository.GetAllAuthors();

        public AuthorDetailDto GetAuthorById(int id) => _authorRepository.GetAuthorById(id);

        public List<NewsItemDto> GetNewsItemsByAuthorId(int authorId) => _authorRepository.GetNewsItemsByAuthorId(authorId);

    }
}