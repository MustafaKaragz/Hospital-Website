﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalMS.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult AboutUs()
        {
            return View();
        }

        
        public ActionResult ContactUs()
        {
            return View();
        }

        public ActionResult Doctors1()
        {
            return View();
        }

        public ActionResult Gallery1()
        {
            return View();
        }

        public ActionResult MedicalUnits1()
        {
            return View();
        }
    }
}