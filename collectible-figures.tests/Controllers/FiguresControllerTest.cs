using collectible_figures.Controllers;
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
    class FiguresControllerTest {
        IDatabaseContext databaseContext;
        FiguresController figuresController;
        Figure figure;

        [TestInitialize]
        public void init() {
            databaseContext = new DatabaseContext();
            figuresController = new FiguresController(databaseContext);

            figure = new Figure();
            figure.FigureID = 1;
            figure.Name = "Sample figure";
            figure.Scale = "1:30";
            figure.ReleaseDate = new DateTime(2019, 10, 10);
            figure.Price = 300;
        }

        [TestMethod]
        public void IndexTest() {
            ViewResult viewResult = figuresController.Index() as ViewResult;
            var model = viewResult.Model;

            Assert.IsNotNull(viewResult);
            Assert.IsNotNull(model);
            Assert.IsTrue(model is IList<Figure>);
        }

        [TestMethod]
        public void DetailsTest() {
            databaseContext.Add(figure);
            ViewResult viewResult = figuresController.Details(1) as ViewResult;
            var model = viewResult.Model;

            Assert.IsNotNull(viewResult);
            Assert.IsNotNull(model);
            Assert.IsTrue(model is Figure);
        }

        [TestMethod]
        public void DetailsWhenFigureIsNull() {
            HttpStatusCodeResult result = figuresController
                .Details(2) as HttpStatusCodeResult;

            Assert.AreEqual(result.StatusCode, 404);
        }

        [TestMethod]
        public void DetailsWhenIdIsNull() {
            HttpStatusCodeResult result = figuresController
                .Details(null) as HttpStatusCodeResult;

            Assert.AreEqual(result.StatusCode, 400);
        }

        [TestMethod]
        public void ValidAddTest() {
            Figure newFigure = new Figure();
            newFigure.FigureID = 1;
            newFigure.Name = "Sample name 2";
            newFigure.Scale = "1:20";
            newFigure.ReleaseDate = new DateTime(2020, 10, 10);
            newFigure.Price = 500;

            RedirectToRouteResult redirect = figuresController
                .Create(newFigure) as RedirectToRouteResult;

            Assert.IsNotNull(redirect);
        }


        [TestCleanup]
        public void cleanup() {
            databaseContext = null;
            figuresController = null;
            figure = null;
        }

    }
}