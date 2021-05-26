using Almara.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using AutoMapper;
using Almara.Dtos;

namespace Almara.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetMovies(string query=null)
        {
            var movieQuery = _context.Movies.Include(m => m.Genre);
            if (!String.IsNullOrWhiteSpace(query))
                movieQuery = movieQuery.Where(m => m.Name == query);
                var movieDto = movieQuery.ToList().Select(Mapper.Map<Movie, MovieDto>);

                return Ok(movieDto);

            

            
        }


        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie==null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Movie, MovieDto>(movie));

        }
        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + movie.Id),movieDto);


        }

        [HttpPut]
        public IHttpActionResult Update(MovieDto movieDto,int id)
        {
            if (!ModelState.IsValid) // checks if the passed object is valid
            {
                return BadRequest();
            }

            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb==null)
            {
                return NotFound();
            }

            movieDto.Id = movieInDb.Id;
            Mapper.Map(movieDto,movieInDb); // maps the variables instead of the types.
            _context.SaveChanges();

            return Ok();



        }

        [HttpDelete]
        public IHttpActionResult Delete (int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb==null)
            {
                return NotFound();
            }
            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();
            return Ok();
        }
        
        
    }
}
