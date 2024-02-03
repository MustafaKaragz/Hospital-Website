using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HospitalMS.Models;

namespace HospitalMS.Controllers
{
    public class PrescriptionController : Controller
    {
        private HospitalDBContextEntities db = new HospitalDBContextEntities(); 

        
        // GET: Prescription
        public ActionResult Index()
        {
            var prescriptions = db.Prescriptions.ToList();
            return View(prescriptions);
        }

        // GET: Prescription/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prescription prescription = db.Prescriptions.Find(id);
            if (prescription == null)
            {
                return HttpNotFound();
            }
            return View(prescription);
        }

        // GET: Prescription/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Prescription/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PatientsName,PrescriptionDate,Dosage,Medicine,FrequencyOfUse,DoktorName,AdditionalMessage")] Prescription prescription)
        {
            if (ModelState.IsValid)
            {
                db.Prescriptions.Add(prescription);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(prescription);
        }

        // GET: Prescription/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Prescription prescription = db.Prescriptions.Find(id);

            if (prescription == null)
            {
                return HttpNotFound();
            }

            return View(prescription);
        }

        // POST: Prescription/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PatientsName,PrescriptionDate,Dosage,Medicine,FrequencyOfUse,DoktorName,AdditionalMessage")] Prescription prescription)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prescription).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(prescription);
        }

        // GET: Prescription/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Prescription prescription = db.Prescriptions.Find(id);

            if (prescription == null)
            {
                return HttpNotFound();
            }

            return View(prescription);
        }

        // POST: Prescription/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prescription prescription = db.Prescriptions.Find(id);

            if (prescription == null)
            {
                return HttpNotFound();
            }

            db.Prescriptions.Remove(prescription);
            db.SaveChanges();

            return RedirectToAction("Index");
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
