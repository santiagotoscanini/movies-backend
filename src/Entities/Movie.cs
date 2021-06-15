namespace Entities
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string ImageUrl { get; set; }
        public int GuessedTimes { get; set; }
        public int SelectedTimes { get; set; }

        public override bool Equals(object obj)
        {
            var result = false;

            if (obj is Movie movie)
            {
                result = this.MovieId == movie.MovieId;
            }

            return result;
        }
    }
}
