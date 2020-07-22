using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiagnosticMedical.Models;

namespace DiagnosticMedical.Controllers
{
    public class DoctorRegistrationController : Controller
    {
        // GET: DoctorRegistration
        public ActionResult DoctorRegistrationForm()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DoctorRegistrationForm(Doctor doctor, FormCollection formData)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ValidationMessage = "Please update the highlighted mandatory field(s)";
                return View();
            }
            else
            {
                DBContext doctorContext = new DBContext();
                foreach (var item in doctorContext.Doctors)
                {
                    if (item.DoctorId == Int32.Parse(formData["DoctorId"]))
                    {
                        ViewBag.ValidationMessage = "Doctor Id already exists.";
                    }
                }
                doctorContext.Doctors.Add(doctor);
                doctorContext.SaveChanges();
                ViewBag.ValidationMessage = "Your details are submitted succesfully.";
                return View();
            }
        }
    }
}