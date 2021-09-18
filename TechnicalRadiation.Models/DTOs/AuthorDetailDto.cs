namespace TechnicalRadiation.Models.DTOs
{
    public class AuthorDetailDto : HyperMediaModel
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public string ProfileImgSource { get; set; }
    }
}