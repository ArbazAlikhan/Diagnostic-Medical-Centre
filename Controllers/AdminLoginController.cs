using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiagnosticMedical.Models;

namespace DiagnosticMedical.Controllers
{
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection formData)
        {
            if ((formData["UserId"] == null) || (formData["UserId"] == "") || (formData["UserId"] == " "))
            {
                ViewBag.ValidationMessage = "User Id cannot be blank.";
            }
            else if ((formData["Password"] == null) || (formData["Password"] == "") || (formData["Password"] == " "))
            {
                ViewBag.ValidationMessage = "Password cannot be blank.";
            }
            else
            {
                int userId = Convert.ToInt32(formData["UserId"]);
                string password = formData["Password"];
                DBContext AdminLogin = new DBContext();
                foreach (var item in AdminLogin.Admins)
                {
                    if ((item.VendorId == userId) && (item.Password == password))
                    {
                        Session["UserId"] = item.VendorId;
                        Session["Password"] = item.Password;

                        return RedirectToAction("AdminHome");
                    }
                    else
                    {
                        ViewBag.ValidationMessage = "Invalid User Id (or) Incorrect Password.";
                        return View("Login");
                    }

                }
            }
            return View();
        }
        public ActionResult AdminHome()
        {
            if ((Session["UserId"] != null) || (Session["Password"] != null))
            {
                ViewBag.ValidationMessage = "Login Success";
                return View("AdminHome");
            }
            else
            {
                return RedirectToAction("Login");
            }

        }


        DBContext viewTestsContext = new DBContext();

        public ActionResult PatientIdsList()
        {
            if (Session["UserId"] != null)
            {
                List<BookAppointment> appointmentsList = viewTestsContext.BookAppointments.Where(m => m.Status.Equals("Approved")).ToList();
                return View(appointmentsList);
            }
            else
            {
                return RedirectToAction("Login");
            }

        }
        
        public ActionResult TestResultsUpdate(int patientId)
        {
            if (Session["UserId"] != null)
            {
                var patientDetails = viewTestsContext.BookAppointments.Find(patientId);
                var patientAge = viewTestsContext.Patients.Find(patientDetails.AppointmentId);
                ViewBag.AppointmentId = patientDetails.AppointmentId;
                ViewBag.PatientId = patientDetails.PatientId;
                ViewBag.DoctorId = patientDetails.DoctorId;
                ViewBag.Date = patientDetails.SelectDate;
                ViewBag.MedicareService = patientDetails.MedicareService;
                return View();

            }
            else
            {
                return RedirectToAction("Login");
            }

        }

        public ActionResult SaveTestResults()
        {
            if (Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        [HttpPost]
        public ActionResult SaveTestResults(TestResult testResults, FormCollection formData)
        {
            if (Session["UserId"] != null)
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.ValidationMessage = "Test results updated successfully..";
                    return View("TestResultsUpdate");
                }
                else
                {
                    foreach (var item in viewTestsContext.TestResults)
                    {
                        if (item.PatientId == Int32.Parse(formData["PatientId"]) && item.MedicareService == formData["MedicareService"])
                        {
                            ViewBag.ValidationMessage = "Test Details already updated.";
                            return View("TestResultsUpdate");
                        }
                    }
                    int patientId = Int32.Parse(formData["PatientId"]);
                    string medicareService = formData["MedicareService"];
                    viewTestsContext.TestResults.Add(testResults);
                    viewTestsContext.SaveChanges();
                    ViewBag.ValidationMessage = "Test results updated successfully.";
                    return View("TestResultsUpdate");
                }

            }
            else
            {
                return RedirectToAction("Login");
            }

        }

    }
}