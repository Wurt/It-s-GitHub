using ItsGitHub.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ItsGitHub.Controllers
{
    public class CommentController : Controller
    {
        private int _assignmentId;
        public ActionResult Add(int assignmentId)
        {
            _assignmentId = assignmentId;
            return View();
        }

        [HttpPost]
        public ActionResult Add(int assignmentId, Comment comment)
        {
            comment.AssignmentId = assignmentId;
            db.Comment.Add(comment);
            db.SaveChanges();

            return RedirectToAction("Details", "Assignment", new { id = assignmentId});
        }

        private ItsGitHubContext db = new ItsGitHubContext();
    }
}