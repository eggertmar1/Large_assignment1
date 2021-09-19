using System;
using System.Collections.Generic;

namespace TechnicalRadiation.Models.Entities
{
    public class Authors 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProfileImgSource { get; set; }
        public string Bio { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        //Navigation properties
        public ICollection<NewsItems> NewsItemsLink { get; set; }


    }
}