using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.MappingViews;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Flixster.Models;
using Flixster.ViewModels;

namespace Flixster.Controllers
{
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            return View(_context.Movies.Include(m => m.Genre).ToList());
        }

        public ActionResult Details(int Id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == Id);
            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }

        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

        public ActionResult New()
        {
            var genres = _context.Genres;
            var viewModel = new MovieFormViewModel()
            {
                Genres = genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel
                {
                    Movie = movie,
                    Genres = _context.Genres
                };
                return View("MovieForm", viewModel);
            }
            

            if (movie.Id == 0)
            {
                //movie.DateAdded = (DateTime)DateTime.Now;
                _context.Movies.Add(movie);
                
            }
            else
            {
                var existingMovie = _context.Movies.Single(m => m.Id == movie.Id);

                existingMovie.Name = movie.Name;
                existingMovie.ReleaseDate = (DateTime)movie.ReleaseDate;
                existingMovie.GenreId = movie.GenreId;

            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int Id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == Id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel()
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }
    }
}