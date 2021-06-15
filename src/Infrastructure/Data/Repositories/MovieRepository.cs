using Entities;
using Exceptions;
using InfrastructureInterface.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Data.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly DbContext _context;
        private readonly DbSet<Movie> _movies;

        private const string MovieAlreadyExistMessage = "There is already a movie registered with the id: ";
        private const string MovieNotFound = "There is not movie registered with the id: ";

        public MovieRepository(DbContext context)
        {
            _context = context;
            _movies = context.Set<Movie>();
        }

        public Movie Add(Movie movie)
        {
            try
            {
                return AddAndReturnMovie(movie);
            }
            catch (DbUpdateException)
            {
                throw new ObjectAlreadyExistException(MovieAlreadyExistMessage + movie.MovieId);
            }
            catch (InvalidOperationException)
            {
                throw new ObjectAlreadyExistException(MovieAlreadyExistMessage + movie.MovieId);
            }
            catch (ArgumentException)
            {
                throw new ObjectAlreadyExistException(MovieAlreadyExistMessage + movie.MovieId);
            }
        }

        private Movie AddAndReturnMovie(Movie movie)
        {
            var movieToReturn = _movies.Add(movie).Entity;
            _context.SaveChanges();
            return movieToReturn;
        }

        public IEnumerable<Movie> GetAll()
        {
            return _movies;
        }

        public void DeleteMovie(int movieId)
        {
            var movie = GetMovieById(movieId);
            _movies.Remove(movie);
            _context.SaveChanges();
        }

        private Movie GetMovieById(int movieId)
        {
            try
            {
                var movie = _movies.First(m => m.MovieId == movieId);
                return movie;
            }
            catch (InvalidOperationException)
            {
                throw new NotFoundException(MovieNotFound + movieId);
            }
        }

        public Movie UpdateMovie(Movie movie)
        {
            var movieSaved = GetMovieById(movie.MovieId);
            if (movie.GuessedTimes != 0)
            {
                movieSaved.GuessedTimes += movie.GuessedTimes;
            }

            if (movie.SelectedTimes != 0)
            {
                movieSaved.SelectedTimes += movie.SelectedTimes;
            }

            var movieUpdated = _movies.Update(movieSaved).Entity;
            _context.SaveChanges();
            return movieUpdated;
        }

        public IEnumerable<Movie> GetRanking(int pageSize, SortOrder sortOrder)
        {
            var sortingOrder = SortingByOrder(sortOrder);
            
            return _movies
                .Where(m => m.SelectedTimes > 0)
                .OrderByDescending(sortingOrder)
                .Take(pageSize);
        }

        public Movie GetRandom()
        {
            return _movies.OrderBy(r => Guid.NewGuid()).First();
        }

        private Func<Movie, int> SortingByOrder(SortOrder sortOrder)
        {
            Func<Movie, int> funcOrder;
            
            switch (sortOrder)
            {
                case SortOrder.Guessed:
                    funcOrder = (m) => m.GuessedTimes;
                    break;
                case SortOrder.Selected:
                    funcOrder = (m) => m.SelectedTimes;
                    break;
                default:
                    funcOrder = (m) => m.GuessedTimes;
                    break;
            }

            return funcOrder;
        }
    }
}
