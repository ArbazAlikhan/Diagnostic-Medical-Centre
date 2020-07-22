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
    public class MedicareServicesController : Controller
    {
        // GET: MedicareServices
        public ActionResult MedicareServicesForm()
        {
            return View();
        }
        [HttpPost]
        public ActionResult MedicareServicesForm(Medicare medicare, FormCollection formData)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ValidationMessage = "Please update the highlighted mandatory field(s)";
                return View();
            }
            else
            {
                DBContext medicareServices = new DBContext();
                foreach (var item in medicareServices.Medicares)
                {
                    if (item.MedicareId == Int32.Parse(formData["MedicareId"]))
                    {
                        ViewBag.ValidationMessage = "Medicare Id already exists.";
                    }
                }
                medicareServices.Medicares.Add(medicare);
                medicareServices.SaveChanges();
                ViewBag.ValidationMessage = "Your details are submitted succesfully.";
                return View();
            }
        }



    }
}