using System;
using System.ComponentModel.DataAnnotations;

namespace MyFlix.Models
{
    public class Customer
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Customer name is required")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Required(ErrorMessage ="Please select a Membership type")]
        public byte MembershipTypeID { get; set; }

        [Min18YearsIfaMember]
        public DateTime? BirthDate { get; set; }
    }
}