using E_Tickets.Data.Base;
using E_Tickets.Data.ViewModels;
using E_Tickets.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Tickets.Data.Services
{

    public class MoviesService : EntityBaseRepository<Movie>, IMoviesService
    {
        private readonly AppDbContext _context;
        public MoviesService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task addNewMovieAsync(NewMovieVM data)
        {
            var newMovie = new Movie()
            {
                Name = data.Name,
                Description = data.Description,
                Price = data.Price,
                ImageUrl = data.ImageUrl,
                CinemaID = data.CinemaID,
                StartDate = data.StartDate,
                EndDate = data.EndDate,
                MovieCategory = data.MovieCategory,
                ProducerID = data.ProducerID
            };
            await _context.Movies.AddAsync(newMovie);
            await _context.SaveChangesAsync();
            foreach (var actorId in data.ActorsIds)
            {
                var newActor = new Actor_Movie()
                {
                    MovieId = newMovie.Id,
                    ActorId = actorId
                };
                await _context.SaveChangesAsync();

            }

        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            var movieDetails = await _context.Movies.Include(c => c.Cinema).
               Include(c => c.Producer)
               .Include(am => am.Actors_Movies)
               .ThenInclude(a => a.Actor).FirstOrDefaultAsync(n => n.Id == id);
            return movieDetails;
        }

        public async Task<NewMovieDropDownsVM> GetNewMovieDropDownsValues()
        {
            var response = new NewMovieDropDownsVM()
            {
                Producers = await _context.Producers.OrderBy(n => n.FullName)
                                                    .ToListAsync(),
                Cinemas = await _context.Cinemas.OrderBy(n => n.Name)
                                                .ToListAsync(),
                Actors = await _context.Actors.OrderBy(n => n.FullName)
                                              .ToListAsync()
            };

            return response;
        }

        public async Task UpdateMovieAsync(NewMovieVM data)
        {
            var dbMovie = await _context.Movies.FirstOrDefaultAsync(n => n.Id == data.ID);
            if (dbMovie != null)
            {
                dbMovie.Name = data.Name;
                dbMovie.Description = data.Description;
                dbMovie.Price = data.Price;
                dbMovie.ImageUrl = data.ImageUrl;
                dbMovie.CinemaID = data.CinemaID;
                dbMovie.StartDate = data.StartDate;
                dbMovie.EndDate = data.EndDate;
                dbMovie.MovieCategory = data.MovieCategory;
                dbMovie.ProducerID = data.ProducerID;
                await _context.SaveChangesAsync();

            }
            //Supp les acteurs
            var existingactorsdb = _context.Actors_Movies.Where(n => n.MovieId == data.ID).ToList();
            _context.Actors_Movies.RemoveRange(existingactorsdb);
            await _context.SaveChangesAsync();

            foreach (var actorId in data.ActorsIds)
            {
                var newActorMovie = new Actor_Movie()
                {
                    MovieId = data.ID,
                    ActorId = actorId
                };
                await _context.Actors_Movies.AddAsync(newActorMovie);
                await _context.SaveChangesAsync();

            }
        }
    }
}
