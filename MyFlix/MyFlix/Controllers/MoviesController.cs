using MyFlix.Models;
using MyFlix.ViewModels;
using System;
using System.Collections;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFlix.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Movies
        //public ActionResult Random()
        //{
        //    var movie = new Movie(){ ID = 1, Name = "MarudhaNayagam" };

        //    //return View(movie);
        //    //return Content("Hello Mams");
        //    return RedirectToAction("Index", "Home");
        //}

        //public ActionResult Edit(int id)
        //{
        //    return Content("id="+ id);
        //}

        public ActionResult Edited(int? pageid, string sortby)
        {
            pageid = pageid.HasValue ? pageid : 1;
            sortby = string.IsNullOrWhiteSpace(sortby) ? "Name" : sortby;
            return Content(string.Format("pageid={0};SortBy={1}",pageid,sortby));
        }

        [Route("movies/released/{year}/{month:range(1,12)}")]
        public ActionResult ByReleased(int year, int month)
        {
            return Content(string.Format("{0}/{1}", year, month));
        }

        public ActionResult Random()
        {
            var movie = new Movie() { Name = "MarudhaNayagam" };
            var customers = new List<Customer>()
            {
                new Customer() {Name = "Giri" },
                new Customer() {Name = "Preethi" }
            };
            var randomViewModel = new RandomMovieViewModel() { Movie = movie, Customers = customers };

            return View(randomViewModel);

        }

        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m=>m.Genre);
            return View(movies);
        }

        public ActionResult Details(int Id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.ID == Id);
            if (movie == null)
                return HttpNotFound();
            return View(movie);
        }

        public ActionResult New()
        {
            var genres = _context.Genres;

            var viewModel = new MovieViewModel
            {
                Movie = new Movie(),
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult Remove(int ID)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.ID == ID);

            if (movie == null)
                return HttpNotFound();

            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return View("Index", _context.Movies.Include(m=>m.Genre));
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.ID==id);

            if (movie == null)
                return HttpNotFound();

            var genres = _context.Genres;

            var viewModel = new MovieViewModel
            {
                Genres = genres,
                Movie = movie
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (movie.ID == 0)
                _context.Movies.Add(movie);
            else
            {
                var movieINDB = _context.Movies.Single(m => m.ID == movie.ID);
                movieINDB.Name = movie.Name;
                movieINDB.ReleasedDate = movie.ReleasedDate;
                movieINDB.DateAdded = movie.DateAdded;
                movieINDB.GenreId = movie.GenreId;
                movieINDB.NumberInStock = movie.NumberInStock;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }
    }
}