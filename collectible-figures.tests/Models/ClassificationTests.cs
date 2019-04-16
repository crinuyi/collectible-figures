using collectible_figures.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collectible_figures.tests.Models {
    [TestClass]
    public class ClassificationTests {
        private Classification classification;

        [TestInitialize]
        public void Init() {
            classification = new Classification() {
                Name = "Sample classification",
                Figures = {
                    new Figure() {
                        Name = "Sakura Kinomoto",
                        Scale = "1:30",
                        ReleaseDate = new DateTime(2020, 01, 01),
                        Price = 200,
                        Series = new Series() {
                            Name = "Sample series"
                        }
                    }
                }
            };
        }

        [TestCleanup]
        public void Cleanup() {
            classification = null;
        }
    }
}
