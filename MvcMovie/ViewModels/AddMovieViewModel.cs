using MvcMovie.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MvcMovie.ViewModels
{
    public class AddMovieViewModel
    {
        public Movie Movie { get; set; }

        public IEnumerable<SelectListItem> Actors { get; set; }
        public IEnumerable<int> SelectedActors { get; set; }
    }
}