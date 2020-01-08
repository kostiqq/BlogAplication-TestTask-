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
        public HomeController(NewsContext dbn, NewsService newsService)
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
        public ActionResult EditNews(int? id)
        {
            News news = dbNews.news.Find(id);
            SelectList categories = new SelectList(dbNews.Category, "Id", "CategoryName", news.CategoryID);
            ViewBag.Categories = categories;
            return View(news);
        }
        [HttpPost]
        public ActionResult EditNews(News news)
        {
            if (ModelState.IsValid)
            {
                dbNews.news.Update(news);
                dbNews.SaveChanges();
                return RedirectToAction("Index");
            }
            else return View(news);
        }

        [HttpGet]
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
        public IActionResult CreateNews()
        {
            SelectList categories = new SelectList(dbNews.Category, "Id", "CategoryName");
            ViewBag.Categories = categories;
            return View();
        }
        [HttpPost]
        public ActionResult CreateNews(News news)
        {
            if (ModelState.IsValid)
            {
                dbNews.news.Add(news);
                dbNews.SaveChanges();
                RedirectToAction("Index");
            }
            return View(news);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public ActionResult NewsView(int id)
        {
            var news = dbNews.news.Find(id);
            if (news != null)
            {
                return View(news);
            }
            return RedirectToAction("Index");
        }
    }
}
