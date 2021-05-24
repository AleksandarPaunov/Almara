using Almara.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Almara.ViewModels
{
    public class MovieFormViewModel
    {
        
        public IEnumerable<Genre> Genres { get; set; }
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }


        [Required]
        [Display(Name = "Release Year")]
        [Range(1900, 2021)]
        public int? ReleaseYear { get; set; }


        [Required]
        [Display(Name = "Number in stock")]
        [Range(1, 20)]
        public int? NumberInStock { get; set; }


        [Required]
        [Display(Name = "Genre")]
        public int? GenreId { get; set; }

        public MovieFormViewModel()
        {
            Id = 0;
        }
        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseYear = movie.ReleaseYear;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }
    }
}