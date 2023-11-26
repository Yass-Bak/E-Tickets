using E_Tickets.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Tickets.Models
{
    public class Movie
    {
        [Key]
       public int Id { get; set; }
        
        public string Name { get; set; }
        public string Description { get; set; }

        public double Price { get; set; }
      
        public string ImageUrl { get; set;}
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovieCategory MovieCategory { get; set; }
        public List<Actor_Movie> Actors_Movies { get; set; }
        public int CinemaID { get; set; }
        [ForeignKey("CinemaID")]
        public Cinema Cinema { get; set; }
        public int ProducerID { get; set; }
        [ForeignKey("ProducerID")]
        public Producer Producer { get; set; }




    }
}
