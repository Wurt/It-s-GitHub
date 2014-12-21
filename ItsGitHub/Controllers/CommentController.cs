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
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Comment comment)
        {
            db.Comment.Add(comment);
            db.SaveChanges();

            return RedirectToAction("Create");
        }

        private CommentContext db = new CommentContext();
    }
}