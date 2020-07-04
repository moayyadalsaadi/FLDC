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
    [Authorize]
    public class AdminUniDecisionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UniDecision
        //this get قرارات جامعية
        //the code of it is 2
        public ActionResult Index()
        {
            return View(db.CenterAchievements.Where(A=>A.Code==2).ToList());
        }

        // GET: UniDecision/Details/5
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

        // GET: UniDecision/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UniDecision/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CenterAchievementId,Label,Text,Code")] CenterAchievement centerAchievement)
        {
            if (ModelState.IsValid)
            {
                centerAchievement.Code = 2;
                db.CenterAchievements.Add(centerAchievement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(centerAchievement);
        }

        // GET: UniDecision/Edit/5
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

        // POST: UniDecision/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CenterAchievementId,Label,Text,Code")] CenterAchievement centerAchievement)
        {
            if (ModelState.IsValid)
            {
                centerAchievement.Code = 2;
                db.Entry(centerAchievement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(centerAchievement);
        }

        // GET: UniDecision/Delete/5
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

        // POST: UniDecision/Delete/5
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
