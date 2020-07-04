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
    //this will controll قواعد المركز
    //the code = 1
    [Authorize]
    public class AdminCenterRuleController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CenterRule
        public ActionResult Index()
        {
            return View(db.CenterRules.Where(A=>A.Code==1).ToList());
        }

        // GET: CenterRule/Details/5
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

        // GET: CenterRule/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CenterRule/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CenterRuleId,Text")] CenterRule centerRule)
        {
            if (ModelState.IsValid)
            {
                centerRule.Code = 1;
                db.CenterRules.Add(centerRule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(centerRule);
        }

        // GET: CenterRule/Edit/5
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

        // POST: CenterRule/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CenterRuleId,Text")] CenterRule centerRule)
        {
            if (ModelState.IsValid)
            {
                centerRule.Code = 1;
                db.Entry(centerRule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(centerRule);
        }

        // GET: CenterRule/Delete/5
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

        // POST: CenterRule/Delete/5
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
