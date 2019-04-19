using collectible_figures.Controllers;
using collectible_figures.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collectible_figures.tests.Models {
    [TestClass]
    public class FigureTests {
        private Figure figure;
        private FiguresController figuresController;
        private ValidationContext validationContext;
        private List<ValidationResult> validationResults;

        [TestInitialize]
        public void Init() {
            figure = new Figure() {
                Name = "Sample same",
                Scale = "1:30",
                ReleaseDate = new DateTime(2020, 10, 01),
                Price = 300
            };
            figuresController = new FiguresController();
            validationContext = new ValidationContext(figure, null, null);
            validationResults = new List<ValidationResult>();
        }

        [TestMethod]
        public void FigureValidationTest() {
            bool isValid = Validator.TryValidateObject(figure, validationContext, validationResults);

            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void InvalidNameValidationTest() {
            figure.Name = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

            bool isValid = Validator.TryValidateObject(figure, validationContext, validationResults, true);

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void EmptyNameValidationTest() {
            figure.Name = "";

            bool isValid = Validator.TryValidateObject(figure, validationContext, validationResults, true);

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void EmptyScaleTest() {
            figure.Scale = "";

            bool isValid = Validator.TryValidateObject(figure, validationContext, validationResults, true);

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void InvalidScaleTest() {
            figure.Scale = "Invalid scale";

            bool isValid = Validator.TryValidateObject(figure, validationContext, validationResults, true);

            Assert.IsFalse(isValid);
        }

        [TestCleanup]
        public void Cleanup() {
            figure = null;
            figuresController = null;
            validationContext = null;
            validationResults = null;
        }
    }
}
