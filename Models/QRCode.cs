using System.ComponentModel.DataAnnotations;

namespace E_Tickets.Models
{
    public class QRCodeModel
    {
        [Key]
        [Display(Name = "Enter QRCode Text")]
        public string QRCodeText { get; set; }

    }
}
