using ApplicationCoreInterface.Services;
using Entities;
using InfrastructureInterface.Data.Repositories;
using System.Collections.Generic;

namespace ApplicationCore.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public Movie Add(Movie movie)
        {
            return _movieRepository.Add(movie);
        }

        public IEnumerable<Movie> GetAll()
        {
            return _movieRepository.GetAll();
        }

        public void DeleteMovie(int movieId)
        {
            _movieRepository.DeleteMovie(movieId);
        }

        public void UpdateMovie(Movie movie)
        {
            _movieRepository.UpdateMovie(movie);
        }

        public IEnumerable<Movie> GetRanking(int pageSize, SortOrder sortOrder)
        {
            return _movieRepository.GetRanking(pageSize, sortOrder);
        }

        public Movie GetRandom()
        {
            return _movieRepository.GetRandom();
        }
    }
}
