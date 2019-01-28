using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VidlyAppy.Models;
using VidlyAppy.ViewModels;

namespace VidlyAppy.Controllers.Api
{
    public class NewRentalController : ApiController
    {
        private ApplicationDbContext _context;
        public NewRentalController()
        {
            _context = new ApplicationDbContext();
            
        }

        //Post Rental
        [HttpPost]
        public IHttpActionResult PostRental(CustomerMovieVM customerMovieVM)
        {
            var Customer = _context.customers.Single(c => c.id == customerMovieVM.customerId);

            var movies = _context.movies.Where(
                m => customerMovieVM.movieIds.Contains(m.ID));

            foreach (var movy in movies)
            {
                if (movy.NumberAvailable == 0)
                    return BadRequest("Movie is not available.");

                movy.NumberAvailable--;

                var CustomerMovie = new CustomerMovie
                {
                    customer = Customer,
                    movie = movy,
                    DateRented = DateTime.Now

                };
                
                _context.CustomerMovies.Add(CustomerMovie);
      
                
            }
            _context.SaveChanges();


            return Ok();
        }




        //Get Movies
        [HttpGet]
        public IHttpActionResult GetRental()
        {
            
            return Ok(_context.movies.ToList());
        }


        //Post new rental form
        //public IHttpActionResult PostRental(CustomerMovieRental CustomerMovieVM)
        //{

        //    if(ModelState.IsValid)
        //    {

        //    }
        //}
    }
}
