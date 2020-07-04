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
    //this will controll الاسئلة الشائعة التى تظهر الى المستخدم
    
    public class FAQController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FAQ        
        public ActionResult Index()
        {
            return View(db.FAQs.ToList());
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