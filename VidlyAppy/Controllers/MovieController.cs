using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyAppy.Models;
using VidlyAppy.ViewModels;

namespace VidlyAppy.Controllers
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
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("AdminView");

            return View("UserView");
        }
        // GET: Movie/random
        public ActionResult Details(int id)
        {
            var movie = _context.movies.Include("genre").SingleOrDefault(c => c.ID == id);
            if (movie == null)
                return HttpNotFound();
            return View(movie);
        }

        // create a new form to add new movie.
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Create()
        {
           
            var viewModel = new MovieGenreViewModel()
            {
              genres = _context.genres
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie Movie)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new MovieGenreViewModel(Movie)
                {
                    genres = _context.genres
                };
                return View("Create", viewModel);
            }
            if (Movie.ID == 0)
            {
                _context.movies.Add(Movie);
            }
                
            else
            {
                var movieDb = _context.movies.SingleOrDefault(c => c.ID == Movie.ID);
                movieDb.Name = Movie.Name;
                movieDb.ReleasedDate = Movie.ReleasedDate;
                movieDb.GenreId = Movie.GenreId;
                movieDb.DateAdded = Movie.DateAdded;
                movieDb.NumberInStock = Movie.NumberInStock;
            }
           
            _context.SaveChanges();
            return RedirectToAction("Index", "Movie");

        }

        //To Edit a movie
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var Movie = _context.movies.SingleOrDefault(c => c.ID == id);
            var genre = _context.genres.ToList();
            var viewModel = new MovieGenreViewModel(Movie)
            {
                genres = genre
            };
            return View("Create", viewModel);
        }

        [Route("movie/ReleasedByDate/{year}/{month:range(1, 12)}")]
        public ActionResult ReleasedDate(int year, int month)
        {
            return Content(year + "/" + month);
        }
    }
}