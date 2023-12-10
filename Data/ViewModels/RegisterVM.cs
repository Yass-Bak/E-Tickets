using System.ComponentModel.DataAnnotations;

namespace E_Tickets.Data.ViewModels
{
    public class RegisterVM
    {
        [Display(Name = "Nom")]
        [Required(ErrorMessage = "Le nom est requis")]
        public string FullName { get; set; }

        [Display(Name = "Adresse Mail")]
        [Required(ErrorMessage = "Adresse Mail est requis")]
        public string EmailAddress { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirmer Mot de passe")]
        [Required(ErrorMessage = "Confirmer Mot de passe est requis")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Les mots de passe ne correspondent pas")]
        public string ConfirmPassword { get; set; }
    }
}
