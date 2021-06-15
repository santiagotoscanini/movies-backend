using Entities;

namespace Web.Models.MovieModels
{
    public class MovieBaseModel
    {
        public string MovieName { get; }
        public int MovieId { get; }
        public int GuessedTimes { get; }
        public int SelectedTimes { get; }
        public string ImageURL { get; }

        public MovieBaseModel(Movie movie)
        {
            MovieName = movie.MovieName;
            MovieId = movie.MovieId;
            GuessedTimes = movie.GuessedTimes;
            SelectedTimes = movie.SelectedTimes;
            ImageURL = movie.ImageUrl;
        }

        public override bool Equals(object obj)
        {
            var result = false;

            if (obj is MovieBaseModel movieModel)
            {
                result = MovieId == movieModel.MovieId;
            }

            return result;
        }
    }
}
