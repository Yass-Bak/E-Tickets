using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace E_Tickets.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Nom")]
        public string FullName { get; set; }
    }
}
