﻿using System.ComponentModel.DataAnnotations;

namespace E_Tickets.Models
{
    public class Producer
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Photo de profile")]
        public string ProfilePictureUrl { get; set; }
        [Display(Name = "Nom")]
        public string FullName { get; set; }
        [Display(Name = "Bio")]
        public string Bio { get; set; }
        public List<Movie> Movies { get; set;}
    }
}