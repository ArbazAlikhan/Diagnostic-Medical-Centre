using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiagnosticMedical.Models;

namespace DiagnosticMedical.Controllers
{
    public class BookAppointmentDetailsController : Controller
    {
        // GET: BookAppointmentDetails
        public ActionResult bookAppointmentDetails()
        {
            DBContext contextObject = new DBContext();
            List<BookAppointment> bookAppointmentsList = (from bookAppointments in contextObject.BookAppointments select bookAppointments).ToList();
            return View(bookAppointmentsList);
        }


        public ActionResult AcceptBookAppointment(int id)
        {
            DBContext contextObject = new DBContext();
            var acceptStatus = contextObject.BookAppointments.Find(id);
            acceptStatus.Status = "Approved";
            contextObject.SaveChanges();
            return RedirectToAction("bookAppointmentDetails");
        }


        public ActionResult RejectBookAppointment(int id)
        {
            DBContext contextObject = new DBContext();
            var rejectStatus = contextObject.BookAppointments.Find(id);
            rejectStatus.Status = "Rejected";
            contextObject.SaveChanges();
            return RedirectToAction("bookAppointmentDetails");
        }
    }
}