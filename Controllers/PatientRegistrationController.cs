using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiagnosticMedical.Models;
using System.Text.RegularExpressions;
using System.Text;
using System.Security.Cryptography;

namespace DiagnosticMedical.Controllers
{
    public class PatientRegistrationController : Controller
    {
        // GET: PatientRegistration
        public ActionResult PatientRegistrationForm()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PatientRegistrationForm(Patient patient, FormCollection formData)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ValidationMessage = "Please update the highlighted mandatory field(s)";
                return View();
            }
            else
            {
                DBContext patientRegistration = new DBContext();
                foreach (var item in patientRegistration.Patients)
                {
                    if (item.PatientId == Int64.Parse(formData["PatientId"]))
                    {
                        ViewBag.ValidationMessage = "Patient Id already exists.";
                    }
                }
                patientRegistration.Patients.Add(patient);
                patientRegistration.SaveChanges();
                ViewBag.ValidationMessage = "Your details are submitted succesfully.";
                return View();
            }
        }



    }
}