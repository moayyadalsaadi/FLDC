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
    //this will controll لوائح المركز
    //the code = 2
    [Authorize]
    public class AdminCenterRegulationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CenterRegulations
        public ActionResult Index()
        {
            return View(db.CenterRules.Where(A=>A.Code==2).ToList());
        }

        // GET: CenterRegulations/Details/5
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

        // GET: CenterRegulations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CenterRegulations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CenterRuleId,Text,Code")] CenterRule centerRule)
        {
            if (ModelState.IsValid)
            {
                centerRule.Code = 2;
                db.CenterRules.Add(centerRule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(centerRule);
        }

        // GET: CenterRegulations/Edit/5
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

        // POST: CenterRegulations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CenterRuleId,Text,Code")] CenterRule centerRule)
        {
            if (ModelState.IsValid)
            {
                centerRule.Code = 2;
                db.Entry(centerRule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(centerRule);
        }

        // GET: CenterRegulations/Delete/5
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

        // POST: CenterRegulations/Delete/5
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
