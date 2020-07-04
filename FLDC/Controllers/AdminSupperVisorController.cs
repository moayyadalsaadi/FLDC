﻿using System;
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
    //this will control المشرفون 
    //the code is = 3
    [Authorize]
    public class AdminSupperVisorController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SupperVisor
        public ActionResult Index()
        {
            return View(db.CenterStaffs.Where(A => A.Code == 3).ToList());
        }

        // GET: SupperVisor/Details/5
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

        // GET: SupperVisor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SupperVisor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CenterStaffId,Name,Description,Path,Code")] CenterStaff centerStaff, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                //get  the id of the last row + 1
                string ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                SqlConnection con = new SqlConnection(ConnectionString);
                string Query = "SELECT IDENT_CURRENT('CenterStaffs') + IDENT_INCR('CenterStaffs')";
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
                //save  image
                string path1_1 = Path.Combine(Server.MapPath("~/ImagesOfProject/SuperVisorPhotos"), Image.FileName);
                string Extension1 = Path.GetExtension(path1_1);
                string path1_2 = Path.Combine(Server.MapPath("~/ImagesOfProject/SuperVisorPhotos"), id + Extension1);
                Image.SaveAs(path1_2);
                string Domain = ConfigurationManager.AppSettings["Domain"].ToString();
                centerStaff.Path = Domain + "/ImagesOfProject/SuperVisorPhotos/" + id + Extension1;               
                
                centerStaff.Code = 3;
                db.CenterStaffs.Add(centerStaff);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(centerStaff);
        }

        // GET: SupperVisor/Edit/5
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

        // POST: SupperVisor/Edit/5
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
                    string path1_1 = Path.Combine(Server.MapPath("~/ImagesOfProject/SuperVisorPhotos"), Image.FileName);
                    string Extension1 = Path.GetExtension(path1_1);
                    string path1_2 = Path.Combine(Server.MapPath("~/ImagesOfProject/SuperVisorPhotos"), id + Extension1);
                    Image.SaveAs(path1_2);
                    string Domain = ConfigurationManager.AppSettings["Domain"].ToString();
                    centerStaff.Path = Domain + "/ImagesOfProject/SuperVisorPhotos/" + id + Extension1;
                }
                
                //string Path1 = Path.Combine(Server.MapPath("~/ImagesOfProject"), centerStaff.CenterStaffId + Image.FileName);
                //Image.SaveAs(Path1);
                //centerStaff.Path = "~/ImagesOfProject/" + centerStaff.CenterStaffId + Image.FileName;

                centerStaff.Code = 3;
                db.Entry(centerStaff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(centerStaff);
        }

        // GET: SupperVisor/Delete/5
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

        // POST: SupperVisor/Delete/5
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
