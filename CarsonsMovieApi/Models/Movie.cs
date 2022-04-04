using System;
using System.Collections.Generic;

namespace CarsonsMovieApi.Models
{
    public partial class Movie
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public int? Year { get; set; }
        public string? Actors { get; set; }
        public string? Directors { get; set; }
    }
}
