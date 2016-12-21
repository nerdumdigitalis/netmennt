using Microsoft.AspNet.Identity;
using Netmennt.Entities;
using Netmennt.Enums;
using Netmennt.Models;
using Netmennt.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Netmennt.Controllers
{
    public class ComponentsController : Controller
    {
        private Context db = new Context();

        // GET: Flermigans
        public ActionResult Index()
        {
            return View(db.Components);
        }


        public ActionResult CreateOrUpdateCourse(int? courseId)
        {
            var model = new CreateCourseViewModel();

            Component course;
            var userId = User.Identity.GetUserId<int>();
            if (!courseId.HasValue)
            {
                course = new Component
                {
                    CreatorId = Convert.ToInt32(User.Identity.GetUserId()),
                    Created = DateTime.Now,
                    Type = ComponentType.Course
                };

                db.Components.Add(course);

                var enrollment = new Enrollment
                {
                    DateStart = DateTime.Now,
                    EnrolledId = userId,
                    EnrolledType = ComponentType.User,
                    EnrolleeId = course.ComponentId,
                    EnrolleeType = ComponentType.Course,
                    RoleId = (int)Role.Teacher

                };

                db.Enrollments.Add(enrollment);

                db.SaveChanges();

                model.Course = course;
                model.Topics = new List<Component>();


            }
            else
            {
                course = (from a in db.Components
                          where a.ComponentId == courseId
                          select a).FirstOrDefault();

                var topics = from a in db.Enrollments
                             where a.EnrolledId == courseId && a.EnrolleeType == ComponentType.Topic
                             join b in db.Components on a.EnrolleeId equals b.ComponentId
                             select b;

                course.ImagePath = System.IO.File.Exists(Server.MapPath("/Resources/" + course.ComponentId + ".jpg")) ? ("../Resources/" + course.ComponentId + ".jpg") : "../Resources/NoImage.jpg";
                foreach (var topic in topics)
                {
                    topic.ImagePath = System.IO.File.Exists("../Resources/" + course.ComponentId + ".jpg") ? ("../Resources/" + course.ComponentId + ".jpg") : "../Resources/NoImage.jpg";
                    topic.EnrollmentId = course.ComponentId;
                }
                model.Course = course;
                model.Topics = topics;

            }

            return View(model);
        }
        [HttpPost]
        public ActionResult CreateComponent(string componentType, int enrollmentId, string enrollmentType)
        {
            var component = new Component
            {
                CreatorId = Convert.ToInt32(User.Identity.GetUserId()),
                Type = (ComponentType)Enum.Parse(typeof(ComponentType), componentType),
                EnrollmentId = enrollmentId
            };

            db.Components.Add(component);
            db.SaveChanges();

            var enrollment = new Enrollment
            {
                DateStart = DateTime.Now,
                EnrolledId = enrollmentId,
                EnrolledType = (ComponentType)Enum.Parse(typeof(ComponentType), enrollmentType),
                EnrolleeId = component.ComponentId,
                EnrolleeType = (ComponentType)Enum.Parse(typeof(ComponentType), componentType),
                RoleId = (int)Role.Teacher
            };

            db.Enrollments.Add(enrollment);

            db.SaveChanges();

            string viewName = "";

            switch ((ComponentType)Enum.Parse(typeof(ComponentType), componentType))
            {
                case ComponentType.Course:
                    viewName = "CreateorUpdateCourse";
                    break;
                case ComponentType.Topic:
                    viewName = "CreateTopic";
                    break;
                case ComponentType.Module:
                    viewName = "CreateModule";
                    break;
            }

            return PartialView(viewName, component);
        }

        public ActionResult CreateOrUpdateModule(int? topicId)
        {
            var model = (from a in db.Enrollments
                         where a.EnrolledId == topicId && a.EnrolleeType == ComponentType.Module
                         join b in db.Components on a.EnrolleeId equals b.ComponentId
                         select b).ToList();

            model.ForEach(x => x.EnrollmentId = topicId.Value);
            return PartialView(model);
        }

        public void SaveName(int componentId, string name)
        {
            var component = (from a in db.Components
                             where a.ComponentId == componentId
                             select a).FirstOrDefault();

            component.Name = name;
            db.SaveChanges();
        }

        public void SaveDescription(int componentId, string description)
        {
            var component = (from a in db.Components
                             where a.ComponentId == componentId
                             select a).FirstOrDefault();

            component.Description = description;
            db.SaveChanges();
        }

        public JsonResult SaveVideoUrl(int componentId, string url)
        {
            try
            {
                var component = (from a in db.Components
                                 where a.ComponentId == componentId
                                 select a).FirstOrDefault();
                component.VideoUrl = url;
                db.SaveChanges();
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult SaveImage(int componentId)
        {
            try
            {
                var file = System.Web.HttpContext.Current.Request.Files;
                if (file != null && file.Count > 0 && file[0].ContentLength > 0)
                {
                    var physicalPath = Path.Combine(Server.MapPath("~/Resources"), componentId.ToString() + Path.GetExtension(file[0].FileName));
                    file[0].SaveAs(physicalPath);
                }
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {

                return Json(new { success = false }, JsonRequestBehavior.AllowGet);
            }


        }

        public ActionResult CreateOrUpdateClass(int? classId)
        {
            if (!classId.HasValue)
            {
                
            }
            else
            {

            }

            return View();
        }
      

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
