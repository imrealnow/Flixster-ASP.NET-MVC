using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flixster.Dtos
{
    public class RentalDto
    {
        public int CustomerId { get; set; }
        public ICollection<int> MovieIds { get; set; }
    }
}