using Graduation_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Graduation_Project.Controllers
{
    [Authorize]
    public class AdminUserQueryController : Controller
    {
        // GET: AdminUserQuery
        private ApplicationDbContext DB = new ApplicationDbContext();
        public ActionResult GetUser()
        {
            return View();
        }
        public ActionResult FindUser(string search)
        {
            var user = DB.Applicants.SingleOrDefault(a => a.Code == search || search == null);            
            return View(user);            
        }

    }
}