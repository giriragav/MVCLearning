using MyFlix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFlix.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Random()
        {
            var movie = new Movie(){ ID = 1, Name = "MarudhaNayagam" };

            //return View(movie);
            //return Content("Hello Mams");
            return RedirectToAction("Index", "Home");
        }
    }
}