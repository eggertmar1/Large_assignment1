using System;

namespace TechnicalRadiation.Models.InputModels
{
    public class NewsItemInputModel
    {
        [Required]
        public string Title { get; set; }

        //TODO implement a custom valid url attribute
        public string ImgSource { get; set; }

        [Required]
        [maxlength(50)]
        public string ShortDescription { get; set; }

        [minlenght(50)]
        [maxlength(255)]
        public string LongDescription { get; set; }

        [Required]
        public DateTime PublishedDate { get; set; }
    }
}