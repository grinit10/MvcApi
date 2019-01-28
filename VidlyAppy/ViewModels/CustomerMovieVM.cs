using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VidlyAppy.ViewModels
{
    public class CustomerMovieVM
    {
        public int customerId { get; set; }
        [Required]
        public List<int> movieIds { get; set; }
    }
}