using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Flixster.Models
{
    public class Movie
    {
        public Movie()
        {
            DateAdded = DateTime.Now;
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public Genre Genre { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public int GenreId { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Date Added")]
        [Column(TypeName = "datetime2")]
        public DateTime DateAdded { get; set; }

        [Required]
        [Display(Name = "Copies Available")]
        [Range(1,20)]
        public byte CopiesAvailable { get; set; }
    }
}