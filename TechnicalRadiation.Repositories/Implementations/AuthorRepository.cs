using TechnicalRadiation.Repositories.Interfaces;
using TechnicalRadiation.Repositories.Data;
using TechnicalRadiation.Models.DTOs;
using System.Linq;
using System.Collections.Generic;
using TechnicalRadiation.Models.InputModels;
using Microsoft.EntityFrameworkCore;
using TechnicalRadiation.Models.Entities;
using TechnicalRadiation.Models.Extensions;
using TechnicalRadiation.Models;

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

        public List<NewsItemDto> GetNewsItemsByAuthorId(int authorId)
        {
            var newsItems = _dbContext.AuthorNewsItem
            .Where(a => a.AuthorsId == authorId)
            .Select(ani => new NewsItemDto {
                Id = ani.NewsItems.Id,
                Title = ani.NewsItems.Title,
                ImgSource = ani.NewsItems.ImgSource,
                ShortDescription = ani.NewsItems.ShortDescription
            }).ToList();
            return newsItems;
        }

        public int CreateAuthor(AuthorInputModel author)
        {
            var entity = new Authors
            {
                Name = author.Name,
                ProfileImgSource = author.ProfileImgSource,
                Bio = author.Bio,
                ModifiedBy = "TechnicalRadiationAdmin"

            };
            _dbContext.Authors.Add(entity);
            _dbContext.SaveChanges();
            return entity.Id;
        }

        public void UpdateAuthor(int id, AuthorInputModel author)
        {
            var entity = _dbContext.Authors.FirstOrDefault(a => a.Id == id);
            if (entity == null) { return; }

            entity.Name = author.Name;
            entity.ProfileImgSource = author.ProfileImgSource;
            entity.Bio = author.Bio;

            _dbContext.SaveChanges();
        }

        public void DeleteAuthorById(int id)
        {
            var entity = _dbContext.Authors.FirstOrDefault(r => r.Id == id);
            if (entity == null) { return; }

            // Delete the entity
            _dbContext.Authors.Remove(entity);
            _dbContext.SaveChanges();
        }
        public AuthorDetailDto AddLinksToDto(AuthorDetailDto dto) 
        {
            dto.Links.AddReference("self", new {href = $"api/authors/{dto.Id}"});
            dto.Links.AddReference("edit", new {href = $"api/authors/{dto.Id}"});
            dto.Links.AddReference("delete", new {href = $"api/authors/{dto.Id}"});
            dto.Links.AddReference("newsItems", new {href = $"api/authors/{dto.Id}/newsItems"});
            dto.Links.AddListReference(
                "newsItemsDetailed",
                _dbContext.AuthorNewsItem  
                    .Where(i => i.AuthorsId == dto.Id)
                    .Select(i => $"api/{i.NewsItemsId}")
            );
            return dto;
        }
        public IEnumerable<AuthorDto> AddLinksToDtoAllAuthors(IEnumerable<AuthorDto> dtos) 
        {
            foreach(AuthorDto dto in dtos)
            {
                dto.Links.AddReference("self", new {href = $"api/authors/{dto.Id}"});
                dto.Links.AddReference("edit", new {href = $"api/authors/{dto.Id}"});
                dto.Links.AddReference("delete", new {href = $"api/authors/{dto.Id}"});
                dto.Links.AddReference("newsItems", new {href = $"api/authors/{dto.Id}/newsItems"});
                dto.Links.AddListReference(
                    "newsItemsDetailed",
                    _dbContext.AuthorNewsItem  
                        .Where(i => i.AuthorsId == dto.Id)
                        .Select(i => $"api/{i.NewsItemsId}")
                );
            }
            return dtos;
        }
    }
}