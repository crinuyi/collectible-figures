using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using collectible_figures.Models;
using collectible_figures.ViewModels;

namespace collectible_figures.Controllers
{
    public class StatisticsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Statistics
        [Route("statystyki")]
        public ActionResult Index()
        {
            var model = new StatisticsViewModel();

            model.amountOfFigures = db.Figures.Count();
            model.amountOfClassifications = db.Classifications.Count();
            model.amountOfSeries = db.Series.Count();

            return View(model);
        }
    }
}