namespace TechnicalRadiation.Models.Entities

{
    public class AuthorNewsItem 
    {
        public int AuthorsId { get; set; }
        public int NewsItemsId { get; set; }

        //Navigation links
        public Authors Authors { get; set; }
        public NewsItems NewsItems { get; set; }
    }
}