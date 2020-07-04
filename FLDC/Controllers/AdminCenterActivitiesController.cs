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
    //this will control أنشطة المركز
    //the code = 3
    [Authorize]
    public class AdminCenterActivitiesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CenterActivities
        public ActionResult Index()
        {
            return View(db.CenterRules.Where(A=>A.Code==3).ToList());
        }

        // GET: CenterActivities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CenterRule centerRule = db.CenterRules.Find(id);
            if (centerRule == null)
            {
                return HttpNotFound();
            }
            return View(centerRule);
        }

        // GET: CenterActivities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CenterActivities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CenterRuleId,Text,Code")] CenterRule centerRule)
        {
            if (ModelState.IsValid)
            {
                centerRule.Code = 3;
                db.CenterRules.Add(centerRule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(centerRule);
        }

        // GET: CenterActivities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CenterRule centerRule = db.CenterRules.Find(id);
            if (centerRule == null)
            {
                return HttpNotFound();
            }
            return View(centerRule);
        }

        // POST: CenterActivities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CenterRuleId,Text,Code")] CenterRule centerRule)
        {
            if (ModelState.IsValid)
            {
                centerRule.Code = 3;
                db.Entry(centerRule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(centerRule);
        }

        // GET: CenterActivities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CenterRule centerRule = db.CenterRules.Find(id);
            if (centerRule == null)
            {
                return HttpNotFound();
            }
            return View(centerRule);
        }

        // POST: CenterActivities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CenterRule centerRule = db.CenterRules.Find(id);
            db.CenterRules.Remove(centerRule);
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
