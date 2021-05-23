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

        public ActionResult Save(Movie movie)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == movie.Id);
            movieInDb.Name = movie.Name;
            movieInDb.ReleaseDate = movie.ReleaseDate;
            movieInDb.NumberInStock = movie.NumberInStock;
            movieInDb.DateAdded = movie.DateAdded;
            movieInDb.GenreId = movie.GenreId;
            _context.SaveChanges();


            return RedirectToAction("Index","Movie");
        }
       
        

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie==null)
            {
                return HttpNotFound();
            }
            var viewModel = new MovieFormViewModel()
            {   Movie = movie,
                Genres = _context.Genres.ToList()
               
            };

            return View(viewModel);

            







        }
        
        public ActionResult Add(Movie movie)
        {
            if (movie.Id==0)
            {
                _context.Movies.Add(movie);
            }
            
            _context.SaveChanges();
            return RedirectToAction("Index","Movie");
        }

 
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel { Genres=genres };

            return View("MovieForm",viewModel);
        }

        public ActionResult Index()
        {

            var movies = _context.Movies.Include(m => m.Genre).ToList();
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
        public ActionResult ByReleaseYear(int year, int month)
        {

            return Content(year + "/" + month);
        }


        public ActionResult Random()
        {

            var moviesDb = _context.Movies.Include(m => m.Genre).ToList();
            moviesDb.RemoveAll(movie => movie == null);
            var movies = new RandomMovieViewModel()
            {
                Movies = moviesDb
            };
            return View(movies);
        }

    }
}