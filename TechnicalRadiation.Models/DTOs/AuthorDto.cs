using System.Collections.Generic;
using TechnicalRadiation.Models.Entities;

namespace TechnicalRadiation.Models.DTOs
{
    public class AuthorDto : HyperMediaModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}