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
    //this will controll قواعد المركز التى تظهر الى المستخدم
    //the code = 1
    public class CenterRuleController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CenterRule
        public ActionResult Index()
        {
            return View(db.CenterRules.Where(A=>A.Code==1).ToList());
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