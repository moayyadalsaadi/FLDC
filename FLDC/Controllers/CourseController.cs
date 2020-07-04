using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Graduation_Project.Models;
using System.Net;
using System.IO;
using Microsoft.Reporting.WebForms;
using System.Configuration;

namespace Graduation_Project.Controllers
{
    //this will controll الكورسات التى تعرض للمستخدم
    public class CourseController : Controller
    {
        // GET: Course
        ApplicationDbContext DB = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View(DB.Courses.Where(A => A.ShowHide == 1).ToList());
        }

        [HttpGet]
        public ActionResult Apply(int? id)
        {
            //ViewBag.CourseId = new SelectList(DB.Courses, "CourseId", "Name");
            string CourseName = DB.Courses.Single(A => A.CourseId == id).Name;
            ViewBag.CourseId = id;
            ViewBag.CourseName = CourseName;
            return View();
        }
        [HttpPost]
        public ActionResult Apply(Applicant U)
        {
            if (ModelState.IsValid)
            {
                int courseid = U.CourseId;
                Course C = DB.Courses.Find(courseid);
                DateTime dateStart = new DateTime();
                dateStart = Convert.ToDateTime(C.DateStart);
                string ApplicantSSN = U.SSN;
                Applicant A = DB.Applicants.SingleOrDefault(E => E.SSN == ApplicantSSN && E.CourseStart == dateStart);
                if (A!=null)
                {
                    ViewBag.Message = "لا يمكن التسجيل في برنامجين لهم نفس التاريخ";
                    string CourseName = DB.Courses.SingleOrDefault(F => F.CourseId == courseid).Name;
                    ViewBag.CourseId = courseid;
                    ViewBag.CourseName = CourseName;
                    return View();
                }
                else
                {
                    //get the start date of the course                                        
                    U.CourseStart = dateStart;

                    //set the state of user to zero
                    U.State = 0;

                    //generate a random 5 digit code for the user
                    Random r = new Random();
                    //get the last 7 digit of the SSN
                    double ssn = Convert.ToDouble(U.SSN) % 10000000;
                    //concatinate the last 7 digit with 5 random digits
                    string x = r.Next(10000, 99999).ToString();
                    U.Code = ssn + x;

                    DB.Applicants.Add(U);
                    DB.SaveChanges();
                    return View("UserInfo", U);
                }                
            }
            return View(U);
        }

        //this action get the user after application
        [HttpGet]
        public ActionResult GetUserPdf(int? id)
        {
            //get the user
            Applicant user = DB.Applicants.Single(A => A.ApplicantId == id);
            //get the course
            Course course = DB.Courses.Single(A => A.CourseId == user.CourseId);
            //start the report
            LocalReport lr = new LocalReport();            
            int ReportType = course.CourseType;
            string path = "";
            if (ReportType == 1)
            {
                path = Path.Combine(Server.MapPath("~/Report"), "PdfReport.rdlc");
            }
            else if (ReportType == 2)
            {
                path = Path.Combine(Server.MapPath("~/Report"), "OnLinePdfReport.rdlc");
            }

            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return View("Apply");
            }
            ReportParameterCollection Parm = new ReportParameterCollection();
            Parm.Add(new ReportParameter("UserName", user.Name));
            Parm.Add(new ReportParameter("Eamil", user.Email));
            Parm.Add(new ReportParameter("Code", user.Code));
            Parm.Add(new ReportParameter("Phone", user.Phone));
            Parm.Add(new ReportParameter("SSN", user.SSN));
            Parm.Add(new ReportParameter("College", user.College));
            Parm.Add(new ReportParameter("Section", user.Section));
            Parm.Add(new ReportParameter("Degree", user.Degree));
            Parm.Add(new ReportParameter("JobState", user.JobState));
            Parm.Add(new ReportParameter("DateStart", course.DateStart.ToString()));
            Parm.Add(new ReportParameter("DateEnd", course.DateEnd.ToString()));
            Parm.Add(new ReportParameter("CourseName", course.Name));
            lr.SetParameters(Parm);
            string reportType = "PDF";
            string mimeType;
            string encoding;
            string fileNameExtension;            



            string deviceInfo =

            "<DeviceInfo>" +
            "  <OutputFormat>" + "PDF" + "</OutputFormat>" +
            "  <PageWidth>8.5in</PageWidth>" +
            "  <PageHeight>11in</PageHeight>" +
            "  <MarginTop>0.5in</MarginTop>" +
            "  <MarginLeft>1in</MarginLeft>" +
            "  <MarginRight>1in</MarginRight>" +
            "  <MarginBottom>0.5in</MarginBottom>" +
            "</DeviceInfo>";

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            renderedBytes = lr.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings);
            return File(renderedBytes, mimeType);
        }
        //follow application
        [HttpGet]
        public ActionResult FollowApplication()
        {
            return View();
        }
        public ActionResult FindUser(string search)
        {
            var user = DB.Applicants.Where(a => a.Code == search || search == null).ToList();
            foreach (var item in user)
            {
                if (item.State == 1 || item.State == 2)
                {
                    ViewBag.State = item.State;
                }
            }
            return View(user);
        }
        //تأكيد الحجز عن طريق رفع الصور
        [HttpGet]
        public ActionResult Regester(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant user = DB.Applicants.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        [HttpPost]
        public ActionResult Regester(Applicant user, HttpPostedFileBase FormImg, HttpPostedFileBase PaymentImg, HttpPostedFileBase StatusImg)
        {
            if (true)
            {
                int id = user.ApplicantId;
                Applicant U = DB.Applicants.Find(id);

                //int courseid = user.CourseId;
                //Course C = DB.Courses.Single(A => A.CourseId == courseid);
                //int seats = Convert.ToInt32(C.SeatBooked);
                //C.SeatBooked = seats + 1;

                //save form image
                string Path1_1 = Path.Combine(Server.MapPath("~/Upload/FormPhotos"), FormImg.FileName);
                string Extension1 = Path.GetExtension(Path1_1);
                string path1_2 = Path.Combine(Server.MapPath("~/Upload/FormPhotos"), id + Extension1);
                FormImg.SaveAs(path1_2);
                string Domain = ConfigurationManager.AppSettings["Domain"].ToString();
                U.Form = Domain + "/Upload/FormPhotos/" + id + Extension1;

                //save payment image
                string Path2_1 = Path.Combine(Server.MapPath("~/Upload/PayPhotos"), PaymentImg.FileName);
                string Extension2 = Path.GetExtension(Path2_1);
                string path2_2 = Path.Combine(Server.MapPath("~/Upload/PayPhotos"), id + Extension2);
                PaymentImg.SaveAs(path2_2);                
                U.Payment = Domain + "/Upload/PayPhotos/" + id + Extension2;

                //save staatus image
                string Path3_1 = Path.Combine(Server.MapPath("~/Upload/StatusPhotos"), StatusImg.FileName);
                string Extension3 = Path.GetExtension(Path3_1);
                string path3_2 = Path.Combine(Server.MapPath("~/Upload/StatusPhotos"), id + Extension3);
                StatusImg.SaveAs(path3_2);
                U.Status = Domain + "/Upload/StatusPhotos/" + id + Extension3;

                //change the state when upload imgaes
                U.State = 1;
                DB.SaveChanges();

                int courseid = U.CourseId;
                Course C = DB.Courses.Single(A => A.CourseId == courseid);
                DateTime date = new DateTime();
                date = Convert.ToDateTime(C.DateStart);
                int count = DB.Applicants.Count(A => A.CourseId == courseid && A.State == 1 || A.State == 2 && A.CourseStart == date);
                C.SeatBooked = count;
                DB.SaveChanges();

                return RedirectToAction("Index");
            }
        }
        //delay the Application
        [HttpGet]
        public ActionResult Delay(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant user = DB.Applicants.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        [HttpPost]
        public ActionResult Delay(Applicant user)
        {
            int id = user.ApplicantId;

            var u = DB.Applicants.SingleOrDefault(A => A.ApplicantId == id);
            DateTime courseStart = Convert.ToDateTime(u.CourseStart);
            int days;
            days = DateTime.Now.Subtract(courseStart).Days;
            if (days <= 2)
            {                
                return RedirectToAction("Delay", id);
            }
            else
            {

                Applicant U = DB.Applicants.Find(id);
                U.State = 3;
                DB.SaveChanges();

                int courseid = U.CourseId;
                Course C = DB.Courses.Single(A => A.CourseId == courseid);
                DateTime date = new DateTime();
                date = Convert.ToDateTime(C.DateStart);
                int count = DB.Applicants.Count(A => A.CourseId == courseid && A.State == 1 || A.State == 2 && A.CourseStart == date);
                C.SeatBooked = count;
                DB.SaveChanges();
                return RedirectToAction("Index");
            }

        }
        [HttpGet]
        public ActionResult Cancel(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant user = DB.Applicants.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        [HttpPost]
        public ActionResult Cancel(Applicant user)
        {
            if (true)
            {
                int id = user.ApplicantId;
                Applicant U = DB.Applicants.Find(id);
                U.State = 3;
                DB.SaveChanges();
                return RedirectToAction("Index");
            }

        }
        //this get the pdf file that contains the programs of the center
        public ActionResult ProgramMatrix()
        {
            //مصفوفة البرامج
            return View();
        }
    }
}