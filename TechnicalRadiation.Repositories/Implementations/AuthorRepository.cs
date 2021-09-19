using TechnicalRadiation.Repositories.Interfaces;
using TechnicalRadiation.Repositories.Data;
using TechnicalRadiation.Models.DTOs;
using System.Linq;
using System.Collections.Generic;
using TechnicalRadiation.Models.InputModels;

namespace TechnicalRadiation.Repositories.Implementations 
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly NewsDbContext _dbContext;

        public AuthorRepository(NewsDbContext dbContext) 
        {
            _dbContext = dbContext;
        } 

        public IEnumerable<AuthorDto> GetAllAuthors() 
        {
            var authors = _dbContext.Authors.Select(c => new AuthorDto 
            {
                Id = c.Id,
                Name = c.Name
            }).ToList();
            return authors;
        }

        public AuthorDetailDto GetAuthorById(int id) 
        {
            var author = _dbContext.Authors.Where(c => c.Id == id).Select(c => new AuthorDetailDto
            {
                Id = c.Id,
                Name = c.Name,
                Bio = c.Bio,
                ProfileImgSource = c.ProfileImgSource
            }).ToList()[0];
            return author;
        }
    }
}