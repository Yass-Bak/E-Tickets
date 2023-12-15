using E_Tickets.Data.Base;
using E_Tickets.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Tickets.Models
{
    public class Movie : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Titre")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "Prix")]
        public double Price { get; set; }
        [Display(Name = "Poster")]
        public string ImageUrl { get; set; }
        [Display(Name = "Date Début")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Date Fin")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Catégorie")]
        public MovieCategory MovieCategory { get; set; }
        public virtual List<Actor_Movie> Actors_Movies { get; set; }
        public int CinemaID { get; set; }
        [ForeignKey("CinemaID")]
        public virtual Cinema Cinema { get; set; }
        public int ProducerID { get; set; }
        [ForeignKey("ProducerID")]
        public virtual Producer Producer { get; set; }




    }
}
