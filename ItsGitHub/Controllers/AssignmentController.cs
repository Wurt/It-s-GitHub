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

        public ActionResult Details(int id)
        {
            AssignmentViewModel assignmentViewModel = new AssignmentViewModel();
            var assignments = db.Assignment;
            var assignment = assignments.Where(a => a.ID == id).SingleOrDefault();

            // Get comments for assignments as well
            var comments = db.Comment.Where(c => c.AssignmentId == id).ToList();

            assignmentViewModel.Assignment = assignment;
            assignmentViewModel.Comments = comments;

            return View(assignmentViewModel);
        }

        [HttpPost]
        public ActionResult Create(Assignment assignment)
        {
            db.Assignment.Add(assignment);
            db.SaveChanges();

            return RedirectToAction("Create");
        }

        private ItsGitHubContext db = new ItsGitHubContext();
    }
}