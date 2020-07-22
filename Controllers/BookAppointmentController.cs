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
    public class BookAppointmentController : Controller
    {
        // GET: BookAppointment
        public ActionResult AppointmentForm()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AppointmentForm(BookAppointment bookAppointment, FormCollection formData)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ValidationMessage = "Please update the highlighted mandatory field(s)";
                return View();
            }
            else
            {
                DBContext bookappointment = new DBContext();
                DateTime dateofAppointment = DateTime.Parse(formData["SelectDate"]);
                if (dateofAppointment >= DateTime.Now.Date)
                {
                    bookappointment.BookAppointments.Add(bookAppointment);
                    bookappointment.SaveChanges();
                    ViewBag.ValidationMessage = "Your details are submitted succesfully.";
                    return View();
                }
                else
                {
                    ViewBag.ValidationMessage = "Please select Upcoming Dates.";
                    return View();
                }
            }
        }
    }
}