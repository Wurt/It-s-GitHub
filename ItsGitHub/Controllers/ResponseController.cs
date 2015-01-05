using ItsGitHub.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ItsGitHub.Controllers
{
    public class ResponseController : Controller
    {
        private int _assignmentId;
        public ActionResult Add(int assignmentId)
        {
            _assignmentId = assignmentId;
            return View();
        }

        [HttpPost]
        public ActionResult Add(int assignmentId, Response response)
        {
            response.AssignmentId = assignmentId;
            db.Response.Add(response);
            db.SaveChanges();

            return RedirectToAction("Details", "Assignment", new { id = assignmentId});
        }

        private ItsGitHubContext db = new ItsGitHubContext();
    }
}