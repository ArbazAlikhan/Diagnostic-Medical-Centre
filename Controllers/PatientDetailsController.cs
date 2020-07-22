using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiagnosticMedical.Models;

namespace DiagnosticMedical.Controllers
{
    public class PatientDetailsController : Controller
    {
        // GET: PatientDetails
        public ActionResult patientDetails()
        {
            DBContext contextObject = new DBContext();
            List<Patient> patientsList = (from patients in contextObject.Patients select patients).ToList();
            return View(patientsList);
        }


        public ActionResult AcceptPatient(int id)
        {
            DBContext contextObject = new DBContext();
            var acceptStatus = contextObject.Patients.Find(id);
            acceptStatus.Status = "Accepted";
            contextObject.SaveChanges();
            return RedirectToAction("patientDetails");
        }


        public ActionResult RejectPatient(int id)
        {
            DBContext contextObject = new DBContext();
            var rejectStatus = contextObject.Patients.Find(id);
            rejectStatus.Status = "Rejected";
            contextObject.SaveChanges();
            return RedirectToAction("patientDetails");
        }
    }
}