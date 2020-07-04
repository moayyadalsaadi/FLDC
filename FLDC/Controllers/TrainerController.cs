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
    //this will controll المدربون التى ستظهر الى المستخدم
    //the code = 2
    public class TrainerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Trainer
        public ActionResult Index()
        {
            return View(db.CenterStaffs.Where(A=>A.Code==2).ToList());
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
