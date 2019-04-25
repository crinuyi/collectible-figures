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
    public class SeriesTests {
        private Series series;
        private ValidationContext validationContext;
        private List<ValidationResult> validationResults;

        [TestInitialize]
        public void Init() {
            series = new Series() {
                Name = "Sample name"
            };
            validationContext = new ValidationContext(series, null, null);
            validationResults = new List<ValidationResult>();
        }

        [TestMethod]
        public void SeriesValidationTest() {
            bool isValid = Validator.TryValidateObject(series, validationContext, validationResults);

            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void EmptyNameValidationTest() {
            series.Name = "";

            bool isValid = Validator.TryValidateObject(series, validationContext, validationResults, true);

            Assert.IsFalse(isValid);
        }

        [TestCleanup]
        public void Cleanup() {
            series = null;
            validationContext = null;
            validationResults = null;
        }
    }
}
