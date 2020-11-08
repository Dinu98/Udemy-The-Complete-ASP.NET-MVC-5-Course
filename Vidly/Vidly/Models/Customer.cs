using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customer name"), StringLength(255)]
        public String Name { get; set; }

        [Required]
        public bool IsSubscribedToNewsletter { get; set; }

        [Display(Name = "Membership Type")]
        public MembershipType MembershipType { get; set; }
        [Required]
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Date of Birth"), Min18Years]
        public DateTime? Birthday { get; set; }

    }
}