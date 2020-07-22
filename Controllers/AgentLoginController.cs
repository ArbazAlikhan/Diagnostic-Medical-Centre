using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiagnosticMedical.Models;

namespace DiagnosticMedical.Controllers
{
    public class AgentLoginController : Controller
    {
        // GET: AgentLogin
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
                DBContext AgentLogin = new DBContext();
                foreach (var item in AgentLogin.Agents)
                {
                    if ((item.AgentId == userId) && (item.Password == password) && (item.Status == "Accepted"))
                    {
                        Session["UserId"] = item.AgentId;
                        Session["Password"] = item.Password;

                        return RedirectToAction("AgentHome");
                    }
                    else
                    {
                        ViewBag.ValidationMessage = "Invalid User Id (or) Incorrect Password(or) The Request is Pending with Admin.";

                    }
                }
            }
            return View("Login");
        }
        public ActionResult AgentHome()
        {
            if ((Session["UserId"] != null) || (Session["Password"] != null))
            {
                ViewBag.ValidationMessage = "Login SucessFull";
                return View("AgentHome");
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


       // DBContext viewDetailsContext = new DBContext();
        public ActionResult Appointmentview()
        {
            List<BookAppointment> viewAppointmentList = (from appointments in viewDetailsContext.BookAppointments select appointments).ToList();
            return View(viewAppointmentList);
        }

        public ActionResult AppointmentsList(int appinId)
        {

            int appointmentId = appinId;
            var appointmentDetails = viewDetailsContext.BookAppointments.Find(appointmentId);
            ViewBag.AppointmentId = appointmentDetails.AppointmentId;
            ViewBag.DoctorName = appointmentDetails.DoctorName;
            ViewBag.MedicareService = appointmentDetails.MedicareService;
            ViewBag.SelectDate = appointmentDetails.SelectDate;
            return View();
        }

    }
}