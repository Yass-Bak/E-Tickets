using System.ComponentModel.DataAnnotations.Schema;

namespace E_Tickets.Models
{
    public class Actor_Movie

    {


        [ForeignKey("MovieId")]
        public int MovieId { get; set; }

        // Mark the navigation property as virtual
        public virtual Movie Movie { get; set; }

        [ForeignKey("ActorId")]
        public int ActorId { get; set; }

        // Mark the navigation property as virtual
        public virtual Actor Actor { get; set; }
    }

}
