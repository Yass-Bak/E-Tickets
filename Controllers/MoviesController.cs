using E_Tickets.Data;
using E_Tickets.Data.Services;
using E_Tickets.Data.ViewModels;
using E_Tickets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
namespace E_Tickets.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _service;
        private readonly IAvisService _avisService;
        private readonly AppDbContext _context;

        //      public MoviesController(IMoviesService service)
        //{
        //	_service = service;
        //}

        public MoviesController(IMoviesService service, IAvisService avisService)
        {
            _service = service;
            _avisService = avisService;
        }

        public async Task<IActionResult> Index()
        {
            // var allMovies = await _context.Movies.Include(n => n.Cinema).ToListAsync();

            var allMovies = await _service.GetAllAsync(n => n.Cinema);
            return View(allMovies);
        }
        public async Task<IActionResult> Details(int id)
        {
            var movieDetails = await _service.GetMovieByIdAsync(id);

            var avis = await _avisService.GetAllAsync();
            avis = avis.Where(a => a.MovieId == id).ToList<Avis>();

            // Créer un ViewModel.
            var vm = new MoviesDetailViewModel()
            {
                Movies = movieDetails,

                AvisMovies = (List<Avis>)avis
            };

            if (movieDetails == null) return View("Vide");
            return View(vm);
        }
        public async Task<IActionResult> Create()
        {
            var movieDropDownsData = await _service.GetNewMovieDropDownsValues();
            ViewBag.Cinemas = new SelectList(movieDropDownsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropDownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropDownsData.Actors, "Id", "FullName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM movie)
        {
            if (!ModelState.IsValid)
            {
                var movieDropDownsData = await _service.GetNewMovieDropDownsValues();
                ViewBag.Cinemas = new SelectList(movieDropDownsData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropDownsData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropDownsData.Actors, "Id", "FullName");
                return View(movie);
            }
            var allMovies = await _service.GetAllAsync(n => n.Cinema);
            if (allMovies.Where(x => x.Name == movie.Name).Count() > 0)
            {
                ViewBag.Message = "Film existe deja";
                return View();
            }
            else
            {
                await _service.addNewMovieAsync(movie);
                return RedirectToAction(nameof(Index));
            }

        }
        public async Task<IActionResult> Edit(int id)
        {

            var movieDetails = await _service.GetMovieByIdAsync(id);
            if (movieDetails == null) return View("Vide");

            var response = new NewMovieVM()
            {
                ID = movieDetails.Id,
                Name = movieDetails.Name,
                Description = movieDetails.Description,
                Price = movieDetails.Price,
                StartDate = movieDetails.StartDate,
                EndDate = movieDetails.EndDate,
                ImageUrl = movieDetails.ImageUrl,
                MovieCategory = movieDetails.MovieCategory,
                ProducerID = movieDetails.ProducerID,
                ActorsIds = movieDetails.Actors_Movies.Select(n => n.ActorId).ToList(),
            };
            var movieDropDownsData = await _service.GetNewMovieDropDownsValues();
            ViewBag.Cinemas = new SelectList(movieDropDownsData.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropDownsData.Producers, "Id", "FullName");
            ViewBag.Actors = new SelectList(movieDropDownsData.Actors, "Id", "FullName");
            return View(response);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewMovieVM movie)
        {
            if (id != movie.ID) return View("Vide");

            if (!ModelState.IsValid)
            {
                var movieDropDownsData = await _service.GetNewMovieDropDownsValues();
                ViewBag.Cinemas = new SelectList(movieDropDownsData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropDownsData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropDownsData.Actors, "Id", "FullName");
                return View(movie);
            }


            await _service.UpdateMovieAsync(movie);
            return RedirectToAction(nameof(Index));


        }
        public async Task<IActionResult> Filter(string searchString)
        {
            // var allMovies = await _context.Movies.Include(n => n.Cinema).ToListAsync();

            var allMovies = await _service.GetAllAsync(n => n.Cinema);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filterResult = allMovies.Where(n => n.Name.Contains(searchString) || n.Description.Contains(searchString)).ToList();
                return View("Index", filterResult);
            }
            return View("Index", allMovies);
        }

    }
}
