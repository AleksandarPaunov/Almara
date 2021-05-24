using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Almara.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        
        [Required]
        [Display(Name = "Release Year")]
        [Range(1900,2021)]
        public int ReleaseYear { get; set; }

        
        public DateTime? DateAdded { get; set; }

        [Required] 
        [Display(Name="Number in stock")]
        
        public int NumberInStock { get; set; }

        
        public Genre Genre { get; set; }

        [Required]
        [Display(Name="Genre")]
        public int GenreId { get; set; }

    }
}