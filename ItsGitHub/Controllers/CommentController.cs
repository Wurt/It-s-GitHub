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
            _db.Comment.Add(comment);
            _db.SaveChanges();

            // Send email
            dynamic email = new Email("Comment");
            email.To = "bla@example.com";
            email.CommentQuote = comment.Content;
            email.CommentLink = String.Format("http://{0}{1}/{2}", System.Web.HttpContext.Current.Request.Url.Authority, "/Response/Details", responseId);
        //    email.Send();

            return RedirectToAction("Details", "Response", new { id = responseId });
        }

        private readonly ItsGitHubContext _db = new ItsGitHubContext();
    }
}
