using E_Tickets.Models;
using System.Collections.Generic;

namespace E_Tickets.Data.ViewModels
{
    public class MoviesDetailViewModel
    {
        public List<Avis>? AvisMovies { get; set; }
        public Movie Movies { get; set; }
    }
}
