using Almara.Models;
using Almara.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Almara.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext _context;
        public MovieController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movie
        public ActionResult Random()
        {

            var moviesDb = _context.Movies.Include(m => m.Genre).ToList();
            if(moviesDb == null)
            {
                return Content("There are no movies in the database!");
            }
            var movies = new RandomMovieViewModel()
            {
                Movies = moviesDb
            };
            return View(movies);
        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        public ActionResult Index()
        {

            var movies = _context.Movies.Include(m=>m.Genre).ToList();
            var listMovies = new RandomMovieViewModel
            {
                Movies = movies
            };


            return View(listMovies);



        }

        public ActionResult Details(int id)
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            var movieList = movies.SingleOrDefault(x => x.Id == id);
            if (movieList == null)
            {
                return Content("No such movie found in the database!");
            }
            return View(movieList);
        }

        [Route("movie/released/{year}/{month:range(1, 12):regex(\\d{2})}")]
        public ActionResult ByReleaseYear(int year,int month)
        {

            return Content(year + "/" + month);
        }

    }
}