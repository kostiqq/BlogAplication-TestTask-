using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlogAplication.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public virtual ICollection<News> News { get; set; }
        
        public Category()
        {
            News = new List<News>();
        }
    }
}
