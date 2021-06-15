using System;
using System.ComponentModel.DataAnnotations;
using Entities;

namespace Web.Models.MovieModels
{
    public class MoviesRankedFilterModel
    {
        [Required]
        public int pageSize { get; set; }
        [Required]
        public SortOrder sortOrder { get; set; }
    }
}
