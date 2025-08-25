using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Question2;
using Question2.Models;
using Question2.Repoestiry;

namespace Question2.Controllers
{
    public class MoviesController : Controller
    {
      
        // GET: Movies
      
        private readonly IMovies _repo;

        public MoviesController(IMovies repo)
        {
            _repo = repo;
        }

        public ActionResult Index() => View(_repo.GetAll());

        public ActionResult Create() => View();

        [HttpPost]
        public ActionResult Create(Movy movie)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        public ActionResult Edit(int id)
        {
            var movie = _repo.GetById(id);
            return View(movie);
        }

        [HttpPost]
        public ActionResult Edit(Movy movie)
        {
            if (ModelState.IsValid)
            {
                _repo.Update(movie);
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        public ActionResult Delete(int id)
        {
            var movie = _repo.GetById(id);
            return View(movie);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _repo.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult MoviesByYear(int year)
        {
            var movies = _repo.GetByYear(year);
            return View(movies);
        }

        public ActionResult MoviesByDirector(string directorName)
        {
            var movies = _repo.GetByDirector(directorName);
            return View(movies);
        }
    }


}





