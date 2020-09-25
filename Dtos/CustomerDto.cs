using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Flixster.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }


        [Required, StringLength(255)]
        public string Name { get; set; }


        public DateTime? Birthdate { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipTypeDto MembershipType { get; set; }

        [Required]
        public byte MembershipTypeId { get; set; }
    }
}