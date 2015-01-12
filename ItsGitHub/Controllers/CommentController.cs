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
        private int _responseId;
        public ActionResult Add(int responseId)
        {
            _responseId = responseId;
            return View();
        }

        [HttpPost]
        public ActionResult Add(int responseId, Comment comment)
        {
            comment.ResponseId = responseId;
            db.Comment.Add(comment);
            db.SaveChanges();

            return RedirectToAction("CommentDetails", "Response", new { id = responseId });
        }

        private ItsGitHubContext db = new ItsGitHubContext();
    }
}
