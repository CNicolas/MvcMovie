using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcMovie.Models
{
    [Table("Actor")]
    public class Actor
    {
        public int Id { get; set; }
        public string Fullname { get; set; }

        public List<Movie> Movies { get; set; }

        public virtual ICollection<MovieActor> MovieActor { get; set; }
    }
}