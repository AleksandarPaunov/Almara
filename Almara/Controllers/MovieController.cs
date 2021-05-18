using Almara.Models;
using Almara.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Almara.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Random()
        {
            var movie = new List<Movie>
            {
                new Movie{Name="Shrek",Id=1},
                new Movie{Name="Shazam",Id=2},
                new Movie{Name="Wall-e",Id=3},
                new Movie{Name="LoTR",Id=4}
            };

            var customers = new List<Customer>
            {
                new Customer{Name="Aleksandar" },
                 new Customer{Name="Marti" }
            };

            var viewModel = new RandomMovieViewModel()
            {
                Movies = movie,
                Customers = customers
            };
            
            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        public ActionResult Index()
        {

            var movies = GetMovies();
            var listMovies = new RandomMovieViewModel
            {
                Movies = movies
            };


            return View(listMovies);



        }

        public ActionResult Details(int id)
        {
            var movies = GetMovies();
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

        private List<Movie>GetMovies()
        {
            return new List<Movie>
            {
                new Movie {Name= "Shrek", Id=1},
                new Movie {Name= "Wall-e", Id=2},
                new Movie {Name= "Shazam", Id=3}

            };
        }
    }
}