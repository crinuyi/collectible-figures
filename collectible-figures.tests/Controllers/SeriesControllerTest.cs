﻿using collectible_figures.Controllers;
using collectible_figures.Database;
using collectible_figures.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace collectible_figures.tests.Controllers {
    [TestClass]
    public class SeriesControllerTest {
        IDatabaseContext databaseContext;
        SeriesController seriesController;
        Series series;

        [TestInitialize]
        public void init() {
            databaseContext = new DatabaseContext();
            seriesController = new SeriesController(databaseContext);
            series = new Series();
            series.SeriesID = 1;
            series.Name = "Sample name";
        }

        [TestMethod]
        public void IndexTest() {
            ViewResult viewResult = seriesController.Index() as ViewResult;
            var model = viewResult.Model;

            Assert.IsNotNull(viewResult);
            Assert.IsNotNull(model);
            Assert.IsTrue(model is IList<Series>);
        }

        [TestMethod]
        public void DetailsTest() {
            databaseContext.Add(series);
            ViewResult viewResult = seriesController.Details(1) as ViewResult;
            var model = viewResult.Model;

            Assert.IsNotNull(viewResult);
            Assert.IsNotNull(model);
            Assert.IsTrue(model is Series);
        }


        [TestMethod]
        public void DetailsWhenSeriesIsNull() {
            HttpStatusCodeResult result = seriesController
                .Details(2) as HttpStatusCodeResult;

            Assert.AreEqual(result.StatusCode, 404);
        }

        [TestMethod]
        public void DetailsWhenIdIsNull() {
            HttpStatusCodeResult result = seriesController
                .Details(null) as HttpStatusCodeResult;

            Assert.AreEqual(result.StatusCode, 400);
        }

        [TestMethod]
        public void ValidAddTest() {
            Series newSeries = new Series();
            newSeries.SeriesID = 1;
            newSeries.Name = "Sample name 2";


            RedirectToRouteResult redirect = seriesController
                .Create(newSeries) as RedirectToRouteResult;

            Assert.IsNotNull(redirect);
        }

        [TestCleanup]
        public void cleanup() {
            databaseContext = null;
            seriesController = null;
            series = null;
        }
    }
}