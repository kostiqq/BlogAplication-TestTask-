using System;
using System.ComponentModel.DataAnnotations;

namespace BlogAplication.ViewModels.NewsViewModels
{
    public class NewsDisplay
    {
        [Display(Name = "Title")]
        [Required(ErrorMessage = "Title required")]
        public string Name { get; set; }
        [Display(Name = "Short description")]
        [Required(ErrorMessage = "Short description required")]
        public string ShortDesc { get; set; }
        [Display(Name = "Full description")]
        [Required(ErrorMessage = "Description required")]
        public string Description { get; set; }
        [Display(Name = "Image")]
        public string ImageLink { get; set; }
        [Display(Name = "Category")]
        [Required(ErrorMessage = "Category required")]
        public string Category { get; set; }
        [Display(Name = "Tags")]
        [Required(ErrorMessage = "Tags required")]
        public string Tags { get; set; }
        [Display(Name = "Date of publication")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
