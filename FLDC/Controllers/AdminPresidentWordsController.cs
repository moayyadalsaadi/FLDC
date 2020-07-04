using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Graduation_Project.Models;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;

namespace Graduation_Project.Controllers
{
    //this will controll كلمة رئيس الجامعة
    //the code = 1
    [Authorize]
    public class AdminPresidentWordsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PresidentWords
        public ActionResult Index()
        {
            return View(db.PresidentWords.Where(A => A.Code == 1).ToList());
        }

        // GET: PresidentWords/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PresidentWord presidentWord = db.PresidentWords.Find(id);
            if (presidentWord == null)
            {
                return HttpNotFound();
            }
            return View(presidentWord);
        }

        // GET: PresidentWords/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PresidentWords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PresidentWordId,Name,Description,Text,Path,Code")] PresidentWord presidentWord, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                //get  the id of the last row + 1
                string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlConnection con = new SqlConnection(ConnectionString);
                string Query = "SELECT IDENT_CURRENT('PresidentWords') + IDENT_INCR('PresidentWords')";
                SqlCommand cmd = new SqlCommand(Query, con);
                int id = 0;
                try
                {
                    con.Open();
                    SqlDataReader dr;
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        id = Convert.ToInt32(dr[0]);
                    }
                    dr.Close();
                    con.Close();
                }
                catch (Exception)
                {

                    throw;
                }

                string path1_1 = Path.Combine(Server.MapPath("~/ImagesOfProject/PresidentPhotos"), Image.FileName);
                string Extension1 = Path.GetExtension(path1_1);
                string path1_2 = Path.Combine(Server.MapPath("~/ImagesOfProject/PresidentPhotos"), id + Extension1);
                Image.SaveAs(path1_2);
                string Domain = ConfigurationManager.AppSettings["Domain"].ToString();
                presidentWord.Path = Domain + "/ImagesOfProject/PresidentPhotos/" + id + Extension1;
                
                presidentWord.Code = 1;
                db.PresidentWords.Add(presidentWord);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(presidentWord);
        }

        // GET: PresidentWords/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PresidentWord presidentWord = db.PresidentWords.Find(id);
            if (presidentWord == null)
            {
                return HttpNotFound();
            }
            return View(presidentWord);
        }

        // POST: PresidentWords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PresidentWordId,Name,Description,Text,Path,Code")] PresidentWord presidentWord, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                int id = presidentWord.PresidentWordId;
                if (Image!=null)
                {
                    string path1_1 = Path.Combine(Server.MapPath("~/ImagesOfProject/PresidentPhotos"), Image.FileName);
                    string Extension1 = Path.GetExtension(path1_1);
                    string path1_2 = Path.Combine(Server.MapPath("~/ImagesOfProject/PresidentPhotos"), id + Extension1);
                    Image.SaveAs(path1_2);
                    string Domain = ConfigurationManager.AppSettings["Domain"].ToString();
                    presidentWord.Path = Domain + "/ImagesOfProject/PresidentPhotos/" + id + Extension1;
                }                               

                presidentWord.Code = 1;
                db.Entry(presidentWord).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(presidentWord);
        }

        // GET: PresidentWords/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PresidentWord presidentWord = db.PresidentWords.Find(id);
            if (presidentWord == null)
            {
                return HttpNotFound();
            }
            return View(presidentWord);
        }

        // POST: PresidentWords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PresidentWord presidentWord = db.PresidentWords.Find(id);
            db.PresidentWords.Remove(presidentWord);
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
