using MvcMovie.Models;
using System.Collections.Generic;

namespace MvcMovie.ViewModels
{
    public class AddMovieViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<int> SelectedActors { get; set; }
    }
}