using System;
using System.ComponentModel.DataAnnotations;

namespace E_Tickets.Data.ViewModels
{
		public class AvisViewModel
		{
			public int Id { get; set; }

			public int MovieId { get; set; }

			public int UtilisateurId { get; set; }

			[Display(Name = "Commentaire")]
			[Required(ErrorMessage = "Le champ Commentaire est obligatoire.")]
			public string Commentaire { get; set; }

			[Display(Name = "Note")]
			[Range(1, 5, ErrorMessage = "La note doit être comprise entre 1 et 5.")]
			public int Note { get; set; }

			[Display(Name = "Date d'ajout")]
			public DateTime DateAjout { get; set; }

			// Additional properties can be added based on your requirements
		}
	}
