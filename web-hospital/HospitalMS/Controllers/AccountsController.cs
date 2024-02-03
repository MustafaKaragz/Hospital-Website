using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using HospitalMS.Models;


namespace HospitalMS.Controllers
{
    public class AccountsController : Controller
    {
        

        // GET: Accounts
        [HttpGet]
        public ActionResult Login()
        {
            
            return View();
        }

        [HttpGet]
        public ActionResult Signup()
        {
            
            return View();
        }
      

        [HttpPost]
        public ActionResult Login(LoginView model)
        {
            if (ModelState.IsValid)
            {
                using (var dc = new HospitalDBContextEntities())
                {
                    var user = dc.Patients.FirstOrDefault(u => u.Email == model.Email);

                    if (user != null && user.Password == Crypto.Hash(model.Password))
                    {
                        FormsAuthentication.SetAuthCookie(model.Email, false); 
                        return RedirectToAction("Index", "Home"); 
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid e-mail or password.");
                    }
                }
            }

            
            return View(model);
        }





        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Signup([Bind(Exclude = "IsEmailVerified,ActivationCode")] Patients user)
        {
            bool Status = false;
            string message = "";

            
            if (ModelState.IsValid)
            {
                #region //Email is already exist
                var isExist = IsEmailExist(user.Email);
                if (isExist)
                {
                    ModelState.AddModelError("EmailExist", "Email already exists");
                    return View(user);
                }
                #endregion

                
                user.Password = Crypto.Hash(user.Password);
                user.ConfirmPassword = Crypto.Hash(user.ConfirmPassword);

                user.IsEmailVerified1 = false;

                #region //Save Data to DB
                using (HospitalDBContextEntities dc = new HospitalDBContextEntities())
                {
                    dc.Patients.Add(user);
                    dc.SaveChanges();

                    // No email verification and activation code sent
                    message = "Registration successfully done.";
                    Status = true;
                }
                #endregion
            }
            else
            {
                message = "Invalid Request";
            }

            ViewBag.Message = message;
            ViewBag.Status = Status;

            return View();
        }


        [NonAction]
        public bool IsEmailExist(string emailID)
        {
            using (HospitalDBContextEntities dc = new HospitalDBContextEntities()) 
            {
                var x = dc.Patients.Where(a => a.Email == emailID).FirstOrDefault();
                return x != null;
            }
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }


    }

   
}

