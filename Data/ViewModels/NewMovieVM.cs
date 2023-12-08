using E_Tickets.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace E_Tickets.Models
{
    public class NewMovieVM
    {
        public int ID { get; set; }

        [Display(Name = "Titre")]
        [Required(ErrorMessage = " Titre est Obligatoire")]
        public string Name { get; set; }
        [Display(Name = "Description ")]
        [Required(ErrorMessage = " Description est Obligatoire")]
        public string Description { get; set; }
        [Display(Name = "Prix en TND ")]
        [Required(ErrorMessage = " Prix est Obligatoire")]
        public double Price { get; set; }
        [Display(Name = "Poster  du film")]
        [Required(ErrorMessage = " Image est Obligatoire")]
        public string ImageUrl { get; set; }
        [Display(Name = "Date Début ")]
        [Required(ErrorMessage = " DateDébut est Obligatoire")]
        public DateTime StartDate { get; set; }
        [Display(Name = "date de fin ")]
        [Required(ErrorMessage = " date de fin est Obligatoire")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Catégorie")]
        [Required(ErrorMessage = "catégorie est Obligatoire")]
        public MovieCategory MovieCategory { get; set; }
        [Display(Name = "Acteur")]
        [Required(ErrorMessage = "Acteur est Obligatoire")]
        public List<int> ActorsIds { get; set; }
        [Display(Name = "Cinema")]
        [Required(ErrorMessage = "Cinema est Obligatoire")]
        public int CinemaID { get; set; }
        [Display(Name = "Producteur")]
        [Required(ErrorMessage = "Producteur est Obligatoire")]
        public int ProducerID { get; set; }

    }
}
