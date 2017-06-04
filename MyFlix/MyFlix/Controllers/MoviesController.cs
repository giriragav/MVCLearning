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

        public ActionResult Edit(int id)
        {
            return Content("id="+ id);
        }

        public ActionResult Edited(int? pageid, string sortby)
        {
            pageid = pageid.HasValue ? pageid : 1;
            sortby = string.IsNullOrWhiteSpace(sortby) ? "Name" : sortby;
            return Content(string.Format("pageid={0};SortBy={1}",pageid,sortby));
        }

        public ActionResult ByReleased(int year, int month)
        {
            return Content(string.Format("{0}/{1}", year, month));
        }
    }
}