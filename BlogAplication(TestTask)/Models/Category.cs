using System.Collections.Generic;

namespace BlogAplication.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<News> News { get; set; }
        
        public Category()
        {
            News = new List<News>();
        }
    }
}
