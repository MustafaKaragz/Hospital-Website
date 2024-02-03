using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using HospitalMS.Models;

namespace HospitalMS.Controllers
{
    public class DoctorsController : Controller
    {
        [HttpGet]
        public ActionResult DoctorLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DoctorLogin(DoctorLogin model)
        {
            if (ModelState.IsValid)
            {
                using (var dc = new HospitalDBContextEntities())
                {
                    var user = dc.Doctors1.FirstOrDefault(u => u.Email == model.Email);

                    if (user != null)
                    {
                        FormsAuthentication.SetAuthCookie(model.Email, false);

                        
                        return RedirectToAction("Index", "Prescription");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid e-mail or password.");
                    }
                }
            }

            
            return View(model);
        }
    }
}
