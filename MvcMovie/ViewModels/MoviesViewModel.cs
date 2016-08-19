using MvcMovie.DAL;
using MvcMovie.DTO;
using MvcMovie.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;

namespace MvcMovie.ViewModels
{
    public class MoviesViewModel
    {
        [DisplayName("Movies")]
        public List<MovieDto> AllMovies { get; set; }
        [DisplayName("Actors")]
        public List<Actor> AllActors { get; set; }


        public Movie Movie { get; set; }

        public IEnumerable<int> SelectedActors { get; set; }
        public IEnumerable<SelectListItem> Actors { get; set; }

        public string CheckboxesName => "Actors";

    }
}
