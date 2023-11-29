using System.ComponentModel.DataAnnotations;

namespace E_Tickets.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Photo de profile")]
        [Required(ErrorMessage ="Il est obligatoire d'attacher un photo")]
        public string ProfilePictureUrl { get; set;}
        [Display(Name = "Nom")]
        [Required(ErrorMessage = "Il est obligatoire de saisir le nom")]
        [StringLength(50 , MinimumLength =3 , ErrorMessage = "Taille Minimum 3 caractéres")]
        public string FullName { get; set;}
        [Display(Name = "Bio")]
        [Required(ErrorMessage = "Il est obligatoire de saisir Bio")]
        [StringLength(10000, MinimumLength = 5, ErrorMessage = "Taille Minimum 5 caractéres")]
        public string Bio {  get; set;}
        public List<Actor_Movie> Actors_Movies { get; set; }
    }
}
