﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Graduation_Project.Models;

namespace Graduation_Project.Controllers
{
    public class CenterAchievementController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CenterAchievement
        public ActionResult Index()
        {
            return View(db.CenterAchievements.Where(A=>A.Code==1).ToList());
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