
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VidlyAppy.Models;

namespace VidlyAppy.Controllers.Api
{
    //[Authorize(Roles = "CanManagerMovies")]
    [Authorize]
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }


        //Get All Movies api/Movies       
        public IHttpActionResult GetMovies(string query = null)
        {
            var moviesQuery = _context.movies.Include(c => c.genre)
                                .Where(c => c.NumberAvailable > 0);

            if (!string.IsNullOrWhiteSpace(query))
                moviesQuery = moviesQuery.Where(c => c.Name.Contains(query));

            var movies = moviesQuery.ToList();
            if (movies == null)
                return NotFound();

            return Ok(movies);
            
        }

        //GetMovieById api/movies/1
        public IHttpActionResult GetMovieById(int Id)
        {
            var movie = _context.movies.SingleOrDefault(c => c.ID == Id);
            if (movie == null)
                return NotFound();
            return Ok(movie);
        }


        //PostAMovie api/movies
        [HttpPost]
        public IHttpActionResult PostMovie(Movie Movie)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            _context.movies.Add(Movie);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + Movie.ID), Movie);
        }


        //Dpdate a movie api/movies/1
        [HttpPut]
        public IHttpActionResult UpdateMovie(int Id, Movie Movie)
        {
            var movie = _context.movies.SingleOrDefault(c => c.ID == Id);
            if (movie == null)
                return NotFound();
            movie.Name = Movie.Name;
            movie.ReleasedDate = Movie.ReleasedDate;
            movie.DateAdded = Movie.DateAdded;
            movie.GenreId = Movie.GenreId;
            movie.NumberInStock = Movie.NumberInStock;

            _context.SaveChanges();

            return Ok(Movie);

        }

        //DeleteAMovie api/movies/1
        [HttpDelete]
        public IHttpActionResult DeleteMovie(int Id)
        {
            var movie = _context.movies.SingleOrDefault(c => c.ID == Id);
            if (movie == null)
                return NotFound();
            _context.movies.Remove(movie);
            _context.SaveChanges();

            return Ok();

        }


    }
}
