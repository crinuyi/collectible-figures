using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using collectible_figures.Models;

namespace collectible_figures.Database {
    public class DatabaseContext : IDatabaseContext {
        Dictionary<int, Figure> Figures { get; set; }
        Dictionary<int, Series> Series { get; set; }
        Dictionary<int, Classification> Classifications { get; set; }
        IQueryable<Figure> IDatabaseContext.Figures {
            get { return Figures.Select(x => x.Value).AsQueryable<Figure>(); }
        }
        IQueryable<Classification> IDatabaseContext.Classifications {
            get { return Classifications.Select(x => x.Value).AsQueryable<Classification>(); }
        }

        IQueryable<Series> IDatabaseContext.Series {
            get { return Series.Select(x => x.Value).AsQueryable<Series>(); }
        }

        T IDatabaseContext.Add<T>(T entity) {
            if (entity is Figure) {
                Figure figure = entity as Figure;
                Figures.Add(figure.FigureID, figure);
                return entity;
            }
            else if (entity is Classification) {
                Classification classification = entity as Classification;
                Classifications.Add(classification.ClassificationID, classification);
                return entity;
            }
            else if (entity is Series) {
                Series series = entity as Series;
                Series.Add(series.SeriesID, series);
                return entity;
            }
            else throw new TypeLoadException();
        }

        T IDatabaseContext.Delete<T>(T entity) {
            if (entity is Figure) {
                Figure figure = entity as Figure;
                if (Figures.ContainsKey(figure.FigureID)) {
                    Figures.Remove(figure.FigureID);
                    return entity;
                }
                else throw new KeyNotFoundException();
            }
            else if (entity is Classification) {
                Classification classification = entity as Classification;
                if (Classifications.ContainsKey(classification.ClassificationID)) {
                    Classifications.Remove(classification.ClassificationID);
                    return entity;
                }
                else throw new KeyNotFoundException();
            }
            else if (entity is Series) {
                Series series = entity as Series;
                if (Series.ContainsKey(series.SeriesID)) {
                    Series.Remove(series.SeriesID);
                    return entity;
                }
                else throw new KeyNotFoundException();
            }
            else throw new TypeLoadException();
        }

        Classification IDatabaseContext.FindClassificationById(int id) {
            if (Classifications.ContainsKey(id))
                return Classifications[id];
            else throw new KeyNotFoundException();
        }

        Figure IDatabaseContext.FindFigureById(int id) {
            if (Figures.ContainsKey(id))
                return Figures[id];
            else throw new KeyNotFoundException();
        }

        Series IDatabaseContext.FindSeriesById(int id) {
            if (Series.ContainsKey(id))
                return Series[id];
            else throw new KeyNotFoundException();
        }

        int IDatabaseContext.SaveChanges() {
            return 0;
        }
    }
}