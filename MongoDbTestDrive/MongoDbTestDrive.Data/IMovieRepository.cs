using System.Collections.Generic;
using MongoDB.Bson;
using MongoDbTestDrive.Domain;

namespace MongoDbTestDrive.Data
{
    public interface IMovieRepository
    {
        IList<Movie> FindAll();
        bool Insert(Movie movie);
        Movie FindById(ObjectId id);
        IList<Movie> FindMoviesByTitle(string title);
        bool Remove(Movie movie);
        bool RemoveAll();
    }
}
