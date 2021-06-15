using System.Diagnostics.CodeAnalysis;
using Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.Entities
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class MovieTest
    {
        private int _movieId = 1;
        private string _movieName = "La era del Hielo";
        private string _imageUrl = "s3://path/to/s3";
        private int _selectedTimes = 12;
        private int _guessedTimes = 23;

        [TestMethod]
        public void CreateEmptyMovie()
        {
            var movie = new Movie();

            Assert.AreEqual(0, movie.MovieId);
            Assert.IsNull(movie.MovieName);
            Assert.IsNull(movie.ImageUrl);
            Assert.AreEqual(0, movie.GuessedTimes);
            Assert.AreEqual(0, movie.SelectedTimes);
        }

        [TestMethod]
        public void CreateMovieWithData()
        {
            var movie = new Movie
            {
                MovieId = _movieId,
                MovieName = _movieName,
                ImageUrl = _imageUrl,
                SelectedTimes = _selectedTimes,
                GuessedTimes = _guessedTimes,
            };

            Assert.AreEqual(movie.MovieId, _movieId);
            Assert.AreEqual(movie.MovieName, _movieName);
            Assert.AreEqual(movie.ImageUrl, _imageUrl);
            Assert.AreEqual(movie.SelectedTimes, _selectedTimes);
            Assert.AreEqual(movie.GuessedTimes, _guessedTimes);
        }

        [TestMethod]
        public void EqualsOk()
        {
            var movie1 = new Movie
            {
                MovieId = _movieId,
                MovieName = _movieName,
                ImageUrl = _imageUrl,
            };
            var movie2 = new Movie
            {
                MovieId = _movieId,
            };

            Assert.AreEqual(movie1, movie2);
        }

        [TestMethod]
        public void EqualsFail()
        {
            var movie1 = new Movie
            {
                MovieId = _movieId,
                MovieName = _movieName,
                ImageUrl = _imageUrl,
            };
            var movie2 = new Movie
            {
                MovieId = _movieId + 1,
            };

            Assert.AreNotEqual(movie1, movie2);
        }
    }
}
