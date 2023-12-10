using System.ComponentModel.DataAnnotations;

namespace E_Tickets.Data.ViewModels
{
    public class LoginVM
    {
        [Display(Name = "Adresse Mail")]
        [Required(ErrorMessage = "Adresse Mail est requise")]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = "Mot de passe ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
