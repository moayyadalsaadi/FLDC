using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Graduation_Project.Controllers
{
    public class AdminHomeController : Controller
    {
        // GET: AdminHome
        //admin home الصفحة الرئيسية للادمن
        public ActionResult Index()
        {
            return View();
        }
    }
}