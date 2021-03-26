using Assignment3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //might need to take out the 3 context lines here
        private MovieDbContext _context { get; set; }

        public HomeController(ILogger<HomeController> logger, MovieDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovies()
        {
            return View();
        }

        //change post for sqlite db
        [HttpPost]
        public IActionResult AddMovies(AddMoviesModel addmovie)
        {
            //TempStorage.AddApplication(addmovie);
            //replace temp storage with this
            //_context.AddMoviesModel.Add(addmovie)
            return View("Confirmation", addmovie);
        }
        //edit db movie entry
        [HttpGet]
        public IActionResult EditMovies()
        {
            return View();
        }
        [HttpPost]
        public IActionResult EditMovies(AddMoviesModel addmovie)
        {
            _context.Movies.Update(addmovie);
            _context.SaveChanges();
            return View("EditConfirmation", addmovie);
        }
        //delete db movie entry
        [HttpPost]
        public IActionResult DeleteMovies(AddMoviesModel addmovie)
        {
            IQueryable<AddMoviesModel> moviesList = _context.Movies.Where(m => m.MovieID == addmovie.MovieID);
            foreach (var x in moviesList)
            {
                _context.Movies.Remove(x);
            }
            _context.SaveChanges();
            return View("DeleteConfirmation");
        }

        public IActionResult MovieList()
        {
            //switch from temp storage to sqlite db
            return View(_context.Movies.Where(x => x.title != "Independence Day"));
            //return View(TempStorage.Movies.Where(x => x.title != "Independence Day"));
        }

        public IActionResult MyPodcasts()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
