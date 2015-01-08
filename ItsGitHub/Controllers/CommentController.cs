using ItsGitHub.Models;
using Postal;
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

            // Send email to student
            dynamic email = new Email("Comment");
            email.To = "bla@example.com";
            email.CommentQuote = comment.Content;
            email.CommentLink = String.Format("http://{0}{1}/{2}", System.Web.HttpContext.Current.Request.Url.Authority, "/Assignment/Details", assignmentId);
            email.Send();

            return RedirectToAction("Details", "Assignment", new { id = assignmentId});
        }

        private ItsGitHubContext db = new ItsGitHubContext();
    }
}