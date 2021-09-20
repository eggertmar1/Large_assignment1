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
        private readonly INewsRepository _newsRepository;

        public AuthorService(IAuthorRepository authorRepository, INewsRepository newsRepository) 
        {
            _authorRepository = authorRepository;
            _newsRepository = newsRepository;
        }


        public IEnumerable<AuthorDto> GetAllAuthors() => _authorRepository.AddLinksToDtoAllAuthors(_authorRepository.GetAllAuthors());

        public AuthorDetailDto GetAuthorById(int id) => _authorRepository.AddLinksToDto (_authorRepository.GetAuthorById(id));


        public IEnumerable<NewsItemDto> GetNewsItemsByAuthorId(int authorId) =>_newsRepository.AddLinksToDtoAllNews(_authorRepository.GetNewsItemsByAuthorId(authorId));

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

        public int LinkAuthorNews(int authorid, int newsItemId)
        {
            return _authorRepository.LinkAuthorNews(authorid, newsItemId);
        }

    }
}