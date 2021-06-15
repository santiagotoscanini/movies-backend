using Entities;
using System.ComponentModel.DataAnnotations;

namespace Web.Models.MovieModels
{
    public class MovieCreatingModel
    {
        [Required] public string MovieName { get; set; }

        [Required] public int GuessedTimes { get; set; }

        [Required] public int SelectedTimes { get; set; }

        [Required] public string ImageURL { get; set; }

        public Movie ToEntity()
        {
            return new Movie
            {
                MovieName = MovieName,
                GuessedTimes = GuessedTimes,
                SelectedTimes = SelectedTimes,
                ImageUrl = ImageURL,
            };
        }
    }
}
