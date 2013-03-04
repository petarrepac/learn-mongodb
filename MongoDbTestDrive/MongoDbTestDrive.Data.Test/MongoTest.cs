using System;
using System.Linq;
using MongoDB.Bson;
using MongoDbTestDrive.Data.Implementations;
using NUnit.Framework;

namespace MongoDbTestDrive.Data.Test
{
    [TestFixture]
    public class MongoTest
    {
        [Test]
        public void When_EntityInstanceIsCreated_Then_Id_Should_BeEmptyObjectId()
        {
            Assert.AreEqual(ObjectId.Empty, MovieTestData.GetNewMatrixInstance().Id);
            Assert.AreEqual(ObjectId.Empty, MovieTestData.GetNewCasablancaInstance().Id);
        }

        [Test]
        public void When_RemoveAll_Then_FindAll_Should_ReturnZeroCount()
        {
            // arange
            IMovieRepository repo = new MovieRepository();

            // act
            repo.RemoveAll();

            // assert
            Assert.AreEqual(0, repo.FindAll().Count());
        }

        [Test]
        public void When_Insert2_Then_FindAll_Should_Return2()
        {
            // arange
            IMovieRepository repo = new MovieRepository();
            repo.RemoveAll();
            var matrix = MovieTestData.GetNewMatrixInstance();
            var casablanca = MovieTestData.GetNewCasablancaInstance();

            // act
            repo.Insert(matrix);
            repo.Insert(casablanca);

            // assert
            // now ids are NOT empty
            Assert.AreNotEqual(ObjectId.Empty, matrix.Id);
            Assert.AreNotEqual(ObjectId.Empty, casablanca.Id);

            var moviesFromDb = repo.FindAll();
            Assert.AreEqual(2, moviesFromDb.Count());
            
            var matrixFromDb = moviesFromDb.Single(x => x.Title.Contains("Matrix"));
            var casablancaFromDb = moviesFromDb.Single(x => x.Title.Contains("Casablanca"));
            // the instances are not the same in memory 
            Assert.IsFalse(Object.ReferenceEquals(matrix, matrixFromDb));
            Assert.IsFalse(Object.ReferenceEquals(casablanca, casablancaFromDb));
            // but they are considered equal (because they contain the exact same data)
            Assert.AreEqual(matrix, matrixFromDb);
            Assert.AreEqual(casablanca, casablancaFromDb);
        }

        [Test]
        public void When_Insert2_Then_Database_Should_ContainInsertedData()
        {
            // arange
            IMovieRepository repo = new MovieRepository();
            repo.RemoveAll();
            var matrix = MovieTestData.GetNewMatrixInstance();
            var casablanca = MovieTestData.GetNewCasablancaInstance();

            // act
            repo.Insert(matrix);
            repo.Insert(casablanca);

            // assert
            var moviesFromDb = repo.FindAll();
            Assert.AreEqual(2, moviesFromDb.Count());
            var matrixFromDb = moviesFromDb.Single(x => x.Title == matrix.Title);
            var casablancaFromDb = moviesFromDb.Single(x => x.Title == casablanca.Title);
            Assert.AreNotEqual(ObjectId.Empty, matrixFromDb.Id);
            Assert.AreNotEqual(ObjectId.Empty, casablancaFromDb.Id);
        }

        [Test]
        public void When_Insert3_Then_FindById_Should_ReturnRightDocument()
        {
            // arange
            IMovieRepository repo = new MovieRepository();
            repo.RemoveAll();
            var matrix = MovieTestData.GetNewMatrixInstance();
            var casablanca = MovieTestData.GetNewCasablancaInstance();

            var modifiedMatrix = MovieTestData.GetNewMatrixInstance();
            var freshId = ObjectId.GenerateNewId();
            modifiedMatrix.Id = freshId;
            modifiedMatrix.Title = "NewMatrix";

            repo.Insert(matrix);
            repo.Insert(casablanca);
            repo.Insert(modifiedMatrix);

            // act 
            var movieFromDb = repo.FindById(freshId);

            // assert
            Assert.AreEqual("NewMatrix", movieFromDb.Title);
            var allMovies = repo.FindAll();
            Assert.AreEqual(3, allMovies.Count());
        }

        [Test]
        public void When_Insert2_Then_FindWithQuery_Should_ReturnRightDocuments()
        {
            // arange
            IMovieRepository repo = new MovieRepository();
            repo.RemoveAll();
            var matrix = MovieTestData.GetNewMatrixInstance();
            var casablanca = MovieTestData.GetNewCasablancaInstance();
            repo.Insert(matrix);
            repo.Insert(casablanca);

            // act 
            var matrixMovies = repo.FindMoviesByTitle("The Matrix");
            var emptyMovies = repo.FindMoviesByTitle("xyz");

            // assert
            Assert.AreEqual(1, matrixMovies.Count);
            Assert.AreEqual("The Matrix", matrixMovies[0].Title);
            Assert.AreEqual(0, emptyMovies.Count);
        }

        [Test]
        public void When_RemoveDocument_Then_FindAll_Should_ReturnOneLessDocument()
        {
            // arange
            IMovieRepository repo = new MovieRepository();
            repo.RemoveAll();
            var matrix = MovieTestData.GetNewMatrixInstance();
            repo.Insert(matrix);
            repo.Insert(MovieTestData.GetNewCasablancaInstance());

            Assert.AreEqual(2, repo.FindAll().Count());

            // act 
            repo.Remove(matrix);
           
            // assert
            Assert.AreEqual(1, repo.FindAll().Count());
        }
    }
}
