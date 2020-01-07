﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using BlogAplication.Models;
using BlogAplication.ViewModels;
using BlogAplication.ViewModels.NewsViewModels;

namespace BlogAplication.Services
{
    public class NewsService
    {
        private NewsContext context;
        public NewsService(NewsContext context)
        {
            this.context = context;
        }
        public NewsViewModel GetNews(int? category, string? SearchString, string firstDate, string secondDate, int page)
        {
            DateTime first, second;
            NewsViewModel news = null;
            try
            {
                first = Convert.ToDateTime(firstDate);
            }
            catch
            {
                first = Convert.ToDateTime("01.01.1981");
            }
            try
            {
                second = Convert.ToDateTime(secondDate);
            }
            catch
            {
                second = Convert.ToDateTime("10.01.2030");
            }
            int pageSize = 10;
            IQueryable<News> source = context.news;
            if (SearchString != null)
            {
                firstDate = null;
                secondDate = null;
                source = source.Where(p => p.Category.CategoryName.Contains(SearchString) || p.Tags.Contains(SearchString));
            }
            if (firstDate != null || secondDate != null)
            {
                source = source.Where(p => p.Date >= first && p.Date <= second);
            }
            var count = source.Count();
            var items = source.Include(p => p.Category).Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            news = new NewsViewModel
            {
                News = items,
                PageViewModel = pageViewModel,
                FilterViewModel = new NewsFilterViewModel(SearchString, first, second)
            };  
            return news;
        }
    }
}
