using ItsGitHub.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ItsGitHub.Controllers
{
    public class AssignmentController : Controller
    {
        public ActionResult Index()
        {
            var assignments = db.Assignment;
            return View(assignments);
        }

        public ActionResult Create()
        {
            return View();
        }
        //Response
        public ActionResult Details(int id)
        {
            AssignmentViewModel assignmentViewModel = new AssignmentViewModel();
            var assignments = db.Assignment;
            var assignment = assignments.SingleOrDefault(a => a.Id == id);

            // Get comments for assignments as well
            assignmentViewModel.Assignment = assignment;
            assignmentViewModel.Responses = assignment.Responses;

            return View(assignmentViewModel);
        }

        [HttpPost]
        public ActionResult Create(Assignment assignment)
        {
            
            db.Assignment.Add(assignment);
            db.SaveChanges();

            return RedirectToAction("Details", "Assignment", new { id = assignment.Id });
        }




        private ItsGitHubContext db = new ItsGitHubContext();
    }
}