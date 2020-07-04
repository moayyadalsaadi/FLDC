using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Graduation_Project.Models;
using System.Net.Mail;
using System.Configuration;

namespace Graduation_Project.Controllers
{
    //this will controll the courses that the admin manage
    [Authorize]
    public class AdminCoursesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Courses
        public ActionResult Index()
        {
            return View(db.Courses.ToList());
        }

        // GET: Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // GET: Courses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CourseId,Name,Description,SeatNumber,SeatBooked,AvailableSeat,DateStart,DateEnd, CourseType, CourseDays")] Course course)
        {
            if (ModelState.IsValid)
            {
                course.SeatBooked = 0;
                course.ShowHide = 1;       
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(course);
        }

        // GET: Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CourseId,Name,Description,SeatNumber,SeatBooked,DateStart,DateEnd, CourseType, CourseDays, ShowHide")] Course course)
        {
            if (ModelState.IsValid)
            {
                course.ShowHide = 1;
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(course);
        }

        // GET: Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = db.Courses.Find(id);
            db.Courses.Remove(course);
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
        //this action gets the applicants of the course
        [HttpGet]
        public ActionResult GetUser(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var users = db.Applicants.Where(A => A.CourseId == id && A.State == 1).ToList();
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }
        //this action get the details of the applicants       
        public ActionResult UserDetails(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant user = db.Applicants.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        //this method will set user state to 2 when his data is correct form, payment, stutas are correct
        // قبول المتقدمين في الكورس
        public ActionResult AcceptUser(int id)
        {
            Applicant user = db.Applicants.Single(A => A.ApplicantId == id);
            string UserEmail = user.Email;
            Course course = db.Courses.SingleOrDefault(A => A.CourseId == user.CourseId);
            string CourseName = course.Name;
            user.State = 2;
            db.SaveChanges();
            //ارسال رسالة تأكيد الى المتقدم
            MailMessage mm = new MailMessage(ConfigurationManager.AppSettings["Email"].ToString(), UserEmail);
            mm.Subject = "تأكيد التقديم";
            mm.Body = "تم قبولك في البرنامج التدريبي " + CourseName;
            mm.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            NetworkCredential nc = new NetworkCredential(ConfigurationManager.AppSettings["Email"].ToString(), ConfigurationManager.AppSettings["Password"].ToString());
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;
            smtp.Send(mm);

            int courseid = user.CourseId;
            Course C = db.Courses.Single(A => A.CourseId == courseid);
            DateTime date = new DateTime();
            date = Convert.ToDateTime(C.DateStart);
            int count = db.Applicants.Count(A => A.CourseId == courseid && A.State == 1 || A.State == 2 && A.CourseStart == date);
            C.SeatBooked = count;
            db.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
            //return "<br><center><h1 style=\"color:green\">تم التاكيد على هذا الطلب بنجاح</h1></center>";
        }
        // رفض المتقدمين في الكورس
        public ActionResult RefuseUser(int id)
        {
            Applicant user = db.Applicants.Single(A => A.ApplicantId == id);
            string UserEmail = user.Email;
            Course course = db.Courses.SingleOrDefault(A => A.CourseId == user.CourseId);
            string CourseName = course.Name;
            user.State = 4;
            db.SaveChanges();
            //ارسال رسالة رفض الى المتقدم
            MailMessage mm = new MailMessage(ConfigurationManager.AppSettings["Email"].ToString(), UserEmail);
            mm.Subject = "قم بالتواصل مع المركز ";
            mm.Body = "تم رفض طلبك في البرنامج التدريبي " + CourseName;
            mm.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            NetworkCredential nc = new NetworkCredential(ConfigurationManager.AppSettings["Email"].ToString(), ConfigurationManager.AppSettings["Password"].ToString());
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;
            smtp.Send(mm);

            int courseid = user.CourseId;
            Course C = db.Courses.Single(A => A.CourseId == courseid);
            DateTime date = new DateTime();
            date = Convert.ToDateTime(C.DateStart);
            int count = db.Applicants.Count(A => A.CourseId == courseid && A.State == 1 || A.State == 2 && A.CourseStart == date);
            C.SeatBooked = count;
            db.SaveChanges();
            return Redirect(Request.UrlReferrer.ToString());
            //return "<br><center><h1 style=\"color:red\">تم رفض  هذا الطلب </h1></center>";
        }
        // show the course
        public ActionResult ShowCourse(int id)
        {
            Course C = db.Courses.Find(id);
            C.ShowHide = 1;
            db.SaveChanges();
            return RedirectToAction("Index");           
        }
        // hide the course
        public ActionResult HideCourse(int id)
        {
            Course C = db.Courses.Find(id);
            C.ShowHide = 0;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}