using Graduation_Project.Models;
using Graduation_Project.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Graduation_Project.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            //this view model get the data of news, center photos, and president word
            HomeDataViewModel Data = new HomeDataViewModel();
            Data.news = db.Newss.ToList();
            Data.CenterPhotos = db.CenterPhotos.ToList();
            Data.PresidentWords = db.PresidentWords.ToList();
            return View(Data);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}