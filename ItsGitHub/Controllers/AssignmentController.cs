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
            var assignments = db.Assignment;
            var assignment = assignments.Where(a => a.ID == id).SingleOrDefault();

            return View(assignment);
        }

        [HttpPost]
        public ActionResult Create(Assignment assignment)
        {
            db.Assignment.Add(assignment);
            db.SaveChanges();

            return RedirectToAction("Create");
        }

        private AssignmentContext db = new AssignmentContext();
    }
}