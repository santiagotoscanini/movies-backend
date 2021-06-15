using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entities;
using Moq;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using InfrastructureInterface.Data.Repositories;
using System.Linq;
using ApplicationCore.Services;

namespace UnitTests.ApplicationCore.Services
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class MovieServiceTest
    {
        [TestMethod]
        public void TestAddMovie()
        {
            var movieToAdd = new Movie { MovieId = 1 };
            var mock = new Mock<IMovieRepository>(MockBehavior.Strict);
            mock.Setup(r => r.Add(movieToAdd)).Returns(movieToAdd);
            var movieService = new MovieService(mock.Object);

            Movie movieSaved = movieService.Add(movieToAdd);

            mock.VerifyAll();
            Assert.AreEqual(movieToAdd, movieSaved);
        }

        [TestMethod]
        public void TestGetAllOk()
        {
            var moviesToReturn = new List<Movie>
            {
                new Movie { MovieId = 1 },
                new Movie { MovieId = 2 },
            };
            var mock = new Mock<IMovieRepository>(MockBehavior.Strict);
            mock.Setup(r => r.GetAll()).Returns(moviesToReturn);
            var movieService = new MovieService(mock.Object);

            IEnumerable<Movie> moviesSaved = movieService.GetAll();

            mock.VerifyAll();
            Assert.IsTrue(moviesSaved.SequenceEqual(moviesToReturn));
        }
        
        [TestMethod]
        public void TestDeleteMovie()
        {
            var moviesToReturn = new List<Movie>();
            var mock = new Mock<IMovieRepository>(MockBehavior.Strict);
            mock.Setup(r => r.GetAll()).Returns(moviesToReturn);
            mock.Setup(r => r.DeleteMovie(1));
            var moviesService = new MovieService(mock.Object);

            moviesService.DeleteMovie(1);
            var moviesSaved = moviesService.GetAll();

            mock.VerifyAll();
            Assert.IsTrue(moviesSaved.SequenceEqual(moviesToReturn));
        }
        
        [TestMethod]
        public void TestGetRandom()
        {
            var movieToReturn = new Movie()
            {
                MovieId = 2
            };
            var mock = new Mock<IMovieRepository>(MockBehavior.Strict);
            mock.Setup(r => r.GetRandom()).Returns(movieToReturn);
            var moviesService = new MovieService(mock.Object);

            var movieSaved = moviesService.GetRandom();

            mock.VerifyAll();
            Assert.AreEqual(movieToReturn, movieSaved);
        }

        [TestMethod]
        public void TestUpdateMovie()
        {
            var movie = new Movie
            {
                MovieId = 1,
                GuessedTimes = 1,
                SelectedTimes = 2,
            };
            var moviesToReturn = new List<Movie>
            {
                movie
            };
            var mock = new Mock<IMovieRepository>(MockBehavior.Strict);
            mock.Setup(r => r.GetAll()).Returns(moviesToReturn);
            mock.Setup(r => r.UpdateMovie(movie)).Returns(movie);
            var moviesService = new MovieService(mock.Object);

            moviesService.UpdateMovie(movie);
            var moviesSaved = moviesService.GetAll();

            mock.VerifyAll();
            Assert.IsTrue(moviesSaved.SequenceEqual(moviesToReturn));
        }
        
        [TestMethod]
        public void TestGetRanking()
        {
            var pageSize = 10;
            var sortOrder = SortOrder.Guessed;
            var movie = new Movie
            {
                MovieId = 1,
                GuessedTimes = 1,
                SelectedTimes = 2,
            };
            var movies = new List<Movie>
            {
                movie,
                movie
            };
            var movieRepository = new Mock<IMovieRepository>();
            movieRepository.Setup(m => m.GetRanking(pageSize,sortOrder)).Returns(movies);
            var service = new MovieService(movieRepository.Object);

            var result = service.GetRanking(pageSize,sortOrder);

            movieRepository.VerifyAll();
            Assert.IsTrue(result.SequenceEqual(movies));
        }
        
        [TestMethod]
        public void TestGetRandomMovie()
        {
            var movie = new Movie
            {
                MovieId = 1,
                GuessedTimes = 1,
                SelectedTimes = 2,
            };
            var movieRepository = new Mock<IMovieRepository>();
            movieRepository.Setup(m => m.GetRandom()).Returns(movie);
            var service = new MovieService(movieRepository.Object);

            var result = service.GetRandom();
            
            movieRepository.VerifyAll();
            Assert.AreEqual(movie, result);
        }
    }
}
