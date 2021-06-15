using Entities;
using System.Collections.Generic;

namespace ApplicationCoreInterface.Services
{
    public interface IMovieService
    {
        Movie Add(Movie movie);
        IEnumerable<Movie> GetAll();
        void DeleteMovie(int movieId);
        void UpdateMovie(Movie movie);
        IEnumerable<Movie> GetRanking(int pageSize, SortOrder sortOrder);
        Movie GetRandom();
    }
}
