namespace TechnicalRadiation.Models.Entities
{
    public class NewsItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ShordDescription { get; set; }
        public string LongDescription { get; set; }
        public string ImgSource { get; set; }

        public string ModifiedBy { get; set; }

        // Navigation properties
        
    }
}