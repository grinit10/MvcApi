using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using VidlyAppy.Models;

namespace VidlyAppy.ViewModels
{
    public class MovieGenreViewModel
    {

        public IEnumerable<Genre> genres { get; set; }

        public int? ID { get; set; }
       

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Released Date")]
        public DateTime? ReleasedDate { get; set; }

        [Required]
        [Display(Name = "Date Added")]
        public DateTime? DateAdded { get; set; }

        [Required]
        [Display(Name = "Number In Stock")]
        [Range(01, 20)]
        public int? NumberInStock { get; set; }

        [Required]
        [Display(Name = "Genre Type")]
        public int? GenreId { get; set; }

        public string Title { get
            {
                return (ID != 0) ? "Edit Movie" : "New Movie";
            }
        }

        public MovieGenreViewModel()
        {
            ID = 0;
        }

        public MovieGenreViewModel(Movie Movie)
        {
            ID = Movie.ID;
            Name = Movie.Name;
            ReleasedDate = Movie.ReleasedDate;
            DateAdded = Movie.DateAdded;
            NumberInStock = Movie.NumberInStock;
            GenreId = Movie.GenreId;
            //genres = new List<Genre>();
        }

    }

        
}