using ItsGitHub.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Postal;
using System;
using System.Web.Mvc;

namespace ItsGitHub.Controllers
{
    public class CommentController : Controller
    {
        public ActionResult Add(int responseId)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(int responseId, Comment comment)
        {
            var currentUser =
                new UserManager<AppUser>(new UserStore<AppUser>(new AppDbContext())).FindById(
                    User.Identity.GetUserId());
            comment.CreatorName = currentUser.FullName;
            comment.ResponseId = responseId;
            _db.Comment.Add(comment);
            _db.SaveChanges();

            // Send email
            dynamic email = new Email("Comment");
            email.To = "bla@example.com";
            email.CommentQuote = comment.Content;
            email.CommentLink = String.Format("http://{0}{1}/{2}",
                System.Web.HttpContext.Current.Request.Url.Authority, "/Response/Details", responseId);
            //email.Send();

            return RedirectToAction("Details", "Response", new { id = responseId });
        }

        private readonly ItsGitHubContext _db = new ItsGitHubContext();
    }
}
