using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalMS.Models;


namespace HospitalMS.Controllers
{
    [Authorize]
    public class AppointmentsController : Controller
    {
        HospitalDBContextEntities db = new HospitalDBContextEntities();

        [HttpGet]
        [Authorize]
        public ActionResult MakeAppointment()
        {
            return View();
        }

    } 
}