using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private Dbctx db;

        public MoviesController()
        {
            db = new Dbctx();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }

        // GET: Movies
        [Route("movies")]
        public ActionResult Index()
        {
            var movies = db.Movies.Include("Genre").ToList();

            var viewModel = new MoviesAndCustomersViewModel
            {
                Movies = movies
            };

            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = db.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);

            return View(movie);
        }
    }
}