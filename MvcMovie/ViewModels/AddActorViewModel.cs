using MvcMovie.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MvcMovie.ViewModels
{
    public class AddActorViewModel
    {
        public Actor Actor { get; set; }

        public IEnumerable<SelectListItem> Movies { get; set; }
        public IEnumerable<int> SelectedMovies { get; set; }
    }
}