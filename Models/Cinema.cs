using E_Tickets.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace E_Tickets.Models
{
    public class Cinema : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Logo du cinema")]
        [Required(ErrorMessage = "Il est obligatoire d'attacher un photo")]
        public string Logo { get; set; }
        [Display(Name = "Nom")]
        [Required(ErrorMessage = "Il est obligatoire de saisir le nom")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Taille Minimum 3 caractéres")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Il est obligatoire de saisir la Description")]
        [StringLength(10000, MinimumLength = 5, ErrorMessage = "Taille Minimum 5 caractéres")]
        public string Description { get; set; }
        public List<Movie> Movies { get; set; }

    }
}
