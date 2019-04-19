using collectible_figures.Controllers;
using collectible_figures.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace collectible_figures.tests.Models {
    [TestClass]
    public class ClassificationTests {
        private Classification classification;
        private ClassificationsController classificationsController;
        private ValidationContext validationContext;
        private List<ValidationResult> validationResults;

        [TestInitialize]
        public void Init() {
            classification = new Classification() {
                Name = "Sample classification"
            };
            classificationsController = new ClassificationsController();
            validationContext = new ValidationContext(classification, null, null);
            validationResults = new List<ValidationResult>();
        }

        [TestMethod]
        public void ClassificationTest() {
            bool isValid = Validator.TryValidateObject(classification, validationContext, validationResults, true);

            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void InvalidNameValidationTest() {
            classification.Name = "sample classification";
            
            bool isValid = Validator.TryValidateObject(classification, validationContext, validationResults, true);

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void InvalidNameValidation2Test() {
            classification.Name = "Sample classification $$";

            bool isValid = Validator.TryValidateObject(classification, validationContext, validationResults, true);

            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void EmptyNameValidationTest() {
            classification.Name = "";
            
            bool isValid = Validator.TryValidateObject(classification, validationContext, validationResults, true);

            Assert.IsFalse(isValid);
        }

        [TestCleanup]
        public void Cleanup() {
            classification = null;
            classificationsController = null;
            validationContext = null;
            validationResults = null;
        }
    }
}
