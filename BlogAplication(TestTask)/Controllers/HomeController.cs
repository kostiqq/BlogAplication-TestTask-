using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BlogAplication.Models;
using Microsoft.AspNetCore.Authorization;
using BlogAplication.ViewModels;
using BlogAplication.Services;
using BlogAplication.ViewModels.NewsViewModels;

namespace BlogAplication.Controllers
{
    public class HomeController : Controller
    {
        // создаем контекст данных
        private readonly NewsContext dbNews;
        private readonly UserContext dbUsers;
        private NewsService newsService;

        private string firstDate = "01.01.2019", secondDateN = "31.01.2090";
        private int pageN = 1;

        public HomeController(NewsContext dbn, UserContext dbu, NewsService newsService )
        {
            dbNews = dbn;
            dbUsers = dbu;
            this.newsService = newsService;
        }

        public ActionResult Index(string? SearchString, string firstDate = "01.01.2019", string secondDate = "31.01.2090", int page=1)
        {
            int pageSize = 10;
            // получаем из бд все объекты Book
            IEnumerable<News> newse = dbNews.news;
            // передаем все объекты в динамическое свойство Books в ViewBag
            ViewBag.News = newse;
            // возвращаем представление
            NewsViewModel news = newsService.GetNews(SearchString, firstDate, secondDate, page);
            //NewsFilterViewModel Nov = new NewsFilterViewModel { InputRequest=SearchString,SelectedFirstDate=firstDate,SelectedSecondDate=secondDate };
            return View(news);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
