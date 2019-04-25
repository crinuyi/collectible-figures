using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using collectible_figures.Database;
using collectible_figures.Models;

namespace collectible_figures.Controllers
{
    public class ClassificationsController : Controller
    {
        private IDatabaseContext db = null;
        
        public ClassificationsController(IDatabaseContext databaseContext) {
            db = databaseContext;
        }

        public JsonResult DoesNameExists(string name) {
            return Json(!db.Classifications.Any(x => x.Name == name), JsonRequestBehavior.AllowGet);
        }

        // GET: Classifications
        [Route("typ")]
        public ActionResult Index()
        {
            return View(db.Classifications.ToList());
        }

        // GET: Classifications/Details/5
        [Route("typ/{id:int}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classification classification = db.FindClassificationById((int)id);
            if (classification == null)
            {
                return HttpNotFound();
            }
            return View(classification);
        }

        // GET: Classifications/Create
        [Authorize(Roles = "Admin, Moderator")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Classifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClassificationID,Name")] Classification classification)
        {
            if (ModelState.IsValid)
            {
                db.Add(classification);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(classification);
        }
        

        // GET: Classifications/Delete/5
        [Authorize(Roles = "Admin, Moderator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classification classification = db.FindClassificationById((int)id);
            if (classification == null)
            {
                return HttpNotFound();
            }
            return View(classification);
        }

        // POST: Classifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Classification classification = db.FindClassificationById(id);
            db.Delete(classification);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
