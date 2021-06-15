using System.ComponentModel.DataAnnotations;
using Entities;

namespace Web.Models.MovieModels
{
    public class MovieUpdatingModel
    {
        [Required] public int GuessedTimes { get; set; }
        [Required] public int SelectedTimes { get; set; }

        public Movie ToEntity(int movieId)
        {
            return new Movie
            {
                MovieId = movieId,
                GuessedTimes = this.GuessedTimes,
                SelectedTimes = this.SelectedTimes,
            };
        }
    }
}
