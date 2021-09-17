using System.ComponentModel.DataAnnotations;

namespace TechnicalRadiation.Models.InputModels
{
    public class CategoryInputModel 
    {
        [Required]
        public string Name { get; set; }
    }
}