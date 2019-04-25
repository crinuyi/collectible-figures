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
    public class SeriesController : Controller
    {
        private IDatabaseContext db;

        // GET: Series
        [Route("seria")]
        public ActionResult Index()
        {
            return View(db.Series.ToList());
        }

        // GET: Series/Details/5
        [Route("seria/{id:int}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Series series = db.FindSeriesById((int)id);
            if (series == null)
            {
                return HttpNotFound();
            }

            ViewBag.Total = db.Figures.Count(x => x.SeriesID == id);
            return View(series);
        }

        // GET: Series/Create
        [Authorize(Roles = "Admin, Moderator")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Series/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SeriesID,Name")] Series series)
        {
            if (ModelState.IsValid)
            {
                db.Add(series);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(series);
        }

        // GET: Series/Delete/5
        [Authorize(Roles = "Admin, Moderator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Series series = db.FindSeriesById((int)id);
            if (series == null)
            {
                return HttpNotFound();
            }
            return View(series);
        }

        // POST: Series/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Series series = db.FindSeriesById(id);
            db.Delete(series);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
