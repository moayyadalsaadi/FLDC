using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Graduation_Project.Models;

namespace Graduation_Project.Controllers
{
    //this will controll كلمة رئيس الجامعة ونائب الرئيس ومدير المركز
    //1 كلمة رئيس الجامعة
    //2 كلمة نائب الرئيس
    //3 كلمة مدير المركز
    public class PresidentWordController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PresidentWord
        public ActionResult Index()
        {
            return View(db.PresidentWords.ToList());
        }
       
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
