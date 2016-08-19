using System.Collections.Generic;

namespace MvcMovie.Models
{
    public class Actor
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public List<Movie> Movies { get; set; }
    }
}