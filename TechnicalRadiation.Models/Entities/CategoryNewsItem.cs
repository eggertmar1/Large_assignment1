namespace TechnicalRadiation.Models.Entities

{
    public class CategoryNewsItem 
    {
        public int CategoriesId { get; set; }
        public int NewsItemsId { get; set; }

        //Navigation links
        public Categories Categories { get; set; }
        public NewsItems NewsItems { get; set; }
    }
}