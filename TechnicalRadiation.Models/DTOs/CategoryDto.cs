namespace TechnicalRadiation.Models.DTOs
{
    public class CategoryDto : HyperMediaModel
    {
        
        public int Id { get; set; }
        public string Name { get; set; }

        public string Slug {get; set;}
    }
}