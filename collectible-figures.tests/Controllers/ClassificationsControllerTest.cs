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
    public class ClassificationsControllerTest {
        IDatabaseContext databaseContext;
        ClassificationsController classificationsController;
        Classification classification;

        [TestInitialize]
        public void init() {
            databaseContext = new DatabaseContext();
            classificationsController = new ClassificationsController(databaseContext);
            classification = new Classification();
            classification.ClassificationID = 1;
            classification.Name = "Sample name";
        }

        [TestMethod]
        public void IndexTest() {
            ViewResult viewResult = classificationsController.Index() as ViewResult;
            var model = viewResult.Model;

            Assert.IsNotNull(viewResult);
            Assert.IsNotNull(model);
            Assert.IsTrue(model is IList<Classification>);
        }

        [TestMethod]
        public void DetailsTest() {
            databaseContext.Add(classification);
            ViewResult viewResult = classificationsController.Details(1) as ViewResult;
            var model = viewResult.Model;

            Assert.IsNotNull(viewResult);
            Assert.IsNotNull(model);
            Assert.IsTrue(model is Classification);
        }

        [TestMethod]
        public void DetailsWhenClassificationIsNull() {
            HttpStatusCodeResult result = classificationsController
                .Details(2) as HttpStatusCodeResult;

            Assert.AreEqual(result.StatusCode, 404);
        }

        [TestMethod]
        public void DetailsWhenIdIsNull() {
            HttpStatusCodeResult result = classificationsController
                .Details(null) as HttpStatusCodeResult;

            Assert.AreEqual(result.StatusCode, 400);
        }

        [TestMethod]
        public void ValidAddTest() {
            Classification newClassification = new Classification();
            newClassification.ClassificationID = 1;
            newClassification.Name = "Sample name 2";

            RedirectToRouteResult redirect = classificationsController
                .Create(newClassification) as RedirectToRouteResult;

            Assert.IsNotNull(redirect);
        }

        [TestCleanup]
        public void cleanup() {
            databaseContext = null;
            classificationsController = null;
            classification = null;
        }
    }
}