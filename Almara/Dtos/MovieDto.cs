using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Almara.Dtos
{
    public class MovieDto
    {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }


        [Required]
        [Range(1900, 2021)]
        public int ReleaseYear { get; set; }


        public DateTime? DateAdded { get; set; }

        [Required]
        [Range(1, 20)]
        public int NumberInStock { get; set; }

        public GenreDto Genre { get; set; }
        [Required]
        
        public int GenreId { get; set; }
    }
}