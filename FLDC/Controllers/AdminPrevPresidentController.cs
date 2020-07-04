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
    //this will control رؤساء سابقون
    //the code of them = 4
    [Authorize]
    public class AdminPrevPresidentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PrevPresident
        public ActionResult Index()
        {
            return View(db.CenterStaffs.Where(A => A.Code == 4).ToList());
        }

        // GET: PrevPresident/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CenterStaff centerStaff = db.CenterStaffs.Find(id);
            if (centerStaff == null)
            {
                return HttpNotFound();
            }
            return View(centerStaff);
        }

        // GET: PrevPresident/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PrevPresident/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CenterStaff centerStaff, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                //get  the id of the last row + 1
                string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlConnection con = new SqlConnection(ConnectionString);
                string Query = "SELECT IDENT_CURRENT('centerStaffs') + IDENT_INCR('centerStaffs')";
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
                //save form image
                string path1_1 = Path.Combine(Server.MapPath("~/ImagesOfProject/PrePresidentPhotos"), Image.FileName);
                string Extension1 = Path.GetExtension(path1_1);
                string path1_2 = Path.Combine(Server.MapPath("~/ImagesOfProject/PrePresidentPhotos"), id + Extension1);
                Image.SaveAs(path1_2);
                string Domain = ConfigurationManager.AppSettings["Domain"].ToString();
                centerStaff.Path = Domain + "/ImagesOfProject/PrePresidentPhotos/" + id + Extension1;                
                
                centerStaff.Code = 4;
                db.CenterStaffs.Add(centerStaff);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(centerStaff);
        }

        // GET: PrevPresident/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CenterStaff centerStaff = db.CenterStaffs.Find(id);
            if (centerStaff == null)
            {
                return HttpNotFound();
            }
            return View(centerStaff);
        }

        // POST: PrevPresident/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CenterStaffId,Name,Description,Path,Code")] CenterStaff centerStaff, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                int id = centerStaff.CenterStaffId;
                if (Image!=null)
                {
                    string path1_1 = Path.Combine(Server.MapPath("~/ImagesOfProject/PrePresidentPhotos"), Image.FileName);
                    string Extension1 = Path.GetExtension(path1_1);
                    string path1_2 = Path.Combine(Server.MapPath("~/ImagesOfProject/PrePresidentPhotos"), id + Extension1);
                    Image.SaveAs(path1_2);
                    string Domain = ConfigurationManager.AppSettings["Domain"].ToString();
                    centerStaff.Path = Domain + "/ImagesOfProject/PrePresidentPhotos/" + id + Extension1;
                }                

                //string Path1 = Path.Combine(Server.MapPath("~/ImagesOfProject/PrePresidentPhotos"), centerStaff.CenterStaffId + Image.FileName);
                //Image.SaveAs(Path1);
                //centerStaff.Path = "~/ImagesOfProject/" + centerStaff.CenterStaffId + Image.FileName;

                centerStaff.Code = 4;
                db.Entry(centerStaff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(centerStaff);
        }

        // GET: PrevPresident/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CenterStaff centerStaff = db.CenterStaffs.Find(id);
            if (centerStaff == null)
            {
                return HttpNotFound();
            }
            return View(centerStaff);
        }

        // POST: PrevPresident/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CenterStaff centerStaff = db.CenterStaffs.Find(id);
            db.CenterStaffs.Remove(centerStaff);
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
