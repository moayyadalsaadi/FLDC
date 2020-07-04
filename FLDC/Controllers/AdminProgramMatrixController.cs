using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Graduation_Project.Controllers
{
    //this will return the pdf file of programs
    [Authorize]
    public class AdminProgramMatrixController : Controller
    {
        // GET: ProgramMatrix
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase pdffile)
        {
            try
            {
                // TODO: Add insert logic here
                if (pdffile!=null)
                {
                    string path = Path.Combine(Server.MapPath("~/ProgramPdfFiles/ProgramMatrix"), "1.pdf");
                    pdffile.SaveAs(path);
                }
                ViewBag.Message = "تم الحفظ بنجاح";
                return View();
            }
            catch
            {
                ViewBag.Message = "لم يتم الحفظ";
                return View();
            }
        }
        //// GET: ProgramMatrix/Create        
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: ProgramMatrix/Create
        //[HttpPost]
        //public ActionResult Create(HttpPostedFileBase pdffile)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here
        //        if (pdffile.ContentLength>0)
        //        {
        //            string p = Path.GetFullPath("~/ProgramPdfFiles");
        //            int x=p.Count();
        //            p.Remove(0, x);
        //            string path = Path.Combine(Server.MapPath("~/ProgramPdfFiles"), "ProgramMatrix.pdf");
        //            pdffile.SaveAs(path);
        //        }
        //        ViewBag.Message = "saved successfully";
        //        return View();
        //    }
        //    catch
        //    {
        //        ViewBag.Message = "Not saved successfully";
        //        return View();
        //    }
        //}
   
    }
}
