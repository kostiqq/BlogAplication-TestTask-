using System;
using System.ComponentModel.DataAnnotations;

namespace BlogAplication.Models
{
    public class News
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortDesc { get; set; }
        public string Description { get; set; }
        public string ImageLink { get; set; }
        public int CategoryID { get; set; }
        public string Tags { get; set; }
        public DateTime Date { get; set; }
        public virtual Category Category { get; set; }
    }
}
