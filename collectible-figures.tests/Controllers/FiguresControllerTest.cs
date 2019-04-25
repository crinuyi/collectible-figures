using collectible_figures.Controllers;
using collectible_figures.Database;
using collectible_figures.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

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

    }
}