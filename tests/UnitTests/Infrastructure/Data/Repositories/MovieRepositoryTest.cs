using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Entities;
using Exceptions;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Infrastructure.Data.Repositories
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class MovieRepositoryTest
    {
        private MoviesContext _moviesContext;
        private MovieRepository _movieRepository;

        [TestInitialize]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<MoviesContext>().UseInMemoryDatabase(databaseName: "movies_db").Options;
            _moviesContext = new MoviesContext(options);
            _movieRepository = new MovieRepository(_moviesContext);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _moviesContext.Database.EnsureDeleted();
        }
        
        [TestMethod]
        public void TestAddMovie()
        {
            var movieToAdd = new Movie { MovieId = 1 };
            
            _movieRepository.Add(movieToAdd);
            var result = _moviesContext.Movies.Contains(movieToAdd);

            Assert.IsTrue(result);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ObjectAlreadyExistException))]
        public void TestAddMovieDuplicated()
        {
            var movieToAdd = new Movie { MovieId = 1 };
            _moviesContext.Movies.Add(movieToAdd);
            _moviesContext.SaveChanges();
            
            _movieRepository.Add(movieToAdd);
        }

        [TestMethod]
        public void TestGetAllMovies()
        {
            var moviesToReturn = new List<Movie>
            {
                new Movie { MovieId = 1 },
                new Movie { MovieId = 2 },
            };
            _moviesContext.Movies.AddRange(moviesToReturn);
            _moviesContext.SaveChanges();

            var result = _movieRepository.GetAll();

            Assert.IsTrue(moviesToReturn.SequenceEqual(result));
        }

        [TestMethod]
        public void TestGetMoviesRankedByGuessed()
        {
            var moviesToReturn = new List<Movie>
            {
                new Movie { MovieId = 1, GuessedTimes = 2,SelectedTimes = 13},
                new Movie { MovieId = 2, GuessedTimes = 6,SelectedTimes = 4},
            };
            _moviesContext.Movies.AddRange(moviesToReturn);
            _moviesContext.SaveChanges();

            var result = _movieRepository.GetRanking(10, SortOrder.Guessed).ToList();
            moviesToReturn = moviesToReturn.OrderByDescending(m => m.GuessedTimes).ToList();
            
            Assert.IsTrue(moviesToReturn.SequenceEqual(result));
        }

        [TestMethod]
        public void TestGetMoviesRankedBySelected()
        {
            var moviesToReturn = new List<Movie>
            {
                new Movie { MovieId = 1, GuessedTimes = 2,SelectedTimes = 13},
                new Movie { MovieId = 2, GuessedTimes = 6,SelectedTimes = 4},
            };
            _moviesContext.Movies.AddRange(moviesToReturn);
            _moviesContext.SaveChanges();

            var result = _movieRepository.GetRanking(10, SortOrder.Selected).ToList();
            moviesToReturn = moviesToReturn.OrderByDescending(m => m.SelectedTimes).ToList();
            
            Assert.IsTrue(moviesToReturn.SequenceEqual(result));
        }

        
        [TestMethod]
        public void TestGetMoviesRankedNonOrderProvided()
        {
            var moviesToReturn = new List<Movie>
            {
                new Movie { MovieId = 1, GuessedTimes = 2,SelectedTimes = 13},
                new Movie { MovieId = 2, GuessedTimes = 6,SelectedTimes = 4},
            };
            _moviesContext.Movies.AddRange(moviesToReturn);
            _moviesContext.SaveChanges();

            var result = _movieRepository.GetRanking(10, (SortOrder)(-1)).ToList();
            moviesToReturn = moviesToReturn.OrderByDescending(m => m.GuessedTimes).ToList();
            
            Assert.IsTrue(moviesToReturn.SequenceEqual(result));
        }

        [TestMethod]
        public void TestDeleteMovie()
        {
            var movieToAdd = new Movie { MovieId = 1 };
            _moviesContext.Movies.Add(movieToAdd);
            _moviesContext.SaveChanges();
            
            _movieRepository.DeleteMovie(movieToAdd.MovieId);
            var result = _moviesContext.Movies.Contains(movieToAdd);

            Assert.IsFalse(result);
        }
        
        [TestMethod]
        public void TestGetRandomMovie()
        {
            var movieToAdd = new Movie { MovieId = 1 };
            _moviesContext.Movies.Add(movieToAdd);
            _moviesContext.SaveChanges();
            
            var result = _movieRepository.GetRandom();

            Assert.IsInstanceOfType(result, typeof(Movie));
        }

        [TestMethod]
        [ExpectedException(typeof(NotFoundException))]
        public void TestDeleteMovieNotValid()
        {
            var movieToAdd = new Movie { MovieId = 1 };
            
            _movieRepository.DeleteMovie(movieToAdd.MovieId);
        }

        [TestMethod]
        public void TestUpdateMovie()
        {
            var movieToAdd = new Movie { MovieId = 1, MovieName = "chef raton"};
            _moviesContext.Movies.Add(movieToAdd);
            _moviesContext.SaveChanges();
            movieToAdd.MovieName = "ratatouille";
            movieToAdd.SelectedTimes = 11;
            movieToAdd.GuessedTimes = 19;

            _movieRepository.UpdateMovie(movieToAdd);
            var movieSaved = _moviesContext.Movies.First();
                
            Assert.AreEqual(movieToAdd.MovieName, movieSaved.MovieName);
            Assert.AreEqual(movieToAdd.SelectedTimes, movieSaved.SelectedTimes);
            Assert.AreEqual(movieToAdd.GuessedTimes, movieSaved.GuessedTimes);
        }
    }
}