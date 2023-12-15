using E_Tickets.Data.Base;
using System.ComponentModel.DataAnnotations;

namespace E_Tickets.Models
{
    public class Producer : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Photo de profile")]
        [Required(ErrorMessage = "Il est obligatoire d'attacher un photo")]
        public string ProfilePictureUrl { get; set; }
        [Display(Name = "Nom")]
        [Required(ErrorMessage = "Il est obligatoire de saisir le nom")]
        public string FullName { get; set; }
        [Display(Name = "Bio")]
        [Required(ErrorMessage = "Il est obligatoire de saisir Bio")]
        [StringLength(10000, MinimumLength = 5, ErrorMessage = "Taille Minimum 5 caractéres")]
        public string Bio { get; set; }
        public virtual List<Movie>? Movies { get; set; }
    }
}
