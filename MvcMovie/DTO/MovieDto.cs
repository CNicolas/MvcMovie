using MvcMovie.Models;
using System;
using System.Collections.Generic;

namespace MvcMovie.DTO
{
    public class MovieDto
    {
        public Movie Movie { get; set; }
        public string Name { get; private set; }
        public string Realisator { get; private set; }
        public DateTime? Date { get; private set; }
        public string Genre { get; private set; }
        public List<Actor> Actors { get; set; }

        public MovieDto(Movie movie)
        {
            Movie = movie;
            Name = movie.Name;
            Realisator = movie.Realisator;
            Date = movie.Date;
            Genre = movie.Genre;
        }
    }
}