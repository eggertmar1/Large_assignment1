using System;
using System.ComponentModel.DataAnnotations;

namespace TechnicalRadiation.Models.InputModels
{
    public class NewsItemInputModel
    {
        [Required]
        public string Title { get; set; }

        //TODO implement a custom valid url attribute
        public string ImgSource { get; set; }

        [Required]
        [MaxLength(50)]
        public string ShortDescription { get; set; }

        [MinLength(50)]
        [MaxLength(255)]
        public string LongDescription { get; set; }

        [Required]
        public DateTime PublishedDate { get; set; }
    }
}