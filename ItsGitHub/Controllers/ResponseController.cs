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


        public ActionResult CommentDetails(int id)
        {
            AssignmentViewModel assignmentViewModel = new AssignmentViewModel();
            var responses = db.Response;
          //  var Comments = db.Comment;
            
            var response = responses.Where(a => a.ID == id).SingleOrDefault();

            // Get comments for assignments as well
            // var responses = db.Response.Where(c => c.AssignmentId == id).ToList();
       
            var comments = db.Comment.Where(c => c.ResponseId == id).ToList();
            assignmentViewModel.Response = response;
            assignmentViewModel.Comments = comments;
         //  assignmentViewModel.Responses = responses;
            assignmentViewModel.Responses = new List<Response>();
            assignmentViewModel.Assignment = new Assignment();

            return View(assignmentViewModel);
        }


        private ItsGitHubContext db = new ItsGitHubContext();
    }
}