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
    //this will controll الرؤساء السابقون التى ستظهر الى المستخدم
    //the code = 4
    public class PreviousPresidentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PreviousPresident
        public ActionResult Index()
        {
            return View(db.CenterStaffs.Where(A=>A.Code==4).ToList());
        }
        public ActionResult Details(int? id)
        {
            CenterStaff C = db.CenterStaffs.Find(id);
            return View(C);
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
