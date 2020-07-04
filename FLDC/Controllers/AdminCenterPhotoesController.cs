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
    //this will controll صور المركز
    [Authorize]
    public class AdminCenterPhotoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CenterPhotoes
        public ActionResult Index()
        {
            return View(db.CenterPhotos.ToList());
        }

        // GET: CenterPhotoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CenterPhoto centerPhoto = db.CenterPhotos.Find(id);
            if (centerPhoto == null)
            {
                return HttpNotFound();
            }
            return View(centerPhoto);
        }

        // GET: CenterPhotoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CenterPhotoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CenterPhotosId,Description,Path")] CenterPhoto centerPhoto, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                //get  the id of the last row + 1
                string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlConnection con = new SqlConnection(ConnectionString);
                string Query = "SELECT IDENT_CURRENT('CenterPhotoes') + IDENT_INCR('CenterPhotoes')";
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
                catch (Exception e)
                {

                    Response.Write(e);
                }

                string path1_1 = Path.Combine(Server.MapPath("~/ImagesOfProject/CenterPhotos"), Image.FileName);
                string Extension1 = Path.GetExtension(path1_1);
                string path1_2 = Path.Combine(Server.MapPath("~/ImagesOfProject/CenterPhotos"), id + Extension1);
                Image.SaveAs(path1_2);
                string Domain = ConfigurationManager.AppSettings["Domain"].ToString();
                centerPhoto.Path = Domain + "/ImagesOfProject/CenterPhotos/" + id + Extension1;

                db.CenterPhotos.Add(centerPhoto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(centerPhoto);
        }

        // GET: CenterPhotoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CenterPhoto centerPhoto = db.CenterPhotos.Find(id);
            if (centerPhoto == null)
            {
                return HttpNotFound();
            }
            return View(centerPhoto);
        }

        // POST: CenterPhotoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CenterPhotosId,Description,Path")] CenterPhoto centerPhoto, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                int id = centerPhoto.CenterPhotosId;
                if (Image != null)
                {
                    string path1_1 = Path.Combine(Server.MapPath("~/ImagesOfProject/CenterPhotos"), Image.FileName);
                    string Extension1 = Path.GetExtension(path1_1);
                    string path1_2 = Path.Combine(Server.MapPath("~/ImagesOfProject/CenterPhotos"), id + Extension1);
                    Image.SaveAs(path1_2);
                    string Domain = ConfigurationManager.AppSettings["Domain"].ToString();
                    centerPhoto.Path = Domain + "/ImagesOfProject/CenterPhotos/" + id + Extension1;
                }

                //string path = Path.Combine(Server.MapPath("~/ImagesOfProject/CenterPhotos"), Image.FileName);
                //Image.SaveAs(path);
                //centerPhoto.Path = "~/ImagesOfProject/CenterPhotos/" + Image.FileName;
                db.Entry(centerPhoto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(centerPhoto);
        }

        // GET: CenterPhotoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CenterPhoto centerPhoto = db.CenterPhotos.Find(id);
            if (centerPhoto == null)
            {
                return HttpNotFound();
            }
            return View(centerPhoto);
        }

        // POST: CenterPhotoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CenterPhoto centerPhoto = db.CenterPhotos.Find(id);
            db.CenterPhotos.Remove(centerPhoto);
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
