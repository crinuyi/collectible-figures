using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using collectible_figures.Models;

namespace collectible_figures.Database {
    public class DatabaseContext : IDatabaseContext {
        Dictionary<int, Figure> FiguresDictionary { get; set; }
        Dictionary<int, Series> SeriesDictionary { get; set; }
        Dictionary<int, Classification> ClassificationsDictionary { get; set; }

        public DatabaseContext() {
            FiguresDictionary = new Dictionary<int, Figure>();
            SeriesDictionary = new Dictionary<int, Series>();
            ClassificationsDictionary = new Dictionary<int, Classification>();
        }

        public IQueryable<Figure> Figures {
            get { return FiguresDictionary.Select(x => x.Value).AsQueryable<Figure>(); }
        }

        public IQueryable<Classification> Classifications {
            get { return ClassificationsDictionary.Select(x => x.Value).AsQueryable<Classification>(); }
        }

        public IQueryable<Series> Series {
            get { return SeriesDictionary.Select(x => x.Value).AsQueryable<Series>(); }
        }

        T IDatabaseContext.Add<T>(T entity) {
            if (entity is Figure) {
                Figure figure = entity as Figure;
                FiguresDictionary.Add(figure.FigureID, figure);
                return entity;
            }
            else if (entity is Classification) {
                Classification classification = entity as Classification;
                ClassificationsDictionary.Add(classification.ClassificationID, classification);
                return entity;
            }
            else if (entity is Series) {
                Series series = entity as Series;
                SeriesDictionary.Add(series.SeriesID, series);
                return entity;
            }
            else throw new TypeLoadException();
        }

        T IDatabaseContext.Delete<T>(T entity) {
            if (entity is Figure) {
                Figure figure = entity as Figure;
                if (FiguresDictionary.ContainsKey(figure.FigureID)) {
                    FiguresDictionary.Remove(figure.FigureID);
                    return entity;
                }
                else throw new KeyNotFoundException();
            }
            else if (entity is Classification) {
                Classification classification = entity as Classification;
                if (ClassificationsDictionary.ContainsKey(classification.ClassificationID)) {
                    ClassificationsDictionary.Remove(classification.ClassificationID);
                    return entity;
                }
                else throw new KeyNotFoundException();
            }
            else if (entity is Series) {
                Series series = entity as Series;
                if (SeriesDictionary.ContainsKey(series.SeriesID)) {
                    SeriesDictionary.Remove(series.SeriesID);
                    return entity;
                }
                else throw new KeyNotFoundException();
            }
            else throw new TypeLoadException();
        }

        Classification IDatabaseContext.FindClassificationById(int id) {
            if (ClassificationsDictionary.ContainsKey(id))
                return ClassificationsDictionary[id];
            else throw new KeyNotFoundException();
        }

        Figure IDatabaseContext.FindFigureById(int id) {
            if (FiguresDictionary.ContainsKey(id))
                return FiguresDictionary[id];
            else throw new KeyNotFoundException();
        }

        Series IDatabaseContext.FindSeriesById(int id) {
            if (SeriesDictionary.ContainsKey(id))
                return SeriesDictionary[id];
            else throw new KeyNotFoundException();
        }

        int IDatabaseContext.SaveChanges() {
            return 0;
        }
    }
}