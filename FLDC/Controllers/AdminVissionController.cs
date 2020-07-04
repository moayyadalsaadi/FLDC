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
    //this will controll الرؤية والرسالة والاهداف مع الادمن
    // 1 الرؤية
    // 2 الرسالة 
    // 3 الاهداف
    [Authorize]
    public class AdminVissionController : Controller
    {
        //this will controll الرؤية والرسالة والاهداف
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Vission
        public ActionResult Index()
        {
            return View(db.AboutCenters.ToList());
        }

        // GET: Vission/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutCenter aboutCenter = db.AboutCenters.Find(id);
            if (aboutCenter == null)
            {
                return HttpNotFound();
            }
            return View(aboutCenter);
        }               

        // GET: Vission/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AboutCenter aboutCenter = db.AboutCenters.Find(id);
            if (aboutCenter == null)
            {
                return HttpNotFound();
            }
            return View(aboutCenter);
        }

        // POST: Vission/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AboutCenterId,Text,code")] AboutCenter aboutCenter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aboutCenter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aboutCenter);
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
