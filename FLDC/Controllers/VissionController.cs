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
    //this will controll الرؤية والرسالة والاهداف التى ستظهر الى المستخدم
    // 1 الرؤية 
    // 2 الرسالة
    // 3 الهداف
    public class VissionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Vission
        public ActionResult Index()
        {
            return View(db.AboutCenters.ToList());
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
