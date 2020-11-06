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
        [Required, StringLength(255)]
        public String Name { get; set; }
        [Required]
        public bool IsSubscribedToNewsletter { get; set; }
        [Required]
        public MembershipType MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }
        [Display(Name = "Date of Birth")]
        public DateTime? Birthday { get; set; }

    }
}