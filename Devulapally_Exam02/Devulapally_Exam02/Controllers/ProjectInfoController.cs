using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Devulapally_Exam02.DAL;
using Devulapally_Exam02.Models;

namespace Devulapally_Exam02.Controllers
{
    public class ProjectInfoController : Controller
    {
        private ProjectContext db = new ProjectContext();

        // GET: ProjectInfo
        public ActionResult Index()
        {
            var projectInform = db.ProjectInform.Include(p => p.Employees).Include(p => p.Projects);
            return View(projectInform.ToList());
        }

        // GET: ProjectInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectInfo projectInfo = db.ProjectInform.Find(id);
            if (projectInfo == null)
            {
                return HttpNotFound();
            }
            return View(projectInfo);
        }

        // GET: ProjectInfo/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "LastName");
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "Title");
            return View();
        }

        // POST: ProjectInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProjectInfoID,EmployeeID,ProjectID,AssignmentDate")] ProjectInfo projectInfo)
        {
            if (ModelState.IsValid)
            {
                db.ProjectInform.Add(projectInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "LastName", projectInfo.EmployeeID);
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "Title", projectInfo.ProjectID);
            return View(projectInfo);
        }

        // GET: ProjectInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectInfo projectInfo = db.ProjectInform.Find(id);
            if (projectInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "LastName", projectInfo.EmployeeID);
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "Title", projectInfo.ProjectID);
            return View(projectInfo);
        }

        // POST: ProjectInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProjectInfoID,EmployeeID,ProjectID,AssignmentDate")] ProjectInfo projectInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(db.Employees, "ID", "LastName", projectInfo.EmployeeID);
            ViewBag.ProjectID = new SelectList(db.Projects, "ProjectID", "Title", projectInfo.ProjectID);
            return View(projectInfo);
        }

        // GET: ProjectInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectInfo projectInfo = db.ProjectInform.Find(id);
            if (projectInfo == null)
            {
                return HttpNotFound();
            }
            return View(projectInfo);
        }

        // POST: ProjectInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectInfo projectInfo = db.ProjectInform.Find(id);
            db.ProjectInform.Remove(projectInfo);
            db.SaveChanges();
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
