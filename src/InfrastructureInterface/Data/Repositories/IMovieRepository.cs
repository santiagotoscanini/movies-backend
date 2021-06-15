using Entities;
using System.Collections.Generic;

namespace InfrastructureInterface.Data.Repositories
{
    public interface IMovieRepository
    {
        Movie Add(Movie movie);
        IEnumerable<Movie> GetAll();
        void DeleteMovie(int movieId);
        Movie UpdateMovie(Movie movie);
        IEnumerable<Movie> GetRanking(int pageSize, SortOrder sortOrder);
        Movie GetRandom();
    }
}
