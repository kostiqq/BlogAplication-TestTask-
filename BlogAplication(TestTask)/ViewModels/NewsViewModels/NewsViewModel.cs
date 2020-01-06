using System;
using System.Collections.Generic;
using BlogAplication.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogAplication.ViewModels.NewsViewModels
{
    public class NewsViewModel
    {
        public IEnumerable<News> News { get; set; }
        //public SelectList CategoryList { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public DateTime firstDate { get; set; }
        public SelectList CategoryList { get; set; }
        public DateTime secondDate { get; set; }
        public NewsFilterViewModel FilterViewModel { get; set; }

    }
}
