using Graduation_Project.Models;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Graduation_Project.Controllers
{
    //this will controll reports التقارير
    // state = 0
    // تقرير المقدمين 
    //state = 1
    // تقرير المقدمين ورفعو الصور
    //state = 2
    // تقرير المقدمين وتم الموافقة عليهم
    //state = 3
    // تقرير المؤجلين
    [Authorize]
    public class AdminReportController : Controller
    {
        // GET: AdminReport
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            //get all courses            
            return View(db.Courses.ToList());
        }
        //get the user who only applied whose state = 0 
        public ActionResult Applied(int? id)
        {
            //get the course
            Course course = db.Courses.SingleOrDefault(A => A.CourseId == id);            
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Report"), "AppliedReport.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return View("Index");
            }
            DateTime courseStart = Convert.ToDateTime(course.DateStart);
            List<Applicant> users = new List<Applicant>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                users = db.Applicants.Where(A => A.CourseId == id && A.State == 0 && A.CourseStart==courseStart.Date).ToList();
            }
            ReportDataSource rd = new ReportDataSource("MyDataset", users);
            lr.DataSources.Add(rd);
            ReportParameterCollection param = new ReportParameterCollection();
            param.Add(new ReportParameter("CourseName", course.Name));
            param.Add(new ReportParameter("StartDate", course.DateStart.ToString()));
            param.Add(new ReportParameter("EndDate", course.DateEnd.ToString()));
            lr.SetParameters(param);
            string reportType = "PDF";
            string mimeType;
            string encoding;
            string fileNameExtension;



            string deviceInfo =

            "<DeviceInfo>" +
            "  <OutputFormat>" + id + "</OutputFormat>" +
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
        //get the user who  applied and upload images whose state = 1
        public ActionResult FinishApplication(int? id)
        {
            //get the course
            Course course = db.Courses.SingleOrDefault(A => A.CourseId == id);
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Report"), "FinishApplicationReport.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return View("Index");
            }
            DateTime courseStart = Convert.ToDateTime(course.DateStart);
            List<Applicant> users = new List<Applicant>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                users = db.Applicants.Where(A => A.CourseId == id && A.State == 1 && A.CourseStart==courseStart.Date).ToList();
            }
            ReportDataSource rd = new ReportDataSource("MyDataset", users);
            lr.DataSources.Add(rd);
            ReportParameterCollection param = new ReportParameterCollection();
            param.Add(new ReportParameter("CourseName", course.Name));
            param.Add(new ReportParameter("StartDate", course.DateStart.ToString()));
            param.Add(new ReportParameter("EndDate", course.DateEnd.ToString()));
            lr.SetParameters(param);
            string reportType = "PDF";
            string mimeType;
            string encoding;
            string fileNameExtension;



            string deviceInfo =

            "<DeviceInfo>" +
            "  <OutputFormat>" + id + "</OutputFormat>" +
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
        //get the user who  applied and admin approve whose state = 2
        public ActionResult ConfirmApplication(int? id)
        {
            //get the course
            Course course = db.Courses.SingleOrDefault(A => A.CourseId == id);
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Report"), "ConfirmApplicationReport.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return View("Index");
            }
            DateTime courseStart = Convert.ToDateTime(course.DateStart);
            List<Applicant> users = new List<Applicant>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                users = db.Applicants.Where(A => A.CourseId == id && A.State == 2 && A.CourseStart==courseStart.Date).ToList();
            }
            ReportDataSource rd = new ReportDataSource("MyDataset", users);
            lr.DataSources.Add(rd);
            ReportParameterCollection param = new ReportParameterCollection();
            param.Add(new ReportParameter("CourseName", course.Name));
            param.Add(new ReportParameter("StartDate", course.DateStart.ToString()));
            param.Add(new ReportParameter("EndDate", course.DateEnd.ToString()));
            lr.SetParameters(param);
            string reportType = "PDF";
            string mimeType;
            string encoding;
            string fileNameExtension;



            string deviceInfo =

            "<DeviceInfo>" +
            "  <OutputFormat>" + id + "</OutputFormat>" +
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
        //get the user who  delay whose state = 3
        public ActionResult Delay(int? id)
        {
            //get the course
            Course course = db.Courses.SingleOrDefault(A => A.CourseId == id);
            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/Report"), "DelayReport.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                return View("Index");
            }
            DateTime courseStart = Convert.ToDateTime(course.DateStart);
            List<Applicant> users = new List<Applicant>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                users = db.Applicants.Where(A => A.CourseId == id && A.State == 3 && A.CourseStart==courseStart.Date).ToList();
            }
            ReportDataSource rd = new ReportDataSource("MyDataset", users);
            lr.DataSources.Add(rd);
            ReportParameterCollection param = new ReportParameterCollection();
            param.Add(new ReportParameter("CourseName", course.Name));
            param.Add(new ReportParameter("StartDate", course.DateStart.ToString()));
            param.Add(new ReportParameter("EndDate", course.DateEnd.ToString()));
            lr.SetParameters(param);
            string reportType = "PDF";
            string mimeType;
            string encoding;
            string fileNameExtension;



            string deviceInfo =

            "<DeviceInfo>" +
            "  <OutputFormat>" + id + "</OutputFormat>" +
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
    }
}