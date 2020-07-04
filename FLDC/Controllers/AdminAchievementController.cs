using Graduation_Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Graduation_Project.Controllers
{
    [Authorize]
    public class AdminAchievementController : Controller
    {
        // GET: AdminAchievement
        private ApplicationDbContext db = new ApplicationDbContext();        
        // GET: Achievement
        //this get  الانجازات
        //the code of it is 1
        public ActionResult Index()
        {
            return View(db.CenterAchievements.Where(A => A.Code == 1).ToList());
        }

        // GET: Achievement/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CenterAchievement centerAchievement = db.CenterAchievements.Find(id);
            if (centerAchievement == null)
            {
                return HttpNotFound();
            }
            return View(centerAchievement);
        }

        // GET: Achievement/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Achievement/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CenterAchievementId,Label,Text,Code")] CenterAchievement centerAchievement)
        {
            if (ModelState.IsValid)
            {
                centerAchievement.Code = 1;
                db.CenterAchievements.Add(centerAchievement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(centerAchievement);
        }

        // GET: Achievement/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CenterAchievement centerAchievement = db.CenterAchievements.Find(id);
            if (centerAchievement == null)
            {
                return HttpNotFound();
            }
            return View(centerAchievement);
        }

        // POST: Achievement/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CenterAchievementId,Label,Text,Code")] CenterAchievement centerAchievement)
        {
            if (ModelState.IsValid)
            {
                centerAchievement.Code = 1;
                db.Entry(centerAchievement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(centerAchievement);
        }

        // GET: Achievement/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CenterAchievement centerAchievement = db.CenterAchievements.Find(id);
            if (centerAchievement == null)
            {
                return HttpNotFound();
            }
            return View(centerAchievement);
        }

        // POST: Achievement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CenterAchievement centerAchievement = db.CenterAchievements.Find(id);
            db.CenterAchievements.Remove(centerAchievement);
            db.SaveChanges();
            return RedirectToAction("Index");
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