using CFT.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CFT.Controllers
{
    public class HomeController : Controller
    {
        ModelBugTracker db = new ModelBugTracker();          

        public ActionResult Index()
        {
            //return View(db.BugTrackers);

            var bugs = db.BugTrackers.Include(p => p.Applications);
            return View(bugs.ToList());
        }

        // Editor
        [HttpGet]
        public ActionResult Edit(int? id)
        {  
            if (id == null)
            {
                return HttpNotFound();
            }
            BugTrackers bug = db.BugTrackers.Find(id);

            if (bug != null)
            {
                SelectList applications = new SelectList(db.Applications, "ApplicationId", "NameApplication", bug.ApplicationId);
                ViewBag.Applications = applications;
                return View(bug);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(BugTrackers bug)
        {
            string dateapply = "01.01.0001 0:00:00";
            db.Entry(bug).State = EntityState.Modified;
            string datechange = bug.DateEndDevelopment.ToString();
            if (bug.ApplicationId != null && bug.DateEndDevelopment !=null && Equals(datechange, dateapply) == false && bug.Description != null && bug.Email != null)
            {                
                db.SaveChanges();        
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Edit");

            }
            
        }

        // Creator
        [HttpGet]
        public ActionResult Create()
        {
            SelectList applications = new SelectList(db.Applications, "ApplicationId", "NameApplication");
            ViewBag.Applications = applications;
            return View();
        }

        [HttpPost]
        public ActionResult Create(BugTrackers bug)
        {
            db.BugTrackers.Add(bug);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        //Deleter
        [HttpGet]
        public ActionResult Delete(int BugTrackerId)
        {
            BugTrackers b = db.BugTrackers.Find(BugTrackerId);
            if (b == null)
            {
                return HttpNotFound();
            }
            return View(b);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int BugTrackerId)
        {
            BugTrackers b = db.BugTrackers.Find(BugTrackerId);
            if (b == null)
            {
                return HttpNotFound();
            }
            db.BugTrackers.Remove(b);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //view все багов приложения
        public ActionResult ApplicationDetails(int? ApplicationId)
        {
            if (ApplicationId == null)
            {
                return HttpNotFound();
            }
            Applications application = db.Applications.Include(t => t.BugTrackers).FirstOrDefault(t => t.ApplicationId == ApplicationId);
            
            if (application == null)
            {
                return HttpNotFound();
            }
            return View(application);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //предполагается что закроет подключение
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}