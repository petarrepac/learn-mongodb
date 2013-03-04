using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDbTestDrive.Domain;

namespace MongoDbTestDrive.Data.Implementations
{
    public class MovieRepository : MongoRepository, IMovieRepository
    {
        private const string collectionName = "movie";

        private MongoCollection<Movie> GetCollection()
        {
            var movieCollection = Database.GetCollection<Movie>(collectionName);
            return movieCollection;
        }

        public IList<Movie> FindAll()
        {
            var collection = GetCollection();
            return collection.FindAll().ToList();
        }

        public bool Insert(Movie movie)
        {
            var collection = GetCollection();
            var writeConcernResult = collection.Insert(movie);
            return writeConcernResult.Ok;
        }

        public Movie FindById(ObjectId id)
        {
            var collection = GetCollection();
            var movie = collection.FindOneByIdAs<Movie>(id);
            return movie;
        }

        public IList<Movie> FindMoviesByTitle(string title)
        {
            var collection = GetCollection();
            var cursor = collection.Find(Query<Movie>.EQ(x => x.Title, title));
            return cursor.ToList();
        }

        public bool Remove(Movie movie)
        {
            if (movie == null) throw new ArgumentNullException("movie");
            if (movie.Id == ObjectId.Empty) throw new ArgumentNullException("movie");

            var collection = GetCollection();
            var writeConcernResult = collection.Remove(Query.EQ("_id", movie.Id));
            return writeConcernResult.Ok;
        }

        public bool RemoveAll()
        {
            var collection = GetCollection();
            var writeConcernResult = collection.RemoveAll();
            return writeConcernResult.Ok;
        }
    }
}
