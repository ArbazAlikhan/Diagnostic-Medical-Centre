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
    public class AgentRegistrationController : Controller
    {
        // GET: PatientRegistration
        public ActionResult AgentRegistrationForm()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AgentRegistrationForm(Agent agent, FormCollection formData)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ValidationMessage = "Please update the highlighted mandatory field(s)";
                return View();
            }
            else
            {
                DBContext agentRegistration = new DBContext();
                foreach (var item in agentRegistration.Agents)
                {
                    if (item.AgentId == Int32.Parse(formData["AgentId"]))
                    {
                        ViewBag.ValidationMessage = "Agent Id already exists.";
                    }
                }
                agentRegistration.Agents.Add(agent);
                agentRegistration.SaveChanges();
                ViewBag.ValidationMessage = "Your details are submitted succesfully.";
                return View();
            }
        }



    }
}