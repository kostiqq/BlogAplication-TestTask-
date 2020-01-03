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
using BlogAplication.ViewModels.ProcedureViewModels;
using Microsoft.EntityFrameworkCore;

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

        public HomeController(NewsContext dbn, UserContext dbu, NewsService newsService)
        {
            dbNews = dbn;
            dbUsers = dbu;
            this.newsService = newsService;
        }

        public ActionResult Index(string? SearchString, DateTime firstDate, DateTime secondDate, string d0 = "01.01.1970", string d = "01.01.2030", int page = 1)
        {
            int pageSize = 1;
            List<object[]> source = new List<object[]>();

            IEnumerable<News> newse = dbNews.news;

            ViewBag.News = newse;
            var count = dbNews.news.Count();
            var items = dbNews.news.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            NewsViewModel viewModel = new NewsViewModel
            {
                FilterViewModel = new NewsFilterViewModel(SearchString, firstDate, secondDate),
                PageViewModel = pageViewModel,
                News = items,
            };
            return View(viewModel);
        }

        [HttpGet]
        [Authorize(Roles="admin")]
        public ActionResult EditNews(int? id)
        {
            News news = dbNews.news.Find(id);
            return View(news);
        }
        [HttpPost]
        public ActionResult EditNews(News news)
        {
            dbNews.news.Update(news);
            dbNews.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Authorize(Roles="admin")]
        [ActionName("DeleteNews")]
        public ActionResult ConfirmDeleteNews(int id)
        {
            News news = dbNews.news.Find(id);
            if (news == null)
                return View("Not Found");
            else return View(news);
        }

        [HttpPost]
        public ActionResult DeleteNews(int id)
        {
                var news = dbNews.news.FirstOrDefault(c => c.Id == id);
                dbNews.news.Remove(news);
                dbNews.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Authorize(Roles="admin")]
        public IActionResult CreateNews()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateNews(News news)
        {
            dbNews.news.Add(news);
            dbNews.SaveChanges();
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
