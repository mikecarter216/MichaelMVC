using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyMoviesApp.Data;
using MyMoviesApp.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MyMoviesApp.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieContext _context;

        public MoviesController(MovieContext context)
        {
            _context = context;
        }

        // GET: Movies
        public async Task<IActionResult> Index(int? year)
        {
            var movies = from m in _context.Movies
                         select m;

            if (year.HasValue)
            {
                movies = movies.Where(m => m.ReleaseYear >= year.Value);
            }

            return View(await movies.ToListAsync());
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Genre,ReleaseYear,Price")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }
    }
}
