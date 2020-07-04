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
    //this will controll لوائح المركز التى ستظهر الى المستخدم
    //the code = 2
    public class CenterRegulationController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CenterRegulation
        public ActionResult Index()
        {
            return View(db.CenterRules.Where(A=>A.Code==2).ToList());
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
