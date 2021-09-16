using System;

namespace TechnicalRadiation.Models.DTOs
{
    public class NewsItemDetailDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ShordDescription { get; set; }
        public string ImgSource { get; set; }
        public string LongDescription { get; set; }
        public DateTime PublishDate { get; set; }

    }
}