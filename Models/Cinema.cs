using System.ComponentModel.DataAnnotations;

namespace E_Tickets.Models
{
    public class Cinema
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Logo du cinema")]
        public string  Logo { get; set; }
        [Display(Name = "Nom")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        public List<Movie> Movies { get; set; }

    }
}
