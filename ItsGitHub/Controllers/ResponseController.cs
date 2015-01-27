using ItsGitHub.Models;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ItsGitHub.Controllers
{
    public class ResponseController : Controller
    {

        public ActionResult Add(int assignmentId)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(int assignmentId, Response response)
        {
            var currentUser = new UserManager<AppUser>(new UserStore<AppUser>(new AppDbContext())).FindById(User.Identity.GetUserId());
            response.CreatorName = currentUser.FullName;
            response.AssignmentId = assignmentId;
            db.Response.Add(response);
            db.SaveChanges();

            return RedirectToAction("Details", "Assignment", new { id = assignmentId });
        }


        public ActionResult Details(int id)
        {
            AssignmentViewModel assignmentViewModel = new AssignmentViewModel();
            var response = db.Response.SingleOrDefault(a => a.Id == id);

            assignmentViewModel.Response = response;
            if (response != null) assignmentViewModel.Comments = response.Comments;

            return View(assignmentViewModel);
        }


        private ItsGitHubContext db = new ItsGitHubContext();
    }
}