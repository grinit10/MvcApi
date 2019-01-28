using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VidlyAppy.Models
{
    public class Movie
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name ="Released Date")]
        public DateTime ReleasedDate { get; set; }

        [Required]
        [Display(Name="Date Added")]
        public DateTime DateAdded { get; set; }

        [Required]
        [Display(Name="Number In Stock")]
        [Range(01, 20)]
        public int NumberInStock { get; set; }

        public int? NumberAvailable { get; set; }

        [Required]
        [Display(Name="Genre Type")]
        public int GenreId { get; set; }

        public Genre genre { get; set; }
    }
}