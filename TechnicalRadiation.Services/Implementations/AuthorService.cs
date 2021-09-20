using TechnicalRadiation.Services.Interfaces;
using TechnicalRadiation.Repositories.Interfaces;
using TechnicalRadiation.Models.DTOs;
using System.Collections.Generic;
using TechnicalRadiation.Models.InputModels;

namespace TechnicalRadiation.Services.Implementations
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository) 
        {
            _authorRepository = authorRepository;
        }

        public IEnumerable<AuthorDto> GetAllAuthors() => _authorRepository.AddLinksToDtoAllAuthors(_authorRepository.GetAllAuthors());

        public AuthorDetailDto GetAuthorById(int id) => _authorRepository.AddLinksToDto (_authorRepository.GetAuthorById(id));


        public List<NewsItemDto> GetNewsItemsByAuthorId(int authorId) => _authorRepository.GetNewsItemsByAuthorId(authorId);

        public int CreateAuthor(AuthorInputModel author)
        {
            return _authorRepository.CreateAuthor(author);
        }

        public void UpdateAuthor(int id, AuthorInputModel author)
        {
            _authorRepository.UpdateAuthor(id, author);
        }

        public void DeleteAuthorById(int id)
        {
            _authorRepository.DeleteAuthorById(id);
        }

    }
}