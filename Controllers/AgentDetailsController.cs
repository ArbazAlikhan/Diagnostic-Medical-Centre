using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiagnosticMedical.Models;

namespace DiagnosticMedical.Controllers
{
    public class AgentDetailsController : Controller
    {
        // GET: AgentDetails
        public ActionResult agentDetails()
        {
            DBContext contextObject = new DBContext();
            List<Agent> agentsList = (from agents in contextObject.Agents select agents).ToList();
            return View(agentsList);
        }


        public ActionResult AcceptAgent(int id)
        {
            DBContext contextObject = new DBContext();
            var acceptStatus = contextObject.Agents.Find(id);
            acceptStatus.Status = "Accepted";
            contextObject.SaveChanges();
            return RedirectToAction("agentDetails");
        }


        public ActionResult RejectAgent(int id)
        {
            DBContext contextObject = new DBContext();
            var rejectStatus = contextObject.Agents.Find(id);
            rejectStatus.Status = "Rejected";
            contextObject.SaveChanges();
            return RedirectToAction("agentDetails");
        }
    }
}