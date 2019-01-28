using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VidlyAppy.Models
{
   
    public class CustomerMovie
    {
       
        public int Id { get; set; }

        [Required]
        public Customer customer { get; set; }

        [Required]
        public Movie movie { get; set; }

        public DateTime DateRented { get; set; }
        public DateTime? DateReturned { get; set; }
        
    }

}