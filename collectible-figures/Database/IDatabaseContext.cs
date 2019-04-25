using collectible_figures.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collectible_figures.Database {
    interface IDatabaseContext {
        IQueryable<Figure> Figures { get; }
        IQueryable<Classification> Classifications { get; }
        IQueryable<Series> Series { get; }
        int SaveChanges();
        T Add<T>(T entity) where T : class;
        Figure FindFigureById(int id);
        Classification FindClassificationById(int id);
        Series FindSeriesById(int id);
        T Delete<T>(T entity) where T : class;
        
    }
}
