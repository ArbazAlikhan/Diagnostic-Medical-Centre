using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using DiagnosticMedical.Models;

namespace DiagnosticMedical.Controllers
{
    public class PatientLoginController : Controller
    {
        // GET: PatientLogin
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
                DBContext patientLogin = new DBContext();
                foreach (var item in patientLogin.Patients)
                {
                    if ((item.PatientId == userId) && (item.Password == password) && (item.Status == "Accepted"))
                    {
                        Session["UserId"] = item.PatientId;
                        Session["Password"] = item.Password;

                        return RedirectToAction("PatientHome");
                    }
                    else
                    {
                        ViewBag.ValidationMessage = "Invalid User Id (or) Incorrect Password(or) The Request is Pending with Admin.";

                    }

                }
            }
            return View("Login");
        }
        public ActionResult PatientHome(Patient patient)
        {
            if ((Session["UserId"] != null) || (Session["Password"] != null))
            {
                ViewBag.SucessMessage = "Login SucessFull";

                return View("PatientHome");
            }
            else
            {
                return RedirectToAction("Login");
            }

        }

        DBContext viewDetailsContext = new DBContext();

        public ActionResult Medicaresview()
        {
            List<Medicare> medicareIdList = (from medicareservices in viewDetailsContext.Medicares select medicareservices).ToList();
            return View(medicareIdList);
        }
        public ActionResult Medicareservices(int serviceId)
        {

            int medicareId = serviceId;
            var serviceDetails = viewDetailsContext.Medicares.Find(medicareId);
            ViewBag.MedicareServiceId = serviceDetails.MedicareId;
            ViewBag.DoctorId = serviceDetails.DoctorId;
            ViewBag.MedicareServiceName = serviceDetails.MedicareServiceName;
            ViewBag.Eligibility = serviceDetails.Eligibility;
            return View();
        }

        public ActionResult Doctorsview()
        {
            List<Doctor> DoctorIdList = (from doctors in viewDetailsContext.Doctors select doctors).ToList();
            return View(DoctorIdList);
        }
        public ActionResult DoctorsList(int serviceId)
        {

            int medicareId = serviceId;
            var serviceDetails = viewDetailsContext.Doctors.Find(medicareId);
            ViewBag.DoctorId = serviceDetails.DoctorId;
            ViewBag.FirstName = serviceDetails.FirstName;
            ViewBag.LastName = serviceDetails.LastName;
            ViewBag.Age = serviceDetails.Age;
            ViewBag.Gender = serviceDetails.Gender;
            ViewBag.ContactNumber = serviceDetails.ContactNumber;
            return View();
        }


        public ActionResult Agentsview()
        {
            List<Agent> agentIdList = (from agents in viewDetailsContext.Agents select agents).ToList();
            return View(agentIdList);
        }
        public ActionResult AgentsList(int serviceId)
        {

            int medicareId = serviceId;
            var serviceDetails = viewDetailsContext.Agents.Find(medicareId);
            ViewBag.AgentId = serviceDetails.AgentId;
            ViewBag.FirstName = serviceDetails.FirstName;
            ViewBag.LastName = serviceDetails.LastName;
            ViewBag.Age = serviceDetails.Age;
            ViewBag.Gender = serviceDetails.Gender;
            ViewBag.ContactNumber = serviceDetails.ContactNumber;
            return View();
        }

        DBContext listDetailscontext = new DBContext();
        public ActionResult TestResultList()
        {
            if (Session["UserId"] != null)
            {
                int patientId = Int32.Parse(Session["UserId"].ToString());
                List<TestResult> testResults = listDetailscontext.TestResults.Where(m => m.PatientId.Equals(patientId)).ToList();
                var patientDetails = listDetailscontext.Patients.Find(patientId);
                ViewBag.PatientFirstName = patientDetails.FirstName;
                ViewBag.PatientLastName = patientDetails.LastName;
                ViewBag.PatientGender = patientDetails.Gender;
                ViewBag.PatientAge = patientDetails.Age;
                return View(testResults);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        public ActionResult DetailsList(int testId)
        {
            if (Session["UserId"] != null)
            {
                List<TestResult> testResults = listDetailscontext.TestResults.Where(m => m.TestId.Equals(testId)).ToList();
                return View(testResults);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}
