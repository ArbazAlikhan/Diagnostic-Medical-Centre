using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiagnosticMedical.Models;

namespace DiagnosticMedical.Controllers
{
    public class DoctorDetailsController : Controller
    {
        // GET: DoctorDetails
        public ActionResult doctorDetails()
        {
            DBContext contextObject = new DBContext();
            List<Doctor> doctorsList = (from doctors in contextObject.Doctors select doctors).ToList();
            return View(doctorsList);
        }


        public ActionResult AcceptDoctor(int id)
        {
            DBContext contextObject = new DBContext();
            var acceptStatus = contextObject.Doctors.Find(id);
            acceptStatus.Status = "Accepted";
            contextObject.SaveChanges();
            return RedirectToAction("doctorDetails");
        }


        public ActionResult RejectDoctor(int id)
        {
            DBContext contextObject = new DBContext();
            var rejectStatus = contextObject.Doctors.Find(id);
            rejectStatus.Status = "Rejected";
            contextObject.SaveChanges();
            return RedirectToAction("doctorDetails");
        }
    }
}