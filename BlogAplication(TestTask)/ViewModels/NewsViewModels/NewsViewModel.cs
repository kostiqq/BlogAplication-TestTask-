using System.Collections.Generic;
using BlogAplication.Models;

namespace BlogAplication.ViewModels.NewsViewModels
{
    public class NewsViewModel
    {
        public IEnumerable<News> News { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public NewsFilterViewModel FilterViewModel { get; set; }

    }
}
