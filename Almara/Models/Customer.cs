using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Almara.Models
{
    public class Customer
    {
        
        public int Id { get; set; }
        [Required(ErrorMessage ="Please enter customer's name.")]
        [StringLength(255)]
        
        public string Name { get; set; }
        
        public bool IsSubscribedToNewsletter { get; set; }
       
        public MembershipType MembershipType { get; set; }

        [Display(Name="Membership Type")]
        public int MembershipTypeId { get; set; }

        [Min18IfAMember]
        [Display(Name="Date of Birth")]
        public DateTime? BirthDate { get; set; }


    }
}