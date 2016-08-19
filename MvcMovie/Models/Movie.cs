using System;
using System.Collections.Generic;

namespace MvcMovie.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Realisator { get; set; }
        public DateTime? Date { get; set; }
        public string Genre { get; set; }
        public List<Actor> Actors { get; set; }
    }
}