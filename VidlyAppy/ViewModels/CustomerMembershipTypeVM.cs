using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyAppy.Models;

namespace VidlyAppy.ViewModels
{
    public class CustomerMembershipTypeVM
    {
       public Customer customer { get; set; }
       public  IEnumerable<MembershipType> membershipTypes { get; set; }
    }
}