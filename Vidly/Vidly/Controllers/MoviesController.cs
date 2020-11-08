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

        public ActionResult Details(int id)
        {
            var movie = db.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);

            return View(movie);
        }

        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel
                {
                    Movie = movie,
                    Genres = db.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }

            if (movie.Id == 0)
            {
                db.Movies.Add(movie);
            }
            else
            {
                var movieInDb = db.Movies.Single(c => c.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
            }

            db.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        public ActionResult New()
        {
            var genres = db.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Movie = new Movie(),
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var viewModel = new MovieFormViewModel
            {
                Genres = db.Genres.ToList(),
                Movie = db.Movies.SingleOrDefault(m => m.Id == id)
               
            };

            return View("MovieForm", viewModel);
        }
    }
}