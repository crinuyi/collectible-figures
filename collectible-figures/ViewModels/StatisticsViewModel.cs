using collectible_figures.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace collectible_figures.ViewModels {
    public class StatisticsViewModel {
        public int amountOfFigures;
        public int amountOfClassifications;
        public int amountOfSeries;
    }
}