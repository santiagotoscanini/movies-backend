using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using ApplicationCoreInterface.Services;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Web.Controllers;
using Web.Models.MovieModels;

namespace UnitTests.Web.Controllers
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class MovieControllerTest
    {
        private int _movieId = 1;
        private string _movieName = "La era del Hielo";
        private string _imageUrl = "s3://path/to/s3";
        private int _selectedTimes = 12;
        private int _guessedTimes = 23;

        [TestMethod]
        public void AddMovieTest()
        {
            var movieModel = new MovieCreatingModel
            {
                MovieName = _movieName,
                GuessedTimes = _guessedTimes,
                SelectedTimes = _selectedTimes,
                ImageURL = _imageUrl
            };

            var movieService = new Mock<IMovieService>();
            movieService.Setup(m => m.Add(movieModel.ToEntity())).Returns(movieModel.ToEntity());
            var controller = new MovieController(movieService.Object);

            IActionResult result = controller.AddMovie(movieModel);
            var status = result as ObjectResult;
            var content = status.Value as MovieBaseModel;

            movieService.VerifyAll();
            Assert.AreEqual(content, new MovieBaseModel(movieModel.ToEntity()));
        }

        [TestMethod]
        public void DeleteMovieTest()
        {
            var movieService = new Mock<IMovieService>();
            movieService.Setup(m => m.DeleteMovie(_movieId));
            var controller = new MovieController(movieService.Object);

            IActionResult result = controller.DeleteMovie(_movieId);
            var status = result as NoContentResult;

            movieService.VerifyAll();
            Assert.AreEqual(204, status.StatusCode);
        }

        [TestMethod]
        public void UpdateMovieTest()
        {
            var movie = new Movie
            {
                MovieId = _movieId,
                GuessedTimes = _guessedTimes,
                SelectedTimes = _selectedTimes,
            };
            var movieModel = new MovieUpdatingModel
            {
                GuessedTimes = _guessedTimes,
                SelectedTimes = _selectedTimes,
            };
            var movieService = new Mock<IMovieService>();
            movieService.Setup(m => m.UpdateMovie(movie));
            var controller = new MovieController(movieService.Object);

            var result = controller.UpdateMovie(_movieId, movieModel);
            var status = result as NoContentResult;

            movieService.VerifyAll();
            Assert.AreEqual(204, status.StatusCode);
        }
        
        [TestMethod]
        public void GetRandomMovieTest()
        {
            var movie = new Movie
            {
                MovieId = _movieId,
                GuessedTimes = _guessedTimes,
                SelectedTimes = _selectedTimes,
            };
            var movieModel = new MovieBaseModel(movie);
            var movieService = new Mock<IMovieService>();
            movieService.Setup(m => m.GetRandom()).Returns(movie);
            var controller = new MovieController(movieService.Object);

            var result = controller.GetRandomMovie();
            var status = result as ObjectResult;
            var value = status.Value as MovieBaseModel;
            
            movieService.VerifyAll();
            Assert.AreEqual(movieModel, value);
        }

        [TestMethod]
        public void GetMoviesRankedValid()
        {
            var filter = new MoviesRankedFilterModel()
            {
                pageSize = 10,
                sortOrder = SortOrder.Guessed
            };
            var movie = new Movie
            {
                MovieId = _movieId,
                GuessedTimes = _guessedTimes,
                SelectedTimes = _selectedTimes,
            };
            var movies = new List<Movie>
            {
                movie,
                movie
            };
            var moviesModels = new List<MovieBaseModel>
            {
                new MovieBaseModel(movie),
                new MovieBaseModel(movie)
            };
            var movieService = new Mock<IMovieService>();
            movieService.Setup(m => m.GetRanking(filter.pageSize,filter.sortOrder)).Returns(movies);
            var controller = new MovieController(movieService.Object);

            var result = controller.GetMoviesRanked(filter);
            var status = result as ObjectResult;
            var content = status.Value as IEnumerable<MovieBaseModel>;

            movieService.VerifyAll();
            Assert.IsTrue(moviesModels.SequenceEqual(content));
        }
    }
}
