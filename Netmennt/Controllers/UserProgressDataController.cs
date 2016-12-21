using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Netmennt.Entities;
using Netmennt.Models;

namespace Netmennt.Controllers
{
    public class UserProgressDataController : Controller
    {
        private Context db = new Context();

        // GET: UserProgressData
        public async Task<ActionResult> Index()
        {
            return View(await db.UserProgressData.ToListAsync());
        }

        // GET: UserProgressData/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProgressData userProgressData = await db.UserProgressData.FindAsync(id);
            if (userProgressData == null)
            {
                return HttpNotFound();
            }
            return View(userProgressData);
        }

        // GET: UserProgressData/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserProgressData/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "UserProgressDataId,UserId,DataReferenceId,DataReferenceType,Progress,Result,DateStarted,DateCompleted")] UserProgressData userProgressData)
        {
            if (ModelState.IsValid)
            {
                db.UserProgressData.Add(userProgressData);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(userProgressData);
        }

        // GET: UserProgressData/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProgressData userProgressData = await db.UserProgressData.FindAsync(id);
            if (userProgressData == null)
            {
                return HttpNotFound();
            }
            return View(userProgressData);
        }

        // POST: UserProgressData/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "UserProgressDataId,UserId,DataReferenceId,DataReferenceType,Progress,Result,DateStarted,DateCompleted")] UserProgressData userProgressData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userProgressData).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(userProgressData);
        }

        // GET: UserProgressData/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserProgressData userProgressData = await db.UserProgressData.FindAsync(id);
            if (userProgressData == null)
            {
                return HttpNotFound();
            }
            return View(userProgressData);
        }

        // POST: UserProgressData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            UserProgressData userProgressData = await db.UserProgressData.FindAsync(id);
            db.UserProgressData.Remove(userProgressData);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
