using collectible_figures.Controllers;
using collectible_figures.Database;
using collectible_figures.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace collectible_figures.tests.Controllers {
    [TestClass]
    class FiguresControllerTest {
        Mock<IDatabaseContext> databaseContext;
        FiguresController figuresController;
        Mock<Figure> figure;

        [TestInitialize]
        public void Init() {
            databaseContext = new Mock<IDatabaseContext>();
            figuresController = new FiguresController(databaseContext.Object);

            figure = new Mock<Figure>();
        }

        [TestMethod]
        public void IndexTest() {
            databaseContext.Setup(db => db.Classifications).Returns((new Dictionary<int, Classification>().Values).AsQueryable());
            databaseContext.Setup(db => db.Figures).Returns((new Dictionary<int, Figure>().Values).AsQueryable());
            databaseContext.Setup(db => db.Series).Returns((new Dictionary<int, Series>().Values).AsQueryable());

            ViewResult viewResult = figuresController.Index() as ViewResult;
            var model = viewResult.Model;

            Assert.IsNotNull(viewResult);
            Assert.IsNotNull(model);
            Assert.IsTrue(model is IList<Figure>);
        }

        [TestMethod]
        public void DetailsTest() {
            databaseContext.Setup(db => db.Add(figure)).Returns(figure);
            ViewResult viewResult = figuresController.Details(1) as ViewResult;
            var model = viewResult.Model;

            databaseContext.Verify(db => db.Add(figure));
            Assert.IsNotNull(viewResult);
            Assert.IsNotNull(model);
            Assert.IsTrue(model is Figure);
        }

        [TestMethod]
        public void DeleteTest() {
            databaseContext.Setup(db => db.Delete(figure)).Returns(figure);
            ViewResult viewResult = figuresController.Details(1) as ViewResult;
            var model = viewResult.Model;

            databaseContext.Verify(db => db.Delete(figure));
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
        public void Cleanup() {
            databaseContext = null;
            figuresController = null;
            figure = null;
        }

    }
}