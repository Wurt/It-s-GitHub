using System.Data.Entity;
using System.Management.Instrumentation;
using ItsGitHub.Models;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;


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
        //Response
        public ActionResult Details(int id)
        {
            AssignmentViewModel assignmentViewModel = new AssignmentViewModel();
            var assignments = db.Assignment;
            var assignment = assignments.SingleOrDefault(a => a.Id == id);

            assignmentViewModel.Assignment = assignment;
            assignmentViewModel.Responses = assignment.Responses;

            return View(assignmentViewModel);
        }

        [HttpPost]
        public ActionResult Create(Assignment assignment)
        {
            var currentUser = new UserManager<AppUser>(new UserStore<AppUser>(new AppDbContext())).FindById(User.Identity.GetUserId());
            assignment.CreatorName = currentUser.FullName;
            db.Assignment.Add(assignment);
            db.SaveChanges();

            return RedirectToAction("Details", "Assignment", new { id = assignment.Id });
        }




        private ItsGitHubContext db = new ItsGitHubContext();
    }
}