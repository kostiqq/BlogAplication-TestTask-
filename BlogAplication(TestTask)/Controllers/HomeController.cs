using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BlogAplication.Models;
using Microsoft.AspNetCore.Authorization;
using BlogAplication.Services;
using BlogAplication.ViewModels.NewsViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogAplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly NewsContext dbNews;
        private NewsService newsService;

        private NewsDisplay _news = new NewsDisplay
        {
            Category= ""
        };
        public HomeController(NewsContext dbn, UserContext dbu, NewsService newsService)
        {
            dbNews = dbn;
            this.newsService = newsService;
        }

        public ActionResult Index(int? category, string? SearchString, string firstDate= "01.01.2019", string secondDate="31.01.2030", int page = 1)
        {
            NewsViewModel news = newsService.GetNews(category, SearchString, firstDate,secondDate,page);
            return View(news);
        }

        [HttpGet]
        [Authorize(Roles="admin")]
        public ActionResult EditNews(int? id)
        {
            var newsContext = dbNews.news.Include(p => p.Category);
            var items = newsContext.Where(p => p.Id == id).ToList();
            var category = new SelectList(dbNews.Category, "CategoryID", "CategoryName", items.First().CategoryID);
            NewsViewModel news = new NewsViewModel
            {
                newsDisplay= _news,
                News = items,
                CategoryList = category
            };
            return View(news);
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
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
