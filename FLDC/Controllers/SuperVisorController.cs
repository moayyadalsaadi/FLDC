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
    //this will controll المشرفون
    //the code =3
    public class SuperVisorController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SuperVisor
        public ActionResult Index()
        {
            return View(db.CenterStaffs.Where(A=>A.Code==3).ToList());
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
