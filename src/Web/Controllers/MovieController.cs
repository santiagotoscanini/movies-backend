using System.Linq;
using ApplicationCoreInterface.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Web.Models.MovieModels;

namespace Web.Controllers
{
    /// <summary>
    /// Endpoints for Movie management.
    /// </summary>
    [Route("api/v1/movies")]
    public class MovieController : Controller
    {
        private IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        /// <summary>
        /// Creates a new Movie.
        /// </summary>
        /// <response code="201">Created successfully.</response>
        /// <response code="500">Internal Server Error.</response>
        [HttpPost]
        public IActionResult AddMovie([FromBody] MovieCreatingModel movieModel)
        {
            var movieToReturn = new MovieBaseModel(_movieService.Add(movieModel.ToEntity()));
            return StatusCode((int) HttpStatusCode.Created, movieToReturn);
        }

        /// <summary>
        /// Delete a movie.
        /// </summary>
        /// <response code="204">Removed successfully.</response>
        /// <response code="404">There is no movie with that ID.</response>
        /// <response code="500">Internal Server Error.</response>
        [HttpDelete("{movieId:int}")]
        public IActionResult DeleteMovie([FromRoute] int movieId)
        {
            _movieService.DeleteMovie(movieId);
            return NoContent();
        }

        /// <summary>
        /// Updates a movie.
        /// </summary>
        /// <response code="204">Updated successfully.</response>
        /// <response code="404">There is no movie with that ID.</response>
        /// <response code="500">Internal Server Error.</response>
        [HttpPut("{movieId:int}")]
        public IActionResult UpdateMovie([FromRoute] int movieId, [FromBody] MovieUpdatingModel movieUpdatingModel)
        {
            _movieService.UpdateMovie(movieUpdatingModel.ToEntity(movieId));
            return NoContent();
        }
        
        /// <summary>
        /// Get movies ranked.
        /// </summary>
        /// <response code="200">Movies fetched successfully.</response>
        /// <response code="400">Missing filter parameters.</response>
        /// <response code="500">Internal Server Error.</response>
        [HttpGet]
        public IActionResult GetMoviesRanked([FromQuery] MoviesRankedFilterModel filterModel)
        {
            return Ok( _movieService.GetRanking(filterModel.pageSize, filterModel.sortOrder).Select(m => new MovieBaseModel(m)));
        }

        /// <summary>
        /// Get random movie.
        /// </summary>
        /// <response code="200">Random movie fetched successfully.</response>
        /// <response code="500">Internal Server Error.</response>
        [HttpGet("random")]
        public IActionResult GetRandomMovie()
        {
            var movieModel = new MovieBaseModel(_movieService.GetRandom());
            return Ok(movieModel);
        }
    }
}
