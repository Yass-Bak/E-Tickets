using E_Tickets.Data.Base;

namespace E_Tickets.Models
{
    public class Avis : IEntityBase
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int UtilisateurId { get; set; }
        public string Commentaire { get; set; }
        public int Note { get; set; }
        public DateTime DateAjout { get; set; }
    }
}
