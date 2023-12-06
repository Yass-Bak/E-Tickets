using E_Tickets.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace E_Tickets.Models
{
    public class NewMovieVM
    {
        [Display(Description = "Titre")]
        [Required(ErrorMessage = " Titre est Obligatoire")]
        public string Name { get; set; }
        [Display(Description = "Description ")]
        [Required(ErrorMessage = " Description est Obligatoire")]
        public string Description { get; set; }
        [Display(Description = "Prix en TND ")]
        [Required(ErrorMessage = " Prix est Obligatoire")]
        public double Price { get; set; }
        [Display(Description = "Poster  du film")]
        [Required(ErrorMessage = " Image est Obligatoire")]
        public string ImageUrl { get; set; }
        [Display(Description = "Date Début ")]
        [Required(ErrorMessage = " DateDébut est Obligatoire")]
        public DateTime StartDate { get; set; }
        [Display(Description = "date de fin ")]
        [Required(ErrorMessage = " date de fin est Obligatoire")]
        public DateTime EndDate { get; set; }
        [Display(Description = "Catégorie")]
        [Required(ErrorMessage = "catégorie est Obligatoire")]
        public MovieCategory MovieCategory { get; set; }
        [Display(Description = "Acteur")]
        [Required(ErrorMessage = "Acteur est Obligatoire")]
        public List<int> ActorsIds { get; set; }
        [Display(Description = "Cinema")]
        [Required(ErrorMessage = "Cinema est Obligatoire")]
        public int CinemaID { get; set; }
        [Display(Description = "Producteur")]
        [Required(ErrorMessage = "Producteur est Obligatoire")]
        public int ProducerID { get; set; }

    }
}
