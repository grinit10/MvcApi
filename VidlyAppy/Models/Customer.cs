using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VidlyAppy.Models
{
    public class Customer
    {
        public int id { get; set; }

        [Required]
        [StringLength(500)]
        public string Name { get; set;}

        public bool IsSubscribedNewsLetter { get; set; }

        [Display(Name = "Date of Birth")]
        [AgeCounting]
        public DateTime? BirthDay { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        public MembershipType MembershipType { get; set; }
        
    }
}