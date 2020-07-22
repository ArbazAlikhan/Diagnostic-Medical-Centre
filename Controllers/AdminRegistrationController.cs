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
    public class AdminRegistrationController : Controller
    {
        // GET: AdminRegistration
        public ActionResult AdminRegistrationForm()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminRegistrationForm(Admin admin, FormCollection formData)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ValidationMessage = "Please update the highlighted mandatory field(s)";
                return View();
            }
            else
            {
                DBContext adminRegistration = new DBContext();
                foreach (var item in adminRegistration.Admins)
                {
                    if (item.VendorId == Int32.Parse(formData["VendorId"]))
                    {
                        ViewBag.ValidationMessage = "VendorId already exists.";
                    }
                }
                adminRegistration.Admins.Add(admin);
                adminRegistration.SaveChanges();
                ViewBag.ValidationMessage = "Your details are submitted succesfully.";
                return View();
            }
        }



    }
}