using Microsoft.AspNet.Identity;
using Netmennt.Models;
using Netmennt.ViewModels;
using System.Web.Mvc;
using System.Linq;

namespace Netmennt.Controllers
{
    public class DashboardController : Controller
    {
        private Context db = new Context();
        // GET: Dashboard
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId<int>();
            var model = new DashboardViewModel();
            var myComponents = from a in db.Components
                               where a.CreatorId == userId
                               select a;

            var enrolledFlermigans = from a in db.Enrollments
                                     where a.EnrolleeId == userId
                                     join b in db.Components on a.EnrolledId equals b.ComponentId
                                     select b;
            model.MyComponents = myComponents;
            model.EnrolledComponents = enrolledFlermigans;
            return View(model);
        }

        public ActionResult Student()
        {
            return PartialView();
        }

        public ActionResult Teacher()
        {
            return PartialView();
        }

        public ActionResult School()
        {
            return PartialView();
        }
    }
}