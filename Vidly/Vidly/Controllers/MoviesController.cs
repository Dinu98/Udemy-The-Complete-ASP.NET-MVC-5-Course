using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        [Route("movies")]
        public ActionResult Index()
        {
            var movies = new List<Movie>
            {
                new Movie{Name="Movie1"},
                new Movie{Name="Movie2"}
            };

            var viewModel = new MoviesAndCustomersViewModel
            {
                Movies = movies
            };

            return View(viewModel);
        }
    }
}